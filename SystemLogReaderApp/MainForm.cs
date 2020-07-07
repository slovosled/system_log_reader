using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemLogReaderApp.model;
using SystemLogReaderApp.parser;
using SystemLogReaderApp.repository;
using SystemLogReaderApp.viewmodel;

namespace SystemLogReaderApp
{
    public partial class MainForm : Form
    {

        private readonly OpenFileDialog openFileDialog;
        private readonly SystemLogViewModel viewModel;
        private readonly DataTable table;

        public MainForm()
        {
            InitializeComponent();

            //Initialize openFile dialog
            openFileDialog = new OpenFileDialog()
            {
                Title = "Select Log File",
                Filter = "log files (*.log)|*.log",
            };

            // Initialize viewmodel / repository / parser
            FileLogParser<SystemLogMessage> parser = new CsvSystemLogFileParser();
            SystemLogRepository repository = new SystemLogRepository(parser);
            viewModel = new SystemLogViewModel(repository);

            // Initialize DataTable
            table = new DataTable();
            table.Columns.Add("No");
            table.Columns.Add("Type");
            table.Columns.Add("Category");
            table.Columns.Add("Date");
            table.Columns.Add("Message");
            systemLogView.DataSource = table;



        }

       

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<SystemLogMessage> logs = viewModel.ExtractFileLogMessages(openFileDialog.FileName);
                updateGridView(logs);
            }
        }

        private void extractFilecsvToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateGridView(List<SystemLogMessage> logs)
        {
            table.Clear();
            systemLogView.DataSource = table;
        }
    }
}
