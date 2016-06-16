using System;
using System.Collections.Generic;

namespace GildedRoseKata.Src
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQuality(Items[i]);
            }
        }

        private void UpdateQuality(Item item)
        {
            var Items = new Item[1];
            Items[0] = item;
            var i = 0;
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                Items[i].DecreaseQuality();
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality += 1;

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            Items[i].IncreaseQuality();
                        }

                        if (Items[i].SellIn < 6)
                        {
                            Items[i].IncreaseQuality();
                        }
                    }
                }
            }
            Items[i].UpdateExpiration();

            if (Items[i].HasExpired())
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        Items[i].DecreaseQuality();
                    }
                    else
                    {
                        Items[i].ResetQuality();
                    }
                }
                else
                {
                    Items[i].IncreaseQuality();
                }
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        internal void DecreaseQuality()
        {
            if (Quality > 0 && IsMutable())
            {
                Quality -= 1;
            }
        }

        private bool IsMutable()
        {
            return Name != "Sulfuras, Hand of Ragnaros";
        }

        internal void IncreaseQuality()
        {
            if (Quality < 50)
            {
                Quality += 1;
            }
        }

        internal void ResetQuality()
        {
            Quality = 0;

        }

        internal void UpdateExpiration()
        {
            if (IsMutable())
            {
                SellIn -= 1;
            }
        }

        internal bool HasExpired()
        {
            return SellIn < 0;
        }
    }

}
