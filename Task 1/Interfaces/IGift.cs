using System.Collections.Generic;

namespace Task_1.Interfaces
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