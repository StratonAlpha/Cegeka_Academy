using GildedRoseKata;

namespace GildedRose
{
    public class QualityModifier
    {

        public virtual void UpdateQuality(Item item)
        {
            DecreaseQuality(item);
            if (item.SellIn < 0)
                DecreaseQuality(item);
        }

        protected void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        protected void DecreaseQuality(Item item)
        {
            if (item.Name != "Sulfuras" 
                && item.Quality > 0)
                item.Quality = item.Quality - 1;
        }
    }
}
