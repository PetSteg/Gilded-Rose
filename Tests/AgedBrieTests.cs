using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class AgedBrieTests
    {
        [Test]
        public void AgedBrie_SellInDecrements()
        {
            // Given
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 };
            Item expectedAgedBrie = new Item { Name = "Aged Brie", SellIn = 9, Quality = 11 };
            IList<Item> Items = new List<Item> { agedBrie };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedAgedBrie.SellIn, Items[0].SellIn);
        }

        [Test]
        public void AgedBrie_QualityIncreasesWhenBelow50AndBeforeSellin()
        {
            // Given
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 10, Quality = 40 };
            Item expectedAgedBrie = new Item { Name = "Aged Brie", SellIn = 9, Quality = 41 };
            IList<Item> Items = new List<Item> { agedBrie };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedAgedBrie.Quality, Items[0].Quality);
        }

        [Test]
        public void AgedBrie_QualityDoesNotIncreaseAbove50AndBeforeSellin()
        {
            // Given
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 };
            Item expectedAgedBrie = new Item { Name = "Aged Brie", SellIn = 9, Quality = 50 };
            IList<Item> Items = new List<Item> { agedBrie };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedAgedBrie.Quality, Items[0].Quality);
        }

        [Test]
        public void AgedBrie_QualityIncreasesWhenBelow50AndAfterSellin()
        {
            // Given
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 0, Quality = 40 };
            Item expectedAgedBrie = new Item { Name = "Aged Brie", SellIn = -1, Quality = 42 };
            IList<Item> Items = new List<Item> { agedBrie };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedAgedBrie.Quality, Items[0].Quality);
        }

        [Test]
        public void AgedBrie_QualityDoesNotIncreaseAbove50AndAfterSellin()
        {
            // Given
            Item agedBrie = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };
            Item expectedAgedBrie = new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 };
            IList<Item> Items = new List<Item> { agedBrie };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedAgedBrie.Quality, Items[0].Quality);
        }
    }
}