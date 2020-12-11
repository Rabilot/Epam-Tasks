using System.Text;

namespace Task_1.Library.Elements
{
    public class Marshmallow : Sweetness
    {
        public ColorOfMarshmallow Color { get; }
        private readonly StringBuilder _stringBuilder;
        public Marshmallow(
            double pricePerKilo, 
            double weight, 
            string name, 
            string manufacturer, 
            int caloriesPer100Gram,
            int percentOfSugar,
            ColorOfMarshmallow color
        ) : base(pricePerKilo, weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            Color = color;
            _stringBuilder = new StringBuilder();
        }
        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine($"\nThis marshmallow: ");
            _stringBuilder.AppendLine(base.ToString());
            _stringBuilder.Append($"Color: {Color}");
            return _stringBuilder.ToString();
        }
    }
}