using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_1.Interfaces;

namespace Task_1
{
    public class Gift : IGift
    {
        private readonly List<GiftItem> _gift;
        
        public Gift()
        {
            _gift = new List<GiftItem>(); // Добавил конструктор
        }
        
        public void Add(GiftItem giftItem)
        {
            _gift.Add(giftItem);
        }
        
        public void Remove(GiftItem giftItem)
        {
            _gift.Remove(giftItem);
        }
        
        public void Remove(int index)
        {
            if (!IsEmpty()) _gift.RemoveAt(index);
        }
        
        public GiftItem FindByName(string name)
        {
            return _gift.Find(item => item.Name == name);
        }

        public bool IsEmpty()
        {
            return !_gift.Any();
        }

        public List<GiftItem> FindByPriceRange(double min, double max)
        {
            return _gift.Where(item => item.Price >= min && item.Price <= max).ToList();
        }

        public int GetCount()
        {
            return _gift.Count;
        }

        public double GetPrice()
        {
            return _gift.Sum(item => item.Price);
        }


        public double GetWeight()
        {
            return _gift.Sum(item => item.Weight);
        }
        
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Gift: \n");
            foreach (var giftItem in _gift)
            {
                stringBuilder.Append($"{giftItem}\n");
            }
            
            return stringBuilder.ToString();
        }
    }
}