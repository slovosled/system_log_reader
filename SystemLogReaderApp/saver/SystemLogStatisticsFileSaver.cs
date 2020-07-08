using System;
using System.Collections.Generic;
using System.IO;
using SystemLogReaderApp.utilities;

namespace SystemLogReaderApp.model
{
    class SystemLogStatisticsFileSaver : IFileLogSaver<SystemLog>
    {
        public bool SaveFile(List<SystemLog> data, string fileNameAbsolutePath)
        {
            List<string> lines = prepareFileLines(data);
            try
            {
                File.WriteAllLines(fileNameAbsolutePath, lines);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<string> prepareFileLines(List<SystemLog> data)
        {
            List<string> fileLines = new List<string>();
            Dictionary<string, int> types = SystemLogStatisticsUtility.ComputeTypesStatistics(data);
            Dictionary<string, int> categories = SystemLogStatisticsUtility.ComputeCategoriesStatistics(data);
            Dictionary<string, int> tags = SystemLogStatisticsUtility.ComputeTagsStatistics(data);

            fileLines.Add($"Files Total: {data.Count}");
            foreach (string key in types.Keys)
            {
                fileLines.Add($",{key}: {types[key]}");
            }
            fileLines.Add(" ");
            fileLines.Add($"Start time: {data[0].GetDateInStringFormat()}");
            fileLines.Add($"End time: {data[data.Count - 1].GetDateInStringFormat()}");
            fileLines.Add(" ");
            fileLines.Add($"Categories Total: {categories.Count}");
            foreach (string key in categories.Keys)
            {
                fileLines.Add($",{key}: {categories[key]}");
            }
            fileLines.Add(" ");
            fileLines.Add($"Tags Total: {tags.Count}");
            foreach (string key in tags.Keys)
            {
                fileLines.Add($",{key}: {tags[key]}");
            }

            return fileLines;
        }
    }
}
