using GildedRoseKata;

namespace GildedRose.Models
{
    public class AgedBrie : Item
    {
        public AgedBrie() : base()
        {
        }

        public AgedBrie(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override void updateQuality()
        {
            IncreaseQuality();
            if(SellIn < 0)
                IncreaseQuality();
        }
    }
}
