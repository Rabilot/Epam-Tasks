using System.Text;

namespace Task_1
{
    public class GiftItem
    {
        public double Price{ get; }
        public double Weight{ get; }
        public string Name{ get; }
        public string Manufacturer{ get; }

        protected GiftItem(double price, double weight, string name, string manufacturer)
        {
            Price = price;
            Weight = weight;
            Name = name;
            Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Product: \n");
            stringBuilder.Append(
                $"Name: {Name}\nManufacturer: {Manufacturer}\nWeight: " + 
                $"{Weight}\nPrice: {Price}\n");
            return stringBuilder.ToString();
        }
    }
}