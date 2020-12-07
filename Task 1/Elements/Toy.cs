using System.Text;

namespace Task_1.Elements
{
    public class Toy : GiftItem
    {
        public string Material { get; }

        public Toy(
            double price, 
            double weight, 
            string name, 
            string manufacturer, 
            string material
            ) : base(price, weight, name, manufacturer)
        {
            Material = material;
        }

        public override string ToString()
        {
            var info = base.ToString();
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n{info}");
            stringBuilder.Append($"Material: {Material}");
            return stringBuilder.ToString();
        }
    }
}