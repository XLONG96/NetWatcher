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
    class PacketTreeInfo
    {
        private TreeView tree;
        private TreeNode frameNode;
        private Packet packet;

        public PacketTreeInfo(TreeView tree)
        {
            this.tree = tree;
        }

        public void setProtcolTree(RawCapture rawPacket, uint packetid)
        {
            if (frameNode == null)
            {
                frameNode = new TreeNode();
            }

            frameNode.Nodes.Clear();

            int len = rawPacket.Data.Length;
            string epochTime = rawPacket.Timeval.ToString();
            string localTime = rawPacket.Timeval.Date.ToLocalTime().ToString();

            frameNode.Text = string.Format("Frame {0}: {1} bytes on wire ({2} bits)",
                                packetid, len, len * 8);
            frameNode.Nodes.Add(string.Format("Arrival Time: {0}", localTime));
            frameNode.Nodes.Add(string.Format("Epoch Time: {0} seconds", epochTime));
            frameNode.Nodes.Add(string.Format("Frame Number: {0}", packetid));
            frameNode.Nodes.Add(string.Format("Frame Length: {0} bytes", len));
            tree.Nodes.Add(frameNode);

            packet = Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            switch (rawPacket.LinkLayerType)
            {
                case LinkLayers.Ethernet:
                    Ethernet(packet);
                    break;
                default:
                    break;
            }
        }


        #region 数据链路层
        TreeNode EthernetNode;

        private void Ethernet(Packet packet)
        {
            EthernetPacket e = (EthernetPacket)packet.Extract(typeof(EthernetPacket)); //EthernetPacket.GetEncapsulated(packet);
            if (EthernetNode == null)
            {
                EthernetNode = new TreeNode();
            }

            EthernetNode.Nodes.Clear();

            string dstAddress = e.DestinationHwAddress.ToString();
            string srcAddress = e.SourceHwAddress.ToString();

            EthernetNode.Text = string.Format("Ethernet II, Src: {0}, Dst: {1}", srcAddress, dstAddress);
            EthernetNode.Nodes.Add(string.Format("Destination: {0}", UtilTool.HWAddressFormat(e.DestinationHwAddress.ToString())));
            EthernetNode.Nodes.Add(string.Format("Source: {0}", UtilTool.HWAddressFormat(e.SourceHwAddress.ToString())));
            EthernetNode.Nodes.Add(string.Format("Type: {0}", e.Type));
            tree.Nodes.Add(EthernetNode);

            switch (e.Type)
            {
                case EthernetPacketType.Arp: // ARP协议
                    ARPPacket arp = (ARPPacket)e.Extract(typeof(ARPPacket));
                    Arp(arp);
                    break;
                case EthernetPacketType.IpV4: // IP协议
                case EthernetPacketType.IpV6:
                    IpPacket ip = (IpPacket)e.Extract(typeof(IpPacket));
                    Ip(ip);
                    break;
                case EthernetPacketType.Loop: // 本地回环
                    break;
                case EthernetPacketType.None: // 无可用协议
                default:
                    break;
            }
        }

        #endregion

        #region 网络层

        // ARP 协议
        TreeNode ArpNode;

        private void Arp(ARPPacket arp)
        {
            if (ArpNode == null)
            {
                ArpNode = new TreeNode();
            }
            ArpNode.Nodes.Clear();

            ArpNode.Text = string.Format("Address Resolution Protocol ({0})", arp.Operation);
            ArpNode.Nodes.Add(string.Format("Hardware type: {0}", arp.HardwareAddressType));
            ArpNode.Nodes.Add(string.Format("Protocol type: {0}", arp.ProtocolAddressType));
            ArpNode.Nodes.Add(string.Format("Hardware size: {0}", arp.HardwareAddressLength));
            ArpNode.Nodes.Add(string.Format("Protocol size: {0}", arp.ProtocolAddressLength));
            ArpNode.Nodes.Add(string.Format("Opcode: {0}", arp.Operation));
            ArpNode.Nodes.Add(string.Format("Sender MAC address: {0}", arp.SenderHardwareAddress));
            ArpNode.Nodes.Add(string.Format("Sender IP address: {0}", arp.SenderProtocolAddress));
            ArpNode.Nodes.Add(string.Format("Target MAC address: {0}", arp.TargetHardwareAddress));
            ArpNode.Nodes.Add(string.Format("Target Ip address: {0}", arp.TargetProtocolAddress));
            tree.Nodes.Add(ArpNode);
        }

        // IP 协议

        private void Ip(IpPacket ip)
        {
            if (ip.Version == IpVersion.IPv4)
            {
                IPv4Packet ipv4 = ip as IPv4Packet;
                IPv4(ipv4);
            }
            else
            {
                IPv6Packet ipv6 = ip as IPv6Packet;
                IPv6(ipv6);
            }
            ipNext(ip);
        }

        private void ipNext(IpPacket ip)
        {
            switch (ip.NextHeader)
            {
                case IPProtocolType.TCP:
                    TcpPacket tcp = (TcpPacket)ip.Extract(typeof(TcpPacket));
                    TCP(tcp);
                    break;
                case IPProtocolType.UDP:
                    UdpPacket udp = (UdpPacket)ip.Extract(typeof(UdpPacket));
                    UDP(udp);
                    break;
                case IPProtocolType.ICMP:
                    ICMPv4Packet icmp = (ICMPv4Packet)ip.Extract(typeof(ICMPv4Packet));
                    ICMP(icmp);
                    break;
                case IPProtocolType.ICMPV6:
                    ICMPv6Packet icmpv6 = (ICMPv6Packet)ip.Extract(typeof(ICMPv6Packet));
                    ICMPv6(icmpv6);
                    break;
                case IPProtocolType.IGMP:
                    break;
                default:
                    break;
            }
        }

        // IPv4
        TreeNode IPv4Node;

        private void IPv4(IPv4Packet v4)
        {
            if (IPv4Node == null)
            {
                IPv4Node = new TreeNode();
            }

            IPv4Node.Nodes.Clear();

            IPv4Node.Text = string.Format("Internet Protocol Version 4, Src: {0}, Dst: {1}", 
                                        v4.SourceAddress, v4.DestinationAddress);
            IPv4Node.Nodes.Add(string.Format("Version: {0}", v4.Version));
            IPv4Node.Nodes.Add(string.Format("Header Length: {0} bytes", v4.HeaderLength));
            IPv4Node.Nodes.Add(string.Format("Differentiated Services Field: {0}", v4.TypeOfService));
            IPv4Node.Nodes.Add(string.Format("Total Length: {0}", v4.TotalLength));
            IPv4Node.Nodes.Add(string.Format("Identification: {0}", v4.Id));
            IPv4Node.Nodes.Add(string.Format("Flags: {0}", v4.FragmentFlags));
            IPv4Node.Nodes.Add(string.Format("Fragment offset: {0}", v4.FragmentOffset));
            IPv4Node.Nodes.Add(string.Format("Time to live: {0}", v4.TimeToLive));
            IPv4Node.Nodes.Add(string.Format("Protocol: {0}", v4.Protocol));
            IPv4Node.Nodes.Add(string.Format("Header checksum: {0}", v4.Checksum));
            IPv4Node.Nodes.Add(string.Format("Source: {0}", v4.SourceAddress));
            IPv4Node.Nodes.Add(string.Format("Destination: {0}", v4.DestinationAddress));

            tree.Nodes.Add(IPv4Node);
        }

        // IPv6
        TreeNode IPv6Node;

        private void IPv6(IPv6Packet v6)
        {
            if (IPv6Node == null)
            {
                IPv6Node = new TreeNode();
            }

            IPv6Node.Nodes.Clear();
            IPv6Node.Text = string.Format("Internet Protocol Version 6, Src: {0}, Dst: {1}",
                                v6.SourceAddress, v6.DestinationAddress);
            IPv6Node.Nodes.Add(string.Format("Version: {0}", v6.Version));
            IPv6Node.Nodes.Add(string.Format("Payload length: {0}", v6.PayloadLength));
            IPv6Node.Nodes.Add(string.Format("Next header: {0}", v6.NextHeader));
            IPv6Node.Nodes.Add(string.Format("Hot limit: {0}", v6.HopLimit));
            IPv6Node.Nodes.Add(string.Format("Source: {0}", v6.SourceAddress));
            IPv6Node.Nodes.Add(string.Format("Destination: {0}", v6.DestinationAddress));

            tree.Nodes.Add(IPv6Node);
        }

        // ICMPv4
        TreeNode ICMPv4Node;

        private void ICMP(ICMPv4Packet icmp)
        {
            if (ICMPv4Node == null)
            {
                ICMPv4Node = new TreeNode();
            }
            ICMPv4Node.Nodes.Clear();
            ICMPv4Node.Text = string.Format("Internet Control Message Protocol v4");
            ICMPv4Node.Nodes.Add(string.Format("Type/Code: {0}", icmp.TypeCode));
            ICMPv4Node.Nodes.Add(string.Format("Sequence Number: {0}", icmp.Sequence));
            ICMPv4Node.Nodes.Add(string.Format("Identification: {0}", icmp.ID));
            ICMPv4Node.Nodes.Add(string.Format("Checksum: {0}", icmp.Checksum));
            //ICMPv6Node.Nodes.Add(string.Format(""));
            //ICMPv6Node.Nodes.Add(string.Format(""));
            tree.Nodes.Add(ICMPv4Node);

        }

        // ICMPv6
        TreeNode ICMPv6Node;

        private void ICMPv6(ICMPv6Packet icmpv6)
        {
            if (ICMPv6Node == null)
            {
                ICMPv6Node = new TreeNode();
            }
            ICMPv6Node.Nodes.Clear();
            ICMPv6Node.Text = string.Format("Internet Control Message Protocol v6");
            ICMPv6Node.Nodes.Add(string.Format("Type: {0}", icmpv6.Type));
            ICMPv6Node.Nodes.Add(string.Format("Code: {0}", icmpv6.Code));
            ICMPv6Node.Nodes.Add(string.Format("Checksum: {0}", icmpv6.Checksum));
            //ICMPv6Node.Nodes.Add(string.Format(""));
            //ICMPv6Node.Nodes.Add(string.Format(""));
            tree.Nodes.Add(ICMPv6Node);
        }

        #endregion

        #region 传输层
        // UDP 协议
        TreeNode UDPNode;

        private void UDP(UdpPacket udp)
        {
            if (UDPNode == null)
            {
                UDPNode = new TreeNode();
            }
            UDPNode.Nodes.Clear();
            UDPNode.Text = string.Format("User Datagram Protocol, Src Port: {0}, Dst Port: {1}",
                                             udp.SourcePort, udp.DestinationPort);
            UDPNode.Nodes.Add(string.Format("Source Port: {0}", udp.SourcePort));
            UDPNode.Nodes.Add(string.Format("Destination Port: {0}", udp.DestinationPort));
            UDPNode.Nodes.Add(string.Format("Length: {0}", udp.Length));
            UDPNode.Nodes.Add(string.Format("Checksum: {0}", udp.Checksum));
            tree.Nodes.Add(UDPNode);
        }

        // TCP 协议
        TreeNode TCPNode;

        private void TCP(TcpPacket tcp)
        {
            if (TCPNode == null)
            {
                TCPNode = new TreeNode();
            }
            TCPNode.Nodes.Clear();
            TCPNode.Text = string.Format("Transmission Control Protocol, Src Port: {0}, Dst Port: {1}, Seq: {2}, Ack: {3}", 
                                            tcp.SourcePort, tcp.DestinationPort, tcp.SequenceNumber, tcp.Ack);
            TCPNode.Nodes.Add(string.Format("Source Port: {0}", tcp.SourcePort));
            TCPNode.Nodes.Add(string.Format("Destination Port: {0}", tcp.DestinationPort));
            TCPNode.Nodes.Add(string.Format("Sequence number: {0}", tcp.SequenceNumber));
            TCPNode.Nodes.Add(string.Format("Acknowledgement number: {0}", tcp.SequenceNumber));
            TCPNode.Nodes.Add(string.Format("Header Length: {0} bytes", tcp.Header.Length));
            TCPNode.Nodes.Add(string.Format("Flags: {0}", tcp.AllFlags.ToString("X")));
            TCPNode.Nodes.Add(string.Format("Window size value: {0}", tcp.WindowSize));
            TCPNode.Nodes.Add(string.Format("Checksum: {0}", tcp.Checksum));
            TCPNode.Nodes.Add(string.Format("Urgent pointer: {0}", tcp.UrgentPointer));
            //TCPNode.Nodes.Add(string.Format(""));
            //TCPNode.Nodes.Add(string.Format(""));
            tree.Nodes.Add(TCPNode);
            appNext(tcp.PayloadData, tcp.SourcePort, tcp.DestinationPort);
        }

        #endregion

        #region 应用层
        ushort AppSrcPort;
        ushort AppDstPort;

        private void appNext(byte[] payloadData, ushort srcPort, ushort dstPort)
        {
            if (payloadData.Length == 0)
            {
                return;
            }

            AppSrcPort = srcPort;
            AppDstPort = dstPort;

            if (isAnalysProtocol(80))
            {
                HttpPacket http = new HttpPacket(payloadData);
                HTTP(http);
            }
            else if (isAnalysProtocol(21))
            {
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
        TreeNode HTTPNode;

        private void HTTP(HttpPacket http)
        {
            if (http == null)
                return;
            if (HTTPNode == null)
            {
                HTTPNode = new TreeNode();
            }

            HTTPNode.Nodes.Clear();

            HTTPNode.Text = string.Format("Hypertext Transfer Protocol (HTTP)");

            List<CommandTypeHead> httplist = http.CreatHeadList();
            if (httplist.Count == 0)
                return;
            setAppTreeNode(httplist, HTTPNode);
        }

        // FTP 协议
        TreeNode FTPNode;

        private void FTP(FtpPacket ftp)
        {
            if (ftp == null)
                return;
            if (FTPNode == null)
            {
                FTPNode = new TreeNode();
            }

            FTPNode.Nodes.Clear();

            FTPNode.Text = string.Format("File Transfer Protocol (FTP)");
            List<CommandTypeHead> ftplist = ftp.CreatHeadList();
            if (ftplist.Count == 0)
                return;
            setAppTreeNode(ftplist, HTTPNode);
        }

        private void setAppTreeNode(List<CommandTypeHead> list, TreeNode node)
        {
            foreach (var i in list)
            {
                string tmpStr = i.Content;
                foreach (var j in replaceCharArry)
                {
                    tmpStr = tmpStr.Replace(j, '.');
                }
                node.Nodes.Add(tmpStr);
            }
            tree.Nodes.Add(node);
        }

        #endregion
    }
}
