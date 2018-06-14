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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            label1.Text = "正在注册...";
            progressBar1.Value = 0;
            Thread.Sleep(1000);
            label1.Text = "正在加载本地设备...";
            //progressBar1.Value = 99;
            
            for (int i = 0; i < 10; i++)//循环
            {
                System.Threading.Thread.Sleep(1000);//暂停1秒
                progressBar1.Value += progressBar1.Step; //让进度条增加一次
            }
        }
    }
}
