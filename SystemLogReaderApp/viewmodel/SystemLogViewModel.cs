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

        public List<SystemLogMessage> ExtractFileLogMessages(string fileAbsolutePath)
        {
            return repository.GetLogMessages(fileAbsolutePath);
        }

        public bool SaveFileStatistics()
        {
            throw new NotImplementedException();
        }

    }
}
