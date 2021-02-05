using System.Collections.Generic;
using Task4.BL.Csv_Handling;

namespace Task4.BL.Interfaces
{
    public interface IReader
    {
        IEnumerable<CsvObject> ReadFile(string path);
    }
}