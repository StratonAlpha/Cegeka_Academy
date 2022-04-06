namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item()
        {
        }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void ChangeDay()
        {
            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellIn--;
            }
        }

        public virtual void updateQuality()
        {
            DecreaseQuality();
            if (SellIn < 0)
                DecreaseQuality();
        }

        protected void IncreaseQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }

        protected void DecreaseQuality()
        {
            if(Quality > 0 
               && Name != "Sulfuras, Hand of Ragnaros")
                Quality--;
        }
    }
}
