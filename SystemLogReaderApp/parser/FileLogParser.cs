using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogReaderApp.parser
{
    abstract class FileLogParser<TYPE>
    {

        public List<TYPE> Parse(string fileAbsolutePath)
        {
            List<TYPE> logs = new List<TYPE>();

            try
            {
                using (FileStream fs = File.Open(fileAbsolutePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            
                            TYPE log = ParseFileLine(line);
                            if (log == null)
                                continue;
                            logs.Add(log);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", DateTime.Now.ToString() + ":" + ex.ToString() + "\n");
                throw ex;
            }

            return logs;
        }

        protected abstract TYPE ParseFileLine(string line);

    }
}
