using System.Text;

namespace Task_1.Elements
{
    public class Candy : Sweetness
    {
        public TypeOfCandy Type { get; }
        private readonly StringBuilder _stringBuilder;
        public Candy(
            double pricePerKilo, 
            double weight, 
            string name, 
            string manufacturer, 
            int caloriesPer100Gram,
            int percentOfSugar,
            TypeOfCandy type
        ) : base(pricePerKilo,weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            Type = type;
            _stringBuilder = new StringBuilder();
        }
        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine("\nThis candy: ");
            _stringBuilder.AppendLine(base.ToString());
            _stringBuilder.AppendLine($"\n{Type}");
            return _stringBuilder.ToString();
        }
    }
}