using System.Collections.Generic;
using Task_1.Library.Elements;

namespace Task_1.Library.Gift
{
    public interface IGift
    {
        void Add(GiftItem giftItem);
        void Remove(GiftItem giftItem);
        void Remove(int index);
        GiftItem FindByName(string name);
        bool IsEmpty();
        List<GiftItem> FindByPriceRange(double min, double max);
        int GetCount();
        double GetPrice();
        void SortByName();
        void SortByPrice();
        double GetWeight();
    }
}