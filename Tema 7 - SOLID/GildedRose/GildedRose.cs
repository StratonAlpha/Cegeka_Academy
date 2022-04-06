using GildedRose;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        public IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            Items = items;
        }
        public void UpdateQuality()
        {
            var factory = new ItemFactory();
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras")
                    break;
                item.ChangeDay();
                var update = factory.GetItem(item);
                update.UpdateQuality(item);
            }
        }
    }
}
