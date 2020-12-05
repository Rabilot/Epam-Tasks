namespace Task_1.GiftItem
{
    public class Candy : Sweetness
    {

        public Candy()
        {
            
        }

        public Candy(double pricePerKilo, double weight, string name, string manufacturer, int caloriesPer100Gram,
            int percentOfSugar) : base(pricePerKilo,weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            
        }
    }
}