using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwzyProtocol;

namespace NetWatcher
{
    class PacketGridViewInfo
    {
        private DataGridView sourceView;
        private string no;
        private string time;
        private string source;
        private string destination;
        private string srcport;
        private string dstport;
        private string protocol;
        private string length;
        private string info;
        private string rule;
        private string flowProtocol;

        public PacketGridViewInfo(DataGridView sourceView)
        {
            this.sourceView = sourceView;
        }

        public void setPacketGridView(RawCapture rawPacket, uint id, string rules)
        {
            rule = rules;
            parseRawPacket(rawPacket, id);
        }

        public void parseRawPacket(RawCapture rawPacket, uint id)
        {
            time = "0.0";
            source = "-.-.-.-";
            destination = "-.-.-.-";
            protocol = "";
            length = rawPacket.Data.Length.ToString();
            info = "";
            flowProtocol = "";

            time = rawPacket.Timeval.Date.ToLocalTime().ToString();
            no = id.ToString();
            
            Packet packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
            
            EthernetPacket ep = (EthernetPacket)packet.Extract(typeof(EthernetPacket));

            if (ep != null)
            {
                protocol = "Ethernet(v2)";
                flowProtocol += "ethernet(v2)";
                source = ep.SourceHwAddress.ToString();
                destination = ep.DestinationHwAddress.ToString();

                //arp
                ARPPacket arp = (ARPPacket)packet.Extract(typeof(ARPPacket));
                if (arp != null)
                {
                    protocol = "ARP";
                    flowProtocol += "&" + "arp";
                }

                // ip
                IpPacket ip = (IpPacket)packet.Extract(typeof(IpPacket));
                if (ip != null)
                {
                    if (ip.Version == IpVersion.IPv4)
                    {
                        protocol = "IPv4";
                        flowProtocol += "&" + "ipv4";
                    }
                    else
                    {
                        protocol = "IPv6";
                        flowProtocol += "&" + "ipv6";
                    }

                    source = ip.SourceAddress.ToString();
                    destination = ip.DestinationAddress.ToString();

                    ICMPv6Packet icmpv6 = (ICMPv6Packet)packet.Extract(typeof(ICMPv6Packet));
                    if (icmpv6 != null)
                    {
                        protocol = "ICMPv6";
                        flowProtocol += "&" + "icmpv6";
                    }

                    // 传输层
                    TcpPacket tcp = (TcpPacket)packet.Extract(typeof(TcpPacket));
                    if (tcp != null)
                    {
                        protocol = "TCP";
                        flowProtocol += "&" + "tcp";
                        srcport = tcp.SourcePort.ToString();
                        dstport = tcp.DestinationPort.ToString();
                        info = string.Format("{0} -> {1}", srcport, dstport);

                        // 应用层
                        parseApp(tcp.PayloadData, tcp.SourcePort, tcp.DestinationPort);
                    }

                    UdpPacket udp = (UdpPacket)packet.Extract(typeof(UdpPacket));
                    if (udp != null)
                    {
                        protocol = "UDP";
                        flowProtocol += "&" + "udp";
                        srcport = udp.SourcePort.ToString();
                        dstport = udp.DestinationPort.ToString();
                        info = string.Format("{0} -> {1}", srcport, dstport);

                    }
                }
            }

            parseRule();
        }

        ushort AppSrcPort;
        ushort AppDstPort;

        // 应用层
        private void parseApp(byte[] payloadData, ushort srcPort, ushort dstPort)
        {
            if (payloadData.Length == 0)
            {
                return;
            }
            
            AppSrcPort = srcPort;
            AppDstPort = dstPort;

            if (isAnalysProtocol(80))
            {
                protocol = "HTTP";
                flowProtocol += "&" + "http";
                HttpPacket http = new HttpPacket(payloadData);
                HTTP(http);
            }
            else if (isAnalysProtocol(21))
            {
                protocol = "FTP";
                flowProtocol += "&" + "ftp";
                FtpPacket ftp = new FtpPacket(payloadData);
                FTP(ftp);
            }
        }

        private bool isAnalysProtocol(ushort port)
        {
            return (AppSrcPort == port) || (AppDstPort == port);
        }

        // 需要处理的转义字符
        char[] replaceCharArry ={
                                    '\0','\a','\b','\f',
                                    '\t','\v','?'
                               };

        // HTTP 协议
        private void HTTP(HttpPacket http)
        {
            if (http == null)
                return;

            List<CommandTypeHead> httplist = http.CreatHeadList();
            if (httplist.Count == 0)
                return;
            setInfo(httplist);
        }

        private void FTP(FtpPacket ftp)
        {
            if (ftp == null)
                return;

            List<CommandTypeHead> ftplist = ftp.CreatHeadList();
            if (ftplist.Count == 0)
                return;
            setInfo(ftplist);
        }

        private void setInfo(List<CommandTypeHead> list)
        {
            foreach (var i in list)
            {
                string tmpStr = i.Content;
                foreach (var j in replaceCharArry)
                {
                    tmpStr = tmpStr.Replace(j, '.');
                }
                info += " " + tmpStr;
            }
        }

        private void parseRule()
        {
            bool hit = false;

            rule = rule.ToLower();
            
            if (rule == "")
            {
                hit = true;
            }
            else
            {
                string[] rules = rule.Split('&');
                string[] flowProtocols = flowProtocol.Split('&');

                if (rules.Count() == 0 || flowProtocols.Count() == 0)
                {
                    return;
                }

                // protocol
                foreach (string r in rules)
                {
                    foreach (string f in flowProtocols)
                    {
                        if (r.Trim() == f.Trim())
                        {
                            hit = true;
                            break;
                        }
                    }
                }

                // address
                if (rule.Contains("ip.addr") && flowProtocol.Contains("ipv4"))
                {
                    if (!rule.Contains(source) && !rule.Contains(destination))
                    {
                        hit = false;
                    }
                    else
                    {
                        hit = true;
                    }
                }

                if (rule.Contains("ip.addr") && flowProtocol.Contains("ipv6"))
                {
                    if (!rule.Contains(source) && !rule.Contains(destination))
                    {
                        hit = false;
                    }
                    else
                    {
                        hit = true;
                    }
                }

                // port
                if (rule.Contains("tcp.port") && flowProtocol.Contains("tcp"))
                {
                    if (!rule.Contains(srcport) && !rule.Contains(dstport))
                    {
                        hit = false;
                    }
                    else
                    {
                        hit = true;
                    }
                }

                if (rule.Contains("udp.port") && flowProtocol.Contains("udp"))
                {
                    if (!rule.Contains(srcport) && !rule.Contains(dstport))
                    {
                        hit = false;
                    }
                    else
                    {
                        hit = true;
                    }
                }
            }
            
            if (hit)
            {
                setGridView();
            }
        }

        private string[] tcp = new string[] { "tcp", "http", "ftp"};
        private bool isTcpProtocol(string tprotocol)
        {
            foreach (string p in tcp)
            {
                if (p == tprotocol)
                {
                    return true;
                }
            }
            return false;
        }

        private string[] udp = new string[] { "udp", "pop", "smtp" };
        private bool isUdpProtocol(string tprotocol)
        {
            foreach (string p in udp)
            {
                if (p == tprotocol)
                {
                    return true;
                }
            }
            return false;
        }

        private void setGridView()
        {
            string[] cells = new string[7];
            cells[0] = no;
            cells[1] = time;
            cells[2] = source;
            cells[3] = destination;
            cells[4] = protocol;
            cells[5] = length;
            cells[6] = info;
            sourceView.Rows.Add(cells);
        }
    }
}
