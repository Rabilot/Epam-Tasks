using System.Collections.Generic;
using Task_1.GiftItem;

namespace Task_1.Interfaces
{
    public interface IGift
    {
        void Add(GiftItem.GiftItem giftItem);
        void Remove(GiftItem.GiftItem giftItem);
        void Remove(int index);
        GiftItem.GiftItem FindByName(string name);
        bool IsEmpty();
        List<GiftItem.GiftItem> FindByPriceRange(double min, double max);
        int NumberOfGiftItems();
        double Price();
        double Weight();
    }
}