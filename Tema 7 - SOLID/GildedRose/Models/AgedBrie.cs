using GildedRoseKata;

namespace GildedRose.Models
{
    public class AgedBrie : QualityModifier
    {
        public override void UpdateQuality(Item item)
        {
            IncreaseQuality(item);
        }
    }
}
