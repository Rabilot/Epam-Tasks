using System.Text;

namespace Task_1.GiftItem
{
    public class GiftItem
    {
        public double Price{ get; }
        public double Weight{ get; }
        public string Name{ get; }
        public string Manufacturer{ get; }

        protected GiftItem()
        {
            
        }

        protected GiftItem(double Price, double Weight, string Name, string Manufacturer)
        {
            this.Price = Price;
            this.Weight = Weight;
            this.Name = Name;
            this.Manufacturer = Manufacturer;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Product: \n");
            stringBuilder.Append(
                $"Name: {Name}\nManufacturer: {Manufacturer}\nWeight: " +
                $"Price: {Price}\nWeight: {Weight}\n");
            return stringBuilder.ToString();
        }
    }
}