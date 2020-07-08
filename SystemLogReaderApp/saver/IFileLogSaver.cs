using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLogReaderApp.model
{
    interface IFileLogSaver<TYPE>
    {
        bool SaveFile(List<TYPE> logs, string fileNameAbsolutePath);
    }

}
