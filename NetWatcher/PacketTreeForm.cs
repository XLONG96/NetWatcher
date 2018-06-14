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
    public partial class PacketTreeForm : Form
    {
        public PacketTreeForm(TreeView treeview, RichTextBox textbox)
        {
            InitializeComponent();
            this.treeView1.Nodes.Clear();
            this.richTextBox1.Text = "";
            foreach (TreeNode t in treeview.Nodes)
            {
                treeView1.Nodes.Add(t.Clone() as TreeNode);
            }
            richTextBox1.Text = textbox.Text;
        }
    }
}
