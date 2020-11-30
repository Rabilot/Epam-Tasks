﻿using System;
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
            Gift gift = MakeGift();
            Console.WriteLine(gift);
            Serialize(gift);
            WritePriceRange(gift); 
            Console.WriteLine("This gift is: \n" + gift.FindByName("Beer"));
            gift.Remove(0);
            gift = Deserializegift("Act.xml");
        }

        static void WritePriceRange(IGift gift)
        {
            Console.WriteLine("Write minimal and maximal price: ");
            try
            {
                var min = Convert.ToDouble(Console.ReadLine());
                var max = Convert.ToDouble(Console.ReadLine());
                List<GiftItem.GiftItem> giftItems = gift.FindByPriceRange(min, max);
                foreach (var giftItem in giftItems)
                {
                    Console.WriteLine(giftItem);
                }
            }
            catch (InvalidPriceException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Try again: ");
                WritePriceRange(gift);
            }
        }

        

        static Gift MakeGift()
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

        static Gift Deserializegift(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Gift));
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                Gift gift = (Gift) serializer.Deserialize(fileStream);
                fileStream.Close();
                return gift;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {path} not found!");
                return new Gift();
            }
        }

        static void Serialize(Gift gift)
        {
            if (gift.IsEmpty()) return;
            XmlSerializer serializer = new XmlSerializer(typeof(Gift));
            FileStream fileStream = new FileStream("database.xml", FileMode.OpenOrCreate);
            serializer.Serialize(fileStream, gift);
            fileStream.Close();
        }
    }
}