using CsvHelper.Configuration;

namespace Task4.BL
{
    public sealed class CsvObjectMap : ClassMap<CsvObject>
    {
        public CsvObjectMap()
        {
            Map(m => m.Id).Name("Column1");
            Map(m => m.OrderDate).Name("Column2");
            Map(m => m.ClientName).Name("Column3");
            Map(m => m.ProductName).Name("Column4");
            Map(m => m.Price).Name("Column5");
        }
    }
}