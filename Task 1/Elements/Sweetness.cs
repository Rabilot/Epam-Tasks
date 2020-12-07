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
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n{base.ToString()}");
            stringBuilder.Append($"Calories: {CaloriesPer100Gram}{Environment.NewLine}Percent Of Sugar: {PercentOfSugar}" +
                                 $"\nPrice per kilo: {PricePerKilo}");
            return stringBuilder.ToString();
        }
    }
}