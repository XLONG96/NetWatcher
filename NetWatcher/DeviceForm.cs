using SharpPcap;
using SharpPcap.WinPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetWatcher
{
    public partial class DeviceForm : Form
    {
        private MainForm form;
        //private ICaptureDevice device;
        private CaptureDeviceList devices;

        public DeviceForm(MainForm form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
            try
            {
                devices = UtilTool.searchDevice();
                if (devices == null)
                {
                    throw new Exception("No devices in this computor!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            
            foreach (ICaptureDevice dev in devices)
            {
                listBox1.Items.Add(dev.Description);
                //listBox1.Items.Add(dev.Name);
                //listBox1.Items.Add(dev.MacAddress);
                //listBox1.Items.Add(dev.LinkType);
                //listBox1.Items.Add(" ");
            }

            listBox1.SelectedIndex = 0;
            form.setDevice(devices[0]);
        }
        
        public ICaptureDevice getDevice()
        {
            return CaptureDeviceList.Instance[listBox1.SelectedIndex];
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            form.setButtonStartPress();
            form.setDevice(devices[index]);
            form.restartCapture();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            startButton.PerformClick();
        }
    }
}
