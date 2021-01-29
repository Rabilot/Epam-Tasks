using System.Collections.Generic;

namespace Task4.BL
{
    public interface IParser
    {
        List<CsvObject> FileParse(string path);
    }
}