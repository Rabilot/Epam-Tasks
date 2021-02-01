using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Task4.BL
{
    public class Parser : IParser
    {
        public IEnumerable<CsvObject> FileParse(string path)
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
    }
}