﻿namespace Task_1.GiftItem
{
    public class Candy : Sweetness
    {

        public Candy()
        {
            
        }

        public Candy(double price, double weight, string name, string manufacturer, int caloriesPer100Gram,
            int percentOfSugar) : base(price, weight, name, manufacturer, caloriesPer100Gram, percentOfSugar)
        {
            
        }
    }
}