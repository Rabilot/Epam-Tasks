using System.Text;

namespace Task_1.Elements
{
    public class Toy : GiftItem
    {
        public string Material { get; }
        private readonly StringBuilder _stringBuilder;
        public Toy(
            double price, 
            double weight, 
            string name, 
            string manufacturer, 
            string material
            ) : base(price, weight, name, manufacturer)
        {
            Material = material;
            _stringBuilder = new StringBuilder();
        }

        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine("\nThis toy:");
            _stringBuilder.AppendLine(base.ToString());
            _stringBuilder.AppendLine($"Material: {Material}");
            return _stringBuilder.ToString();
        }
    }
}