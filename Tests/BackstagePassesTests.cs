using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class BackstagePassesTests
    {
        [Test]
        public void BackstagePasses_SellInDecrements()
        {
            // Given
            Item backstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };
            Item expectedBackstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 12 };
            IList<Item> Items = new List<Item> { backstagePasses };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(backstagePasses.SellIn, Items[0].SellIn);
        }

        [Test]
        public void BackstagePasses_QualityIncreasesOnceWhenSellinAbove10()
        {
            // Given
            Item backstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 };
            Item expectedBackstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 11 };
            IList<Item> Items = new List<Item> { backstagePasses };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(backstagePasses.Quality, Items[0].Quality);
        }

        [Test]
        public void BackstagePasses_QualityIncreasesTwiceWhenSellinAbove5BelowOrEqual10()
        {
            // Given
            Item backstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };
            Item expectedBackstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 12 };
            IList<Item> Items = new List<Item> { backstagePasses };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(backstagePasses.Quality, Items[0].Quality);
        }

        [Test]
        public void BackstagePasses_QualityIncreasesBy3WhenSellinAbove0BelowOrEqual5()
        {
            // Given
            Item backstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };
            Item expectedBackstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 13 };
            IList<Item> Items = new List<Item> { backstagePasses };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(backstagePasses.Quality, Items[0].Quality);
        }

        [Test]
        public void BackstagePasses_QualityDropTo0WhenSellinBelowOrEqual0()
        {
            // Given
            Item backstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };
            Item expectedBackstagePasses = new Item
                { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 0 };
            IList<Item> Items = new List<Item> { backstagePasses };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(backstagePasses.Quality, Items[0].Quality);
        }
    }
}