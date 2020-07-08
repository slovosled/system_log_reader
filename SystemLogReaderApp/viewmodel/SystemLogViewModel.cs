using System;
using System.Collections.Generic;
using SystemLogReaderApp.model;
using SystemLogReaderApp.repository;

namespace SystemLogReaderApp.viewmodel
{
    class SystemLogViewModel
    {
        private readonly SystemLogRepository repository;
        private List<SystemLog> logMessages;

        public SystemLogViewModel(SystemLogRepository repository)
        {
            this.repository = repository;
        }

        public List<SystemLog> ExtractFileLogMessages(string fileAbsolutePath)
        {
            logMessages = null;
            logMessages =  repository.GetLogMessages(fileAbsolutePath);
            return logMessages;
        }

        public bool ProduceFileStatistics(string fileName)
        {
            if (ContainsLogData())
            {
                return repository.SaveFileStatistics(logMessages,fileName);
            }
            return false;
        }

        public bool ContainsLogData()
        {
            return logMessages != null;
        }

    }
}
