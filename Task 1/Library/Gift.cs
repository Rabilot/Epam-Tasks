using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_1.Library.Exceptions;
using Task_1.Library.Elements;
using Task_1.Library.Interfaces;

namespace Task_1.Library
{
    public class Gift : IGift
    {
        private IList<GiftItem> _gift;
        private readonly StringBuilder _stringBuilder;
        public Gift()
        {
            _gift = new List<GiftItem>();
            _stringBuilder = new StringBuilder();
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
            return _gift.FirstOrDefault(item => item.Name == name); 
        }

        public bool IsEmpty()
        {
            return !_gift.Any();
        }

        public List<GiftItem> FindByPriceRange(double min, double max)
        {
            if (min < 0 || max < min)
            {
                throw new InvalidPriceException("Invalid price!");
            }
            
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

        public void SortByName()
        {
            _gift = _gift.OrderBy(item => item.Name).ToList();
        }

        public void SortByPrice()
        {
            _gift = _gift.OrderBy(item => item.Price).ToList();
        }
        
        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.AppendLine("Gift: ");
            foreach (var giftItem in _gift)
            {
                _stringBuilder.AppendLine($"{giftItem}");
            }
            
            return _stringBuilder.ToString();
        }
    }
}