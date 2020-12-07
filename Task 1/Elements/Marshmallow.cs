using System;
using System.Text;

namespace Task_1.Elements
{
    public class Marshmallow : Sweetness
    {
        public Marshmallow(
            double pricePerKilo, 
            double weight, 
            string name, 
            string manufacturer, 
            int caloriesPer100Gram,
            int percentOfSugar
            ) : base(pricePerKilo, weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"This marshmallow: {Environment.NewLine}");
            stringBuilder.Append(base.ToString());
            return stringBuilder.ToString();
        }
    }
}