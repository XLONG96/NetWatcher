using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.WinPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetWatcher
{
    public partial class MainForm : Form
    {
        private DeviceForm deviceform;
        private LoadingForm loadingform;
        private PacketTreeForm treeform;
        private ICaptureDevice device;
        private List<RawCapture> bufferList;
        private List<RawCapture> packetList;
        private object threadLock = new object();
        private Boolean isStartAnalyzer = true;
        private PacketGridViewInfo gridViewInfo;
        private Thread loadThread;
        private Thread analyzeThread;
        private PacketTreeInfo treeInfo;
        private uint packetid;
        delegate void DataGridRowsShowHandler(RawCapture packet);
        private string rule = "";

        public MainForm()
        {
            loadingform = new LoadingForm();        
            
            Thread loadformThread = new Thread(new ThreadStart(runLoadForm));
            loadformThread.Start();

            loadThread = new Thread(new ThreadStart(loadNetAdapter));
            loadThread.IsBackground = true;
            loadThread.Start();
            
            try
            {
                loadThread.Join();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Device Load fail!" + "\n" + ex.ToString());
            }

            loadformThread.Abort();
            InitializeComponent();
        }

        public void runLoadForm()
        {
            Application.Run(loadingform);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridViewInfo = new PacketGridViewInfo(this.sourceView);
            bufferList = new List<RawCapture>();
            packetList = new List<RawCapture>();
            treeInfo = new PacketTreeInfo(this.treeView1);  
        }

        private void loadNetAdapter()
        {
            UtilTool.searchDevice();
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deviceform = new DeviceForm(this);
            deviceform.Show();         
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            setButtonStartPress();
            try
            {
                isStartAnalyzer = true;
                deviceStartCapture();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            //richTextBox1.Clear();
            //richTextBox1.AppendText(device.ToString());
        }

        public void restartCapture()
        {
            // 停止之前的所有捕捉线程并清空GridView
            stopCapture();
            sourceView.Rows.Clear();
            if (packetList != null)
                packetList.Clear();
            if (bufferList != null)
                bufferList.Clear();
            packetid = 0;
            isStartAnalyzer = true;

            deviceStartCapture();
        }

        private void deviceStartCapture()
        {
            if (device == null)
            {
                MessageBox.Show("请先选择网络设备！");
                return;
            }

            // 开启分析线程
            analyzeThread = new Thread(new ThreadStart(analyzeAndAppendData));
            analyzeThread.IsBackground = true;
            analyzeThread.Start();

            // 注册包到达事件处理句柄
            device.OnPacketArrival +=
                new SharpPcap.PacketArrivalEventHandler(device_OnPacketArrival);

            // 设置读超时时间，在此时间内如果没有收到包则停止捕获
            int readTimeoutMilliseconds = 1000;
            // 当DeviceMode被设为Normal模式时，只捕捉以本地为源或目的的报文
            // 设为Promiscuous（混杂）模式时，捕捉以流过网卡的报文
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            // 非阻塞，在另一个线程上开始捕获
            device.StartCapture();

            /*
            while ((rawPacket = device.GetNextPacket()) != null)
            {
                if (index == 1000 || isStoped)
                {
                    break;
                }

                bufferList.Add(rawPacket);
                sourceView.Rows.Add(gridViewInfo.getRowByRawPacket(rawPacket, index));

                index++;
            }

            device.Close();
            */
        }

        // 数据包到达的处理句柄
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            lock (threadLock)
            {
                bufferList.Add(e.Packet);

                if (packetid > 100000)
                {
                    stopButton.PerformClick();
                }
            }
        }

        // 分析数据包和添加数据到GridView
        private void analyzeAndAppendData()
        {
            while (isStartAnalyzer)
            {
                while (bufferList.Count > 0)
                {
                    List<RawCapture> tmpPacketList;
                    lock (threadLock)
                    {
                        tmpPacketList = bufferList;
                        bufferList = new List<RawCapture>();
                        packetList.AddRange(tmpPacketList);
                    }
                    // 委托调用主窗口体的控件
                    foreach(var i in tmpPacketList)
                    {
                        this.Invoke(new DataGridRowsShowHandler(showDataRows), i);
                    }
                }
            }
        }

        private void showDataRows(RawCapture packet)
        {
            try
            {
                gridViewInfo.setPacketGridView(packet, ++packetid, rule);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            //sourceView.Rows.Add(gridViewInfo.getRowByRawPacket(packet, ++packetid));
        }

        // 停止捕获
        public void stopCapture()
        {
            if (device != null && device.Started)
            {
                device.StopCapture();
                device.Close();

                isStartAnalyzer = false;

                if (analyzeThread != null && analyzeThread.IsAlive)
                {
                    analyzeThread.Abort();
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            setButtonStopPress();
            stopCapture();
        }

        // 主窗口退出，关闭所有抓包线程
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopCapture();
        }

        public void setDevice(ICaptureDevice device)
        {
            this.device = device;
        }

        private void sourceView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            // 右击也选中
            if (e.Button == MouseButtons.Right)
            {
                sourceView.Rows[e.RowIndex].Selected = true;
            }
            selectDataGridRow(e.RowIndex);
        }


        private void sourceView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            selectDataGridRow(e.RowIndex);
            treeform = new PacketTreeForm(treeView1, richTextBox1);
            treeform.Show();
        }

        private void selectDataGridRow(int index)
        {
            if (index < 0 || index > sourceView.Rows.Count)
                return;
            //获取数据包位置
            int i = Convert.ToInt32(sourceView.Rows[index].Cells[0].Value.ToString());
            if (i > packetList.Count)
                return;

            RawCapture rawPacket = packetList[i - 1];

            treeView1.Nodes.Clear();
            treeInfo.setProtcolTree(rawPacket, (uint)i);

            richTextBox1.Text = UtilTool.convertToHexText(rawPacket.Data);
        }

        private void ruleComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Enter
            if (e.KeyChar == 13)
            {
                rule = ruleComboBox1.Text;
                /*
                foreach (string str in ruleComboBox1.Items)
                {
                    if (str == rule)
                    {
                        ruleComboBox1.Items.Remove(str);
                    }
                }
                ruleComboBox1.Text = rule;
                if (rule != "")
                {
                    ruleComboBox1.Items.Insert(0, rule); // Save history
                }*/
                

                lock (threadLock)
                {
                    uint id = 0;
                    sourceView.Rows.Clear();
                    foreach (var p in packetList)
                    {
                        gridViewInfo.setPacketGridView(p, ++id, rule);
                    }
                }
            }
        }

        private void ruleDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ruleComboBox1.Text = e.ClickedItem.Text;
        }

        private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setButtonStartPress();
            try
            {
                isStartAnalyzer = true;
                deviceStartCapture();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void setButtonStartPress()
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
        }

        public void setButtonStopPress()
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void clearAll()
        {
            sourceView.Rows.Clear();
            treeView1.Nodes.Clear();
            richTextBox1.Text = "";
            if (packetList != null)
                packetList.Clear();
            if (bufferList != null)
                bufferList.Clear();
            packetid = 0;
            isStartAnalyzer = true;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "pcap文件|*.pcap";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                stopCapture();
                clearAll();

                ICaptureDevice offDev = new SharpPcap.LibPcap.CaptureFileReaderDevice(ofd.FileName);
                RawCapture tempPacket;
                offDev.Open();

                while ((tempPacket = offDev.GetNextPacket()) != null)
                {
                    packetList.Add(tempPacket);
                    showDataRows(tempPacket);
                }
                offDev.Close();
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pcap文件|*.pcap";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var offDev = new SharpPcap.LibPcap.CaptureFileWriterDevice(sfd.FileName);
                foreach (var i in packetList)
                {
                    offDev.Write(i);
                }

                MessageBox.Show("文件保存成功", "提示", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }
    }
}
