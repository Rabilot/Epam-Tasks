using System.Text;

namespace Task_1.Library.Elements
{
    public class Waffles : Sweetness
    {
        public FillingOfWaffles Filling { get; }
        private readonly StringBuilder _stringBuilder;
        public Waffles(
            double pricePerKilo, 
            double weight, 
            string name, 
            string manufacturer, 
            int caloriesPer100Gram,
            int percentOfSugar,
            FillingOfWaffles filling
            ) : base(pricePerKilo, weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            Filling = filling;
            _stringBuilder = new StringBuilder();
        }
        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine("\nThis waffles: ");
            _stringBuilder.AppendLine(base.ToString());
            _stringBuilder.Append($"Filling: {Filling}");
            return _stringBuilder.ToString();
        }
    }
}