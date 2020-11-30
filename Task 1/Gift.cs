using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_1.Interfaces;

namespace Task_1
{
    public class Gift : IGift
    {
        private List<GiftItem.GiftItem> _gift = new List<GiftItem.GiftItem>();

        public void Add(GiftItem.GiftItem giftItem)
        {
            _gift.Add(giftItem);
        }

        public void Remove(GiftItem.GiftItem giftItem)
        {
            _gift.Remove(giftItem);
        }

        public void Remove(int index)
        {
            if (!IsEmpty())_gift.RemoveAt(index);
        }

        public GiftItem.GiftItem FindByName(string name)
        {
            return _gift.Find(item => item.Name == name);
        }

        public bool IsEmpty()
        {
            return _gift.Count == 0;
        }

        public List<GiftItem.GiftItem> FindByPriceRange(double min, double max)
        {
            return _gift.Where(item => item.Price >= min && item.Price <= max).ToList();
        }

        public int NumberOfGiftItems()
        {
            return _gift.Count;
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