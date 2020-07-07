using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

            const int minPartsOfLogs = 4;

            string[] splittedLine = line.Split(new char[] { ',' }, minPartsOfLogs);

            if (splittedLine.Length < minPartsOfLogs)
                return null;

            string messageType = splittedLine[0];
            string category = splittedLine[1];
            string date = splittedLine[2];
            string message = splittedLine[3];

            DateTime extractedDate = parseDate(date);
            if (extractedDate == DateTime.MinValue)
                return null;

            LogBag bag = parseMessage(message);


            SystemLogMessage logMessage = new SystemLogMessage();
            logMessage.MessageType = messageType;
            logMessage.Category = category;
            logMessage.Date = extractedDate;
            logMessage.Message = bag.Message;

            if(bag.Tags != null)
            {
                logMessage.Tags = bag.Tags.ToList();
            }

            return logMessage;


        }

        private LogBag parseMessage(string message)
        {
            LogBag bag = new LogBag();

            // Check if message contains tags
            if (message.Contains("@") && message.IndexOf("@") == 0)
            {
                //Split tags from log message
                string[] splittedMessage = message.Split(new char[] {' '});
                string potentialTags = splittedMessage[0];

                if (potentialTags.Contains(";"))
                {
                    string[] tags = potentialTags.Split(new char[] { ';' });
                    tags[0] = tags[0].Substring(1);
                    tags[tags.Length - 1] = tags[tags.Length - 1].Substring(0, tags[tags.Length - 1].IndexOf("#"));
                    bag.Tags = tags;
                }
                else
                {
                    potentialTags = potentialTags.Substring(1, potentialTags.IndexOf("#"));
                    bag.Tags = new string[] { potentialTags };
                }
                   
                bag.Message = splittedMessage[1];

            }
            else
            {
                bag.Message = message;
            }

            return bag;
            
        }

        private DateTime parseDate(string dateString)
        {
            try
            {
                //2020-02-12 02:32:04.422+08:00
                string[] entries = dateString.Split('-', ':', ' ', '.', '+');

                int year = Convert.ToInt32(entries[0]);
                int month = Convert.ToInt32(entries[1]);
                int day = Convert.ToInt32(entries[2]);
                int hour = Convert.ToInt32(entries[3]);
                int minute = Convert.ToInt32(entries[4]);
                int second = Convert.ToInt32(entries[5]);

                return new DateTime(year, month, day, hour, minute, second);
            }
            catch 
            {
                return DateTime.MinValue;
            }
        }

        private class LogBag
        {
            public string Message { get; set; }
            public string[] Tags { get; set; }
        }


    }
}
