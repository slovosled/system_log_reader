using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLogReaderApp.model;

namespace SystemLogReaderApp.utilities
{
    class SystemLogStatisticsUtility
    {

        public static Dictionary<string, int> computeTypesStatistics(List<SystemLog> logs)
        {
            Dictionary<string, int> types = new Dictionary<string, int>();
            foreach (SystemLog log in logs)
            {
                if (types.ContainsKey(log.MessageType))
                {
                    types[log.MessageType] += 1;
                }
                else
                {
                    types.Add(log.MessageType, 1);
                }
            }
            return types;
        }

        public static Dictionary<string, int> computeTagsStatistics(List<SystemLog> logs)
        {
            Dictionary<string, int> tags = new Dictionary<string, int>();

            foreach (SystemLog log in logs)
            {
                if (log.Tags != null)
                {
                    foreach (string tag in log.Tags)
                    {
                        if (tags.ContainsKey(tag))
                        {
                            tags[tag] += 1;
                        }
                        else
                        {
                            tags[tag] = 1;
                        }
                    }
                }
            }
            return tags;
        }

        public static Dictionary<string, int> computeCategoriesStatistics(List<SystemLog> data)
        {
            Dictionary<string, int> categories = new Dictionary<string, int>();

            foreach (SystemLog message in data)
            {
                if (categories.ContainsKey(message.Category))
                {
                    categories[message.Category] += 1;
                }
                else
                {
                    categories.Add(message.Category, 1);
                }
            }

            return categories;
        }

    }
}
