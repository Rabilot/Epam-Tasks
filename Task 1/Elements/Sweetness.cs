using System;
using System.Text;

namespace Task_1.Elements
{
    public abstract class Sweetness : GiftItem
    {
        private const double ToKilo = 0.001;
        public int CaloriesPer100Gram{ get; }
        public int PercentOfSugar{ get; }
        public double PricePerKilo { get; }
        private readonly StringBuilder _stringBuilder;

        protected Sweetness(
            double pricePerKilo, 
            double weight, 
            string name, 
            string manufacturer, 
            int caloriesPer100Gram, 
            int percentOfSugar
            ) : base(pricePerKilo * weight * ToKilo, weight, name, manufacturer)
        {
            PricePerKilo = pricePerKilo;
            CaloriesPer100Gram = caloriesPer100Gram;
            PercentOfSugar = percentOfSugar;
            _stringBuilder = new StringBuilder();
        }

        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine($"{base.ToString()}");
            _stringBuilder.AppendLine($"Calories: {CaloriesPer100Gram}\nPercent Of Sugar: {PercentOfSugar}" +
                                 $"\nPrice per kilo: {PricePerKilo}");
            return _stringBuilder.ToString();
        }
    }
}