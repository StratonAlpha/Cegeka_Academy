using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("itemNou", 15, 3)]
        public void foo(string name, int sellIn, int quality)
        {
            var itemTested = new Item(name, sellIn, quality);
            var itemExpected = new Item(name, sellIn-1, quality-1);
            IList<Item> Items = new List<Item>();
            Items.Add(itemTested);
            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(itemExpected, app.Items[0]);
        }
    }
}
