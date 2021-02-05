using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using IReader = Task4.BL.Interfaces.IReader;

namespace Task4.BL.Csv_Handling
{
    public class Reader : IReader
    {
        public IEnumerable<CsvObject> ReadFile(string path)
        {
            if (Path.GetExtension(path) != ".csv")
            {
                throw new TypeLoadException("Invalid file type");
            }

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