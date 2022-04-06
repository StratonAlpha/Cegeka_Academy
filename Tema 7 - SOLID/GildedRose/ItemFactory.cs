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
        public Item GetItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(item.Name, item.SellIn, item.Quality);
                case "Backstage Pass":
                    return new Backstage(item.Name, item.SellIn, item.Quality);
                default:
                    return new Item(item.Name, item.SellIn, item.Quality);
            }
        }
    }
}
