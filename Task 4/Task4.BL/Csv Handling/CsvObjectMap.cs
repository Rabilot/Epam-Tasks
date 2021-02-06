using CsvHelper.Configuration;

namespace Task4.BL.Csv_Handling
{
    public sealed class CsvObjectMap : ClassMap<CsvObject>
    {
        public CsvObjectMap()
        {
            Map(m => m.OrderDate).Name("Date");
            Map(m => m.ClientName).Name("ClientName");
            Map(m => m.ProductName).Name("ProductName");
            Map(m => m.Price).Name("Price");
        }
    }
}