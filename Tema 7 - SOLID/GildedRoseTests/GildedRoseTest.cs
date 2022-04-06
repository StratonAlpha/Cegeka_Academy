using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using System;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData("itemNou", 15, 3, 5)]
        [InlineData("itemNou", 15, 3, 10)]
        [InlineData("itemNou", 15, 3, 15)]
        [InlineData("AgedBrie", 15, 3, 5)]
        [InlineData("AgedBrie", 15, 3, 10)]
        [InlineData("AgedBrie", 15, 3, 15)]
        [InlineData("Backstage", 15, 3, 5)]
        [InlineData("Backstage", 15, 3, 10)]
        [InlineData("Backstage", 15, 3, 15)]
        [InlineData("Conjured", 15, 3, 5)]
        [InlineData("Conjured", 15, 3, 10)]
        [InlineData("Conjured", 15, 3, 15)]
        [InlineData("Sulfuras", 15, 3, 200)]
        public void foo(string name, int sellIn, int quality, int numberOfDays)
        {
            var itemTested = new Item(name, sellIn, quality);
            Item itemExpected = CreateExpected(name, sellIn, quality, numberOfDays);
            IList<Item> Items = new List<Item>();
            Items.Add(itemTested);
            GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);

            for(int i = 0; i < numberOfDays; i++)
                app.UpdateQuality();

            Assert.Equal(itemExpected.Name, app.Items[0].Name);
            Assert.Equal(itemExpected.SellIn, app.Items[0].SellIn);
            Assert.Equal(itemExpected.Quality, app.Items[0].Quality);
        }
    
        public Item CreateExpected(string name, int sellIn, int quality, int numberOfDays)
        {
            Item expectedItem;
            int expectedSellIn;
            int expectedQuality;

            switch (name)
            {
                case "AgedBrie":
                    expectedSellIn = sellIn - numberOfDays;
                    expectedQuality = quality + numberOfDays;

                    if (expectedQuality > 50)
                        expectedItem = new Item(name, expectedSellIn, 50);
                    else
                        expectedItem = new Item(name, expectedSellIn, expectedQuality);
                    break;

                case "Backstage":
                    expectedSellIn = sellIn - numberOfDays;
                    expectedQuality = quality;
                    for(int i = 1; i <= numberOfDays; i++)
                    {
                        expectedQuality++;
                        if ((sellIn - i) < 11)
                            expectedQuality++;
                        if ((sellIn - i) < 6)
                            expectedQuality++;
                    }

                    if (expectedSellIn > 0)
                    {
                        if (expectedQuality > 50)
                            expectedItem = new Item(name, expectedSellIn, 50);
                        else
                            expectedItem = new Item(name, expectedSellIn, expectedQuality);
                    }
                    else
                        expectedItem = new Item(name, expectedSellIn, 0);
                    break;

                case "Sulfuras":
                    expectedItem = new Item(name, sellIn, quality);
                    break;

                case "Conjured":
                    expectedSellIn = sellIn - numberOfDays;
                    expectedQuality = quality - numberOfDays*2;

                    if (expectedSellIn < 0)
                        expectedQuality -= expectedSellIn;

                    if (expectedQuality < 0)
                        expectedItem = new Item(name, expectedSellIn, 0);
                    else
                        expectedItem = new Item(name, expectedSellIn, expectedQuality);
                    break;

                default:
                    expectedSellIn = sellIn - numberOfDays;
                    expectedQuality = quality - numberOfDays;
                    
                    if (expectedSellIn < 0)
                        expectedQuality -= expectedSellIn;

                    if (expectedQuality < 0)
                        expectedItem = new Item(name, expectedSellIn, 0);
                    else
                        expectedItem = new Item(name, expectedSellIn, expectedQuality);
                    break;
            }

            return expectedItem;

        }

    }
}
