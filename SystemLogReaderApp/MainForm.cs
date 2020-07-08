using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly SaveFileDialog saveFileDialog;
        private readonly SystemLogViewModel viewModel;

        public MainForm()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog()
            {
                Title = "Select Log File",
                Filter = "log files (*.log)|*.log",
            };

            saveFileDialog = new SaveFileDialog()
            {
                Title = "Save .csv File",
                Filter = "csv files (*.csv)| *.csv",
                AddExtension = true
            };

            // Initialize viewmodel / repository / parser / file saver
            FileLogParser<SystemLog> parser = new CsvSystemLogFileParser();
            IFileLogSaver<SystemLog> fileSaver = new SystemLogStatisticsFileSaver();
            SystemLogRepository repository = new SystemLogRepository(parser, fileSaver);
            viewModel = new SystemLogViewModel(repository);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<SystemLog> logs = viewModel.ExtractFileLogMessages(openFileDialog.FileName);
                updateGridView(logs);
            }
        }

        private void extractFilecsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!viewModel.ContainsLogData())
            {
                MessageBox.Show("No data are available for extraction!");
            }
            else
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    bool result = viewModel.ProduceFileStatistics(saveFileDialog.FileName);
                    string message = result ? " file successfully created!" : "Error occurred while creating .csv file!";
                    MessageBox.Show(message);
                }              
            }
        }

        private void updateGridView(List<SystemLog> logs)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("No");
            dataTable.Columns.Add("MessageType");
            dataTable.Columns.Add("Category");
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("Message");

            int index = 1;
            foreach (SystemLog log in logs)
            {
                dataTable.Rows.Add(new object[] { index, log.MessageType, log.Category, log.Date, log.Message });
                index++;
            }
            systemLogView.DataSource = dataTable;
            systemLogView.Refresh();
        }
    }
}
