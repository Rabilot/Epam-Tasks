using System.Text;

namespace Task_1.Library.Elements
{
    public class Cookie : Sweetness
    {
        public FillingOfCooke Filling { get; }
        private readonly StringBuilder _stringBuilder;
        public Cookie(
            double pricePerKilo,  
            double weight, 
            string name, 
            string manufacturer, 
            int caloriesPer100Gram,
            int percentOfSugar,
            FillingOfCooke filling
            ) : base(pricePerKilo, weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            Filling = filling;
            _stringBuilder = new StringBuilder();
        }
        
        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine("\nThis cookie: ");
            _stringBuilder.AppendLine(base.ToString());
            _stringBuilder.Append($"Filling: {Filling}");
            return _stringBuilder.ToString();
        }
    }
}