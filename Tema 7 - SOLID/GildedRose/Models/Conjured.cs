using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models
{
    public class Conjured : QualityModifier
    {
        public override void UpdateQuality(Item item)
        {
            DecreaseQuality(item);
            DecreaseQuality(item);
            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
                DecreaseQuality(item);
            }
        }
    }
}
