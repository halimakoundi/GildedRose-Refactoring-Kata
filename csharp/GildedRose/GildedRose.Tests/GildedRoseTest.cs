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
        
    
        [Test]
        public void aged_brie_quality_increases_by_one_each_day_before_sell_date() {
            Item agedBrie = ItemWith("Aged Brie", 2, 0);
            gildedRose = aGildedRoseWithItems(agedBrie);

            afterDays(2);

            assertItemsQuality(2, agedBrie);
        }

        
        [Test]
        public void aged_brie_quality_increases_by_two_each_day_after_sell_date() {
            Item agedBrie = ItemWith("Aged Brie", 0, 0);
            gildedRose = aGildedRoseWithItems(agedBrie);

            afterDays(2);

            assertItemsQuality(4, agedBrie);
        }

        
        [Test]
        public void quality_Cannot_be_more_than_fifty() {
            Item agedBrie = ItemWith("Aged Brie", 2, 0);
            gildedRose = aGildedRoseWithItems(agedBrie);

            afterDays(300);

            assertItemsQuality(50, agedBrie);
        }

        
        [Test]
        public void backstage_passes_quality_increases_by_one_each_day_before_ten_days_to_sell_date() {
            Item backstagePasses = ItemWith("Backstage passes to a TAFKAL80ETC concert", 15, 0);
            gildedRose = aGildedRoseWithItems(backstagePasses);

            afterDays(5);

            assertItemsQuality(5, backstagePasses);
        }

        
        [Test]
        public void backstage_passes_quality_increases_by_two_each_day_between_ten_and_five_days_before_sell_date() {
            Item backstagePasses = ItemWith("Backstage passes to a TAFKAL80ETC concert", 15, 0);
            gildedRose = aGildedRoseWithItems(backstagePasses);

            afterDays(7);

            assertItemsQuality(9, backstagePasses);
        }

        
        [Test]
        public void backstage_passes_quality_increases_by_three_each_day_between_five_days_and_the_sell_date() {
            Item backstagePasses = ItemWith("Backstage passes to a TAFKAL80ETC concert", 15, 0);
            gildedRose = aGildedRoseWithItems(backstagePasses);

            afterDays(15);

            assertItemsQuality(30, backstagePasses);
        }

        
        [Test]
        public void backstage_passes_quality_Is_zero_after_the_sell_date() {
            Item backstagePasses = ItemWith("Backstage passes to a TAFKAL80ETC concert", 15, 20);
            gildedRose = aGildedRoseWithItems(backstagePasses);

            afterDays(16);

            assertItemsQuality(0, backstagePasses);
        }

        
        [Test]
        public void perishable_items_quality_decreases_by_one_each_day_before_sell_date() {
            Item regularItem = ItemWith("+5 Dexterity Vest", 10, 20);
            gildedRose = aGildedRoseWithItems(regularItem);

            afterDays(10);

            assertItemsQuality(10, regularItem);
        }

        
        [Test]
        public void perishable_items_quality_decreases_by_two_each_day_after_sell_date() {
            Item perishableItem = ItemWith("+5 Dexterity Vest", 10, 20);
            gildedRose = aGildedRoseWithItems(perishableItem);

            afterDays(15);

            assertItemsQuality(0, perishableItem);
        }

        
        [Test]
        public void perishable_items_quality_cannot_be_less_than_zero() {
            Item perishableItem = ItemWith("+5 Dexterity Vest", 10, 20);
            gildedRose = aGildedRoseWithItems(perishableItem);

            afterDays(200);

            assertItemsQuality(0, perishableItem);
        }

        
        [Test]
        public void conjured_items_quality_decreases_by_two_each_day_before_sell_date() {
            Item conjuredItem = ItemWith("Conjured Mana Cake", 3, 6);
            gildedRose = aGildedRoseWithItems(conjuredItem);

            afterDays(3);

            assertItemsQuality(0, conjuredItem);
        }

        
        [Test]
        public void conjured_items_quality_decreases_by_four_each_day_after_sell_date() {
            Item conjuredItem = ItemWith("Conjured Mana Cake", 5, 18);
            gildedRose = aGildedRoseWithItems(conjuredItem);

            afterDays(7);

            assertItemsQuality(0, conjuredItem);
        }

        
        [Test]
        public void conjured_tems_quality_cannot_be_less_than_zero() {
            Item conjuredItem = ItemWith("Conjured Mana Cake", 5, 18);
            gildedRose = aGildedRoseWithItems(conjuredItem);

            afterDays(200);

            assertItemsQuality(0, conjuredItem);
        }

        
        [Test]
        public void conjured_sulfuras_is_inmutable() {
            Item conjuredSulfuras = ItemWith("Conjured Sulfuras, Hand of Ragnaros", 5, 18);
            gildedRose = aGildedRoseWithItems(conjuredSulfuras);

            afterDays(200);

            assertItemsQuality(18, conjuredSulfuras);
            assertItemsSellIn(5, conjuredSulfuras);
        }

        
        [Test]
        public void conjured_aged_Brie_quality_increases_by_two_each_day_before_sell_date() {
            Item agedBrie = ItemWith("Conjured Aged Brie", 2, 0);
            gildedRose = aGildedRoseWithItems(agedBrie);

            afterDays(2);

            assertItemsQuality(4, agedBrie);
        }

        
        [Test]
        public void conjured_backstage_passes_quality_increases_twice_faster() {
            Item backstagePasses = ItemWith("Conjured Backstage passes to a TAFKAL80ETC concert", 15, 0);
            gildedRose = aGildedRoseWithItems(backstagePasses);

            afterDays(15);

            assertItemsQuality(50, backstagePasses);
        }

        
        [Test]
        public void conjured_backstage_passes_quality_is_zero_after_the_sell_date() {
            Item backstagePasses = ItemWith("Conjured Backstage passes to a TAFKAL80ETC concert", 15, 2);
            gildedRose = aGildedRoseWithItems(backstagePasses);

            afterDays(16);

            assertItemsQuality(0, backstagePasses);
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
        
        private GildedRoseKata.Src.GildedRose aGildedRoseWithItems(Item item)
        {
            return new GildedRoseKata.Src.GildedRose(new List<Item> { item });
        }
        
        private Item ItemWith(string name, int sellIn, int quality)
        {
            return Item notSulfuras = new Item()
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
        }
        
        private void assertItemsQuality (int expected, Item item)
        {
            Assert.That(item.Quality, Is.EqualTo(expected));
        }
        
        private void assertItemsSellIn (int expected, Item item)
        {
            Assert.That(item.SellIn, Is.EqualTo(expected));
        }
    }
}

