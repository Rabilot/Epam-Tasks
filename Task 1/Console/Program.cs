using System.Collections.Generic;
using System.Linq;
using Task_1.Library.Elements;
using Task_1.Library.Exceptions;
using Task_1.Library.Gift;

namespace Task_1.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IGift gift = MakeGift();
            System.Console.WriteLine(gift);
            WritePriceRange(gift);
            System.Console.WriteLine("Sort gift by name...");
            gift.SortByName();
            System.Console.WriteLine(gift);
            System.Console.WriteLine($"This item of gift is: {gift.FindByName("Bear")}");
            System.Console.WriteLine($"Cost of Gift: {gift.GetPrice()}");
            System.Console.WriteLine($"Weight of Gift: {gift.GetWeight()}");
            gift.Remove(0);
        }

        static void WritePriceRange(IGift gift)
        {
            System.Console.WriteLine("Write minimal and maximal price: \n");
            try
            {
                double min, max;
                while (!double.TryParse(System.Console.ReadLine(), out min))
                {
                    System.Console.WriteLine("Try again: ");
                }
                while (!double.TryParse(System.Console.ReadLine(), out max))
                {
                    System.Console.WriteLine("Try again: ");
                }
                List<GiftItem> giftItems = gift.FindByPriceRange(min, max);
                if (giftItems.Any())
                {
                    foreach (var giftItem in giftItems)
                    {
                        System.Console.WriteLine(giftItem);
                    }
                }
                else
                {
                    System.Console.WriteLine("No items were found!\n");
                }
            }
            catch (InvalidPriceException e)
            {
                System.Console.WriteLine(e);
            }
        }
        static IGift MakeGift()
        {
            IGift gift = new Gift();
            Candy candy = new Candy(12, 1450, "Just candy", "Candy INC.", 432, 70, TypeOfCandy.Caramel);
            gift.Add(candy);
            Cookie cookie = new Cookie(4, 600, "COOKIES!!!", "Cookie INC.", 502, 10, FillingOfCooke.Honey);
            gift.Add(cookie);
            Toy toy = new Toy(60, 1200, "Bear", "Toy INC.", "Plastic");
            gift.Add(toy);
            Waffles waffles = new Waffles(2, 100, "FPS", "Waffles & Beer INC.", 310, 35, FillingOfWaffles.Milk);
            gift.Add(waffles);
            return gift;
        }
    }
}