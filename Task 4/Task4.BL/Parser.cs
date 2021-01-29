using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace Task4.BL
{
    public class Parser : IParser
    {
        public List<CsvObject> FileParse(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<CsvObjectMap>();
                    return csvReader.GetRecords<CsvObject>().ToList();
                }
            }
        }

        private string GetManagerName(string path)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; path[i] != '_'; i++)
            {
                stringBuilder.Append(path[i]);
            }

            return stringBuilder.ToString();
        }
    }
}