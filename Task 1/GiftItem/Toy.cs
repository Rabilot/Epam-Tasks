using System;
using System.Text;

namespace Task_1.GiftItem
{
    public class Toy : GiftItem
    {
        public string Material { get; }

        private Toy()
        {
        }

        public Toy(double Price, double Weight, string Name, string Manufacturer, string Material) : base(Price, Weight, Name,
            Manufacturer)
        {
            this.Material = Material;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Material: {Material}");
            return stringBuilder.ToString();
        }
    }
}