using System.Collections.Generic;

namespace Task4.BL
{
    public interface IParser
    {
        IEnumerable<CsvObject> FileParse(string path);
    }
}