using System.Text;

namespace Task_1.GiftItem
{
    public abstract class Sweetness : GiftItem
    {
        public int CaloriesPer100Gram{ get; }
        public int PercentOfSugar{ get; }

        public Sweetness(double price, double weight, string name, string manufacturer, int caloriesPer100Gram, 
            int percentOfSugar) : base(price, weight, name, manufacturer)
        {
            this.CaloriesPer100Gram = caloriesPer100Gram;
            this.PercentOfSugar = percentOfSugar;
        }

        protected Sweetness()
        {
            
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Calories: {CaloriesPer100Gram}\nPrecentOfSugar: {PercentOfSugar}");
            return stringBuilder.ToString();
        }
    }
}