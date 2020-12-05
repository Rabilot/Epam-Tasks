using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Task_1.Exceptions;
using Task_1.GiftItem;
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
            Console.WriteLine("\nThis gift is: " + gift.FindByName("Beer"));
            Console.WriteLine("\nCost of Gift: " + gift.Price());
            Console.WriteLine("\nWeight of Gift: " + gift.Weight());
            gift.Remove(0);
        }

        static void WritePriceRange(IGift gift)
        {
            Console.WriteLine("Write minimal and maximal price: \n");
            try
            {
                var min = Convert.ToDouble(Console.ReadLine());
                var max = Convert.ToDouble(Console.ReadLine());
                List<GiftItem.GiftItem> giftItems = gift.FindByPriceRange(min, max);
                if (giftItems.Count != 0)
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
                Console.WriteLine("Try again: ");
                WritePriceRange(gift);
            }
        }



        static IGift MakeGift()
        {
            var gift = new Gift();
            Candy candy = new Candy(12, 1450, "Just candy", "Candy INC.", 432, 70);
            gift.Add(candy);
            Cookie cookie = new Cookie(4, 600, "COOKIES!!!", "Cookie INC.", 502, 10);
            gift.Add(cookie);
            Toy toy = new Toy(60, 1200, "Beer", "Toy INC.", "Plastic");
            gift.Add(toy);
            Waffles waffles = new Waffles(2, 100, "FPS", "Waffles & Beer INC.", 310, 35);
            gift.Add(waffles);
            return gift;
        }
    }
}