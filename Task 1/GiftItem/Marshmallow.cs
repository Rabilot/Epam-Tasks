namespace Task_1.GiftItem
{
    public class Marshmallow : Sweetness
    {
        public Marshmallow()
        {
            
        }

        public Marshmallow(double pricePerKilo, double weight, string name, string manufacturer, int caloriesPer100Gram,
            int percentOfSugar) : base(pricePerKilo,  weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            
        }
    }
}