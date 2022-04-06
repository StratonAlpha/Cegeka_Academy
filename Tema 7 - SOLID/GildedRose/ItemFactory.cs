using GildedRose.Models;
using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class ItemFactory
    {
        public QualityModifier GetItem(Item item)
        {
            switch (item.Name)
            {
                case "AgedBrie":
                    return new AgedBrie();
                case "Backstage":
                    return new Backstage();
                case "Conjured":
                    return new Conjured();
                default:
                    return new QualityModifier();
            }
        }
    }
}
