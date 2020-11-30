namespace Task_1.GiftItem
{
    public class Waffles : Sweetness
    {
        public Waffles()
        {
            
        }

        public Waffles(double price, double weight, string name, string manufacturer, int caloriesPer100Gram,
            int percentOfSugar) : base(price, weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            
        }
    }
}