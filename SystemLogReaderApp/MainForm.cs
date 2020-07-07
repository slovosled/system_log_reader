using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemLogReaderApp
{
    public partial class MainForm : Form
    {

        private readonly OpenFileDialog openFileDialog;

        public MainForm()
        {
            InitializeComponent();

            //Initialize openFile dialog
            openFileDialog = new OpenFileDialog()
            {
                Title = "Select Log File",
                Filter = "log files (*.log)|*.log",
            };
            
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Clicked");
            }
        }

        private void extractFilecsvToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
