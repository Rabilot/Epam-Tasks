using System;
using System.Collections.Generic;
using System.Linq;
using Task_1.Exceptions;
using Task_1.Elements;
using Task_1.Interfaces;

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IGift gift = MakeGift();
            Console.WriteLine(gift);
            WritePriceRange(gift);
            Console.WriteLine("Sort gift by name...");
            gift.SortByName();
            Console.WriteLine(gift);
            Console.WriteLine($"\nThis item of gift is: {gift.FindByName("Beer")}");
            Console.WriteLine($"\nCost of Gift: {gift.GetPrice()}");
            Console.WriteLine($"\nWeight of Gift: {gift.GetWeight()}");
            gift.Remove(0);
        }

        static void WritePriceRange(IGift gift)
        {
            Console.WriteLine("Write minimal and maximal price: \n");
            try
            {
                double min, max;
                while (!double.TryParse(Console.ReadLine(), out min))
                {
                    Console.WriteLine("Try again: ");
                }
                while (!double.TryParse(Console.ReadLine(), out max))
                {
                    Console.WriteLine("Try again: ");
                }
                List<GiftItem> giftItems = gift.FindByPriceRange(min, max);
                if (giftItems.Any())
                {
                    foreach (var giftItem in giftItems)
                    {
                        Console.WriteLine(giftItem);
                    }
                }
                else
                {
                    Console.WriteLine("No items were found!\n");
                }
            }
            catch (InvalidPriceException e)
            {
                Console.WriteLine(e);
            }
        }
        static IGift MakeGift()
        {
            IGift gift = new Gift();
            Candy candy = new Candy(12, 1450, "Just candy", "Candy INC.", 432, 70, TypeOfCandy.Caramel);
            gift.Add(candy);
            Cookie cookie = new Cookie(4, 600, "COOKIES!!!", "Cookie INC.", 502, 10, FillingOfCooke.Honey);
            gift.Add(cookie);
            Toy toy = new Toy(60, 1200, "Beer", "Toy INC.", "Plastic");
            gift.Add(toy);
            Waffles waffles = new Waffles(2, 100, "FPS", "Waffles & Beer INC.", 310, 35, FillingOfWaffles.Milk);
            gift.Add(waffles);
            return gift;
        }
    }
}