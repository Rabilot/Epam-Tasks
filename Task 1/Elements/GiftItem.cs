using System.Text;

namespace Task_1.Elements
{
    public class GiftItem
    {
        public double Price{ get; }
        public double Weight{ get; }
        public string Name{ get; }
        public string Manufacturer{ get; }
        private readonly StringBuilder _stringBuilder;

        protected GiftItem(double price, double weight, string name, string manufacturer)
        {
            Price = price;
            Weight = weight;
            Name = name;
            Manufacturer = manufacturer;
            _stringBuilder = new StringBuilder();
        }

        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine("Product: ");
            _stringBuilder.AppendLine(
                $"Name: {Name}\nManufacturer: {Manufacturer}\nWeight: " + 
                $"{Weight}\nPrice: {Price}");
            return _stringBuilder.ToString();
        }
    }
}