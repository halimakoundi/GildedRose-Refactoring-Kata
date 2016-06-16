using System;
using NUnit.Framework;
using System.Collections.Generic;
using GildedRoseKata.Src;

namespace GildedRoseTest
{
    [TestFixture()]
    public class GildedRoseTest
    {
        private GildedRoseKata.Src.GildedRose gildedRose;

        [Test()]
        public void sulfuras_is_inmutable()
        {
            Item sulfuras = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80
            };
            gildedRose = aGildedRoseWithItems(sulfuras);

            afterDays(10);

            Assert.That(sulfuras.Quality, Is.EqualTo(80));
            Assert.That(0, Is.EqualTo(sulfuras.SellIn));
        }

        [Test]
        public void sell_in_decreases_by_one_each_day()
        {
            Item notSulfuras = new Item()
            {
                Name = "NotSulfuras",
                SellIn = 2,
                Quality = 0
            };
            gildedRose = aGildedRoseWithItems(notSulfuras);

            afterDays(10);

            Assert.That(notSulfuras.SellIn, Is.EqualTo(- 8));
        }
       
        private GildedRoseKata.Src.GildedRose aGildedRoseWithItems(Item item)
        {
            return new GildedRoseKata.Src.GildedRose(new List<Item> { item });
        }

        private void afterDays(int days)
        {
            for (var i = 0; i < days; i++)
            {
                gildedRose.UpdateQuality();
            }

        }
    }
}

