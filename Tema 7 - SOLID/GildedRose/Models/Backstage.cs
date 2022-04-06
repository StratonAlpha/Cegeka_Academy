using GildedRoseKata;

namespace GildedRose.Models
{
    public class Backstage : QualityModifier
    {
        public override void UpdateQuality(Item item)
        {
            IncreaseQuality(item);

            if(item.SellIn <= 10)
                IncreaseQuality(item);
            
            if(item.SellIn <= 5)
                IncreaseQuality(item);

            if(item.SellIn <= 0)
            {
                item.Quality = 0;
            }
        }
    }
}
