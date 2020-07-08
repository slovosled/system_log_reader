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
        private readonly FileLogParser<SystemLog> parser;
        private readonly IFileLogSaver<SystemLog> fileSaver;
    
        public SystemLogRepository(FileLogParser<SystemLog> parser, IFileLogSaver<SystemLog> fileSaver)
        {
            this.parser = parser;
            this.fileSaver = fileSaver;
        }

        public List<SystemLog> GetLogMessages(string fileAbsolutePath)
        {
            return parser.Parse(fileAbsolutePath);
        }

        public bool SaveFileStatistics(List<SystemLog> logMessages,string absoluteFileNamePath)
        {
            return fileSaver.SaveFile(logMessages, absoluteFileNamePath);
        }

    }
}
