using System;
using System.Collections.Generic;
using SystemLogReaderApp.model;
using SystemLogReaderApp.repository;

namespace SystemLogReaderApp.viewmodel
{
    class SystemLogViewModel
    {
        private readonly SystemLogRepository repository;

        public SystemLogViewModel(SystemLogRepository repository)
        {
            this.repository = repository;
        }

        public List<SystemLogMessage> ExtractLogMessages(string fileNameAbsolutePath)
        {
            throw new NotImplementedException();
        }

        public bool SaveFileStatistics()
        {
            throw new NotImplementedException();
        }

    }
}
