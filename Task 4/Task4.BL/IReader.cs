using System.Collections.Generic;

namespace Task4.BL
{
    public interface IReader
    {
        IEnumerable<CsvObject> ReadFile(string path);
    }
}