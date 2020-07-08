using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogReaderApp.model
{
    class SystemLog
    {
        public string MessageType { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string[] Tags { get; set; }
        public string Message { get; set; }

        public String GetDateInStringFormat()
        {
            if (Date == null)
                return null;

            return $"{Date.Year}/{zeroPrepand(Date.Month)}/{zeroPrepand(Date.Day)} {zeroPrepand(Date.Hour)}:{zeroPrepand(Date.Minute)}:{zeroPrepand(Date.Second)}";
        }

        private string zeroPrepand(int timPeriod)
        {
            return (timPeriod < 10) ? $"0{timPeriod}" : timPeriod.ToString();
        }
    }



}
