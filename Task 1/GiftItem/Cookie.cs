namespace Task_1.GiftItem
{
    public class Cookie : Sweetness
    {
        public Cookie()
        {
            
        }

        public Cookie(double pricePerKilo,  double weight, string name, string manufacturer, int caloriesPer100Gram,
            int percentOfSugar) : base(pricePerKilo, weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            
        }
    }
}