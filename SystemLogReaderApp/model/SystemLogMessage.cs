using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogReaderApp.model
{
    class SystemLogMessage
    {
        public string MessageType { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public List<string> Tags { get; set; }
        public string Message { get; set; }
    }



}
