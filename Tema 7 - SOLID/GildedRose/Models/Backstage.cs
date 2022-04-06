using GildedRoseKata;

namespace GildedRose.Models
{
    public class Backstage : Item
    {
        public Backstage() : base()
        {
        }

        public Backstage(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override void updateQuality()
        {
            IncreaseQuality();

            if(SellIn <= 10)
                IncreaseQuality();
            
            if(SellIn <= 5)
                IncreaseQuality();
        }
    }
}
