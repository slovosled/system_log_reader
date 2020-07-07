using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLogReaderApp.model;
using SystemLogReaderApp.parser;

namespace SystemLogReaderApp.repository
{
    class SystemLogRepository
    {
        private readonly FileLogParser<SystemLogMessage> parser;

        public SystemLogRepository(FileLogParser<SystemLogMessage> parser)
        {
            this.parser = parser;
        }

        public List<SystemLogMessage> GetLogMessages(string fileAbsolutePath)
        {
            return parser.Parse(fileAbsolutePath);
        }

        public bool SaveFileStatistics()
        {
            throw new NotImplementedException();
        }

    }
}
