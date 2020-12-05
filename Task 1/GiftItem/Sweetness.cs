using System.Text;

namespace Task_1.GiftItem
{
    public abstract class Sweetness : GiftItem
    {
        public int CaloriesPer100Gram{ get; }
        public int PercentOfSugar{ get; }
        public double PricePerKilo { get; }

        protected Sweetness(double pricePerKilo, double weight, string name, string manufacturer, int caloriesPer100Gram, 
            int percentOfSugar) : base(pricePerKilo*weight/1000, weight, name, manufacturer)
        {
            PricePerKilo = pricePerKilo;
            CaloriesPer100Gram = caloriesPer100Gram;
            PercentOfSugar = percentOfSugar;
        }

        protected Sweetness()
        {
            
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\n{base.ToString()}");
            stringBuilder.Append($"Calories: {CaloriesPer100Gram}\nPrecentOfSugar: {PercentOfSugar}" +
                                 $"\nPrice per kilo: {PricePerKilo}");
            return stringBuilder.ToString();
        }
    }
}