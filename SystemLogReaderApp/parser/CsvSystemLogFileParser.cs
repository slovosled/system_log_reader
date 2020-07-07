using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLogReaderApp.model;

namespace SystemLogReaderApp.parser
{
    class CsvSystemLogFileParser : FileLogParser<SystemLogMessage>
    {
        protected override SystemLogMessage ParseFileLine(string line)
        {
            return null;
        }
    }
}
