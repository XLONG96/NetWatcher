namespace NetWatcher
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.捕获ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ruleDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.iPv4OnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPv6OnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aRPOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iCMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tCPPort80ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uDPUdpPort80ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPv4IpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTTPHttpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruleComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.sourceView = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.捕获ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(787, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 捕获ToolStripMenuItem
            // 
            this.捕获ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选项ToolStripMenuItem,
            this.开始ToolStripMenuItem});
            this.捕获ToolStripMenuItem.Name = "捕获ToolStripMenuItem";
            this.捕获ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.捕获ToolStripMenuItem.Text = "捕获";
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.选项ToolStripMenuItem.Text = "选项";
            this.选项ToolStripMenuItem.Click += new System.EventHandler(this.选项ToolStripMenuItem_Click);
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.开始ToolStripMenuItem.Text = "开始";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.toolStripSeparator2,
            this.stopButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.ruleDropDownButton1,
            this.ruleComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(787, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(23, 22);
            this.startButton.Text = "开始捕获";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 22);
            this.stopButton.Text = "停止捕获";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "过滤规则";
            // 
            // ruleDropDownButton1
            // 
            this.ruleDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ruleDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPv4OnlyToolStripMenuItem,
            this.iPv6OnlyToolStripMenuItem,
            this.aRPOnlyToolStripMenuItem,
            this.iCMPToolStripMenuItem,
            this.tCPToolStripMenuItem,
            this.tCPPort80ToolStripMenuItem,
            this.uDPToolStripMenuItem,
            this.uDPUdpPort80ToolStripMenuItem,
            this.iPv4IpToolStripMenuItem,
            this.hTTPHttpToolStripMenuItem,
            this.hTTPToolStripMenuItem});
            this.ruleDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("ruleDropDownButton1.Image")));
            this.ruleDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ruleDropDownButton1.Name = "ruleDropDownButton1";
            this.ruleDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.ruleDropDownButton1.Text = "过滤规则";
            this.ruleDropDownButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ruleDropDownButton1_DropDownItemClicked);
            // 
            // iPv4OnlyToolStripMenuItem
            // 
            this.iPv4OnlyToolStripMenuItem.Name = "iPv4OnlyToolStripMenuItem";
            this.iPv4OnlyToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.iPv4OnlyToolStripMenuItem.Text = "IPv4";
            // 
            // iPv6OnlyToolStripMenuItem
            // 
            this.iPv6OnlyToolStripMenuItem.Name = "iPv6OnlyToolStripMenuItem";
            this.iPv6OnlyToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.iPv6OnlyToolStripMenuItem.Text = "IPv6";
            // 
            // aRPOnlyToolStripMenuItem
            // 
            this.aRPOnlyToolStripMenuItem.Name = "aRPOnlyToolStripMenuItem";
            this.aRPOnlyToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.aRPOnlyToolStripMenuItem.Text = "ARP";
            // 
            // iCMPToolStripMenuItem
            // 
            this.iCMPToolStripMenuItem.Name = "iCMPToolStripMenuItem";
            this.iCMPToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.iCMPToolStripMenuItem.Text = "ICMPv6";
            // 
            // tCPToolStripMenuItem
            // 
            this.tCPToolStripMenuItem.Name = "tCPToolStripMenuItem";
            this.tCPToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.tCPToolStripMenuItem.Text = "TCP";
            // 
            // tCPPort80ToolStripMenuItem
            // 
            this.tCPPort80ToolStripMenuItem.Name = "tCPPort80ToolStripMenuItem";
            this.tCPPort80ToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.tCPPort80ToolStripMenuItem.Text = "TCP && tcp.port==80";
            // 
            // uDPToolStripMenuItem
            // 
            this.uDPToolStripMenuItem.Name = "uDPToolStripMenuItem";
            this.uDPToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.uDPToolStripMenuItem.Text = "UDP";
            // 
            // uDPUdpPort80ToolStripMenuItem
            // 
            this.uDPUdpPort80ToolStripMenuItem.Name = "uDPUdpPort80ToolStripMenuItem";
            this.uDPUdpPort80ToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.uDPUdpPort80ToolStripMenuItem.Text = "UDP && udp.port==80";
            // 
            // iPv4IpToolStripMenuItem
            // 
            this.iPv4IpToolStripMenuItem.Name = "iPv4IpToolStripMenuItem";
            this.iPv4IpToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.iPv4IpToolStripMenuItem.Text = "IPv4 && ip.addr==192.168.1.0";
            // 
            // hTTPHttpToolStripMenuItem
            // 
            this.hTTPHttpToolStripMenuItem.Name = "hTTPHttpToolStripMenuItem";
            this.hTTPHttpToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.hTTPHttpToolStripMenuItem.Text = "FTP";
            // 
            // hTTPToolStripMenuItem
            // 
            this.hTTPToolStripMenuItem.Name = "hTTPToolStripMenuItem";
            this.hTTPToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.hTTPToolStripMenuItem.Text = "HTTP";
            // 
            // ruleComboBox1
            // 
            this.ruleComboBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ruleComboBox1.MaxDropDownItems = 20;
            this.ruleComboBox1.Name = "ruleComboBox1";
            this.ruleComboBox1.Size = new System.Drawing.Size(500, 25);
            this.ruleComboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ruleComboBox1_KeyPress);
            // 
            // sourceView
            // 
            this.sourceView.AllowUserToAddRows = false;
            this.sourceView.AllowUserToDeleteRows = false;
            this.sourceView.AllowUserToResizeColumns = false;
            this.sourceView.AllowUserToResizeRows = false;
            this.sourceView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sourceView.BackgroundColor = System.Drawing.Color.Black;
            this.sourceView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sourceView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Time,
            this.Source,
            this.Destination,
            this.Protocol,
            this.Length,
            this.Info});
            this.sourceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceView.GridColor = System.Drawing.Color.Black;
            this.sourceView.Location = new System.Drawing.Point(0, 0);
            this.sourceView.Name = "sourceView";
            this.sourceView.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.sourceView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.sourceView.RowTemplate.Height = 23;
            this.sourceView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sourceView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sourceView.Size = new System.Drawing.Size(787, 190);
            this.sourceView.TabIndex = 2;
            this.sourceView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sourceView_CellMouseDoubleClick);
            this.sourceView.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sourceView_CellMouseDown);
            // 
            // No
            // 
            this.No.FillWeight = 93.84027F;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            // 
            // Time
            // 
            this.Time.FillWeight = 85.04533F;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Source
            // 
            this.Source.FillWeight = 75.46184F;
            this.Source.HeaderText = "Source";
            this.Source.Name = "Source";
            // 
            // Destination
            // 
            this.Destination.FillWeight = 104.5931F;
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            // 
            // Protocol
            // 
            this.Protocol.FillWeight = 95.53474F;
            this.Protocol.HeaderText = "Protocol";
            this.Protocol.Name = "Protocol";
            // 
            // Length
            // 
            this.Length.FillWeight = 67.85974F;
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            // 
            // Info
            // 
            this.Info.FillWeight = 177.665F;
            this.Info.HeaderText = "Info";
            this.Info.Name = "Info";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(787, 380);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer2.Size = new System.Drawing.Size(787, 186);
            this.splitContainer2.SplitterDistance = 373;
            this.splitContainer2.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Black;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(373, 186);
            this.treeView1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(410, 186);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 430);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetWatcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.DataGridView sourceView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.ToolStripMenuItem 捕获ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox ruleComboBox1;
        private System.Windows.Forms.ToolStripDropDownButton ruleDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tCPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uDPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPv4OnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPv6OnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aRPOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPv4IpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTTPHttpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tCPPort80ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uDPUdpPort80ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iCMPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
    }
}

