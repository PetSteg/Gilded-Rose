using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class GenericItemTests
    {
        [Test]
        public void GenericItem_SellInDecrements()
        {
            // Given
            Item greenApple = new Item { Name = "Green Apple", SellIn = 10, Quality = 10 };
            Item expectedGreenApple = new Item { Name = "Green Apple", SellIn = 9, Quality = 9 };
            IList<Item> Items = new List<Item> { greenApple };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedGreenApple.SellIn, Items[0].SellIn);
        }

        [Test]
        public void GenericItem_QualityDecrementsOnceBeforeSellby()
        {
            // Given
            Item greenApple = new Item { Name = "Green Apple", SellIn = 10, Quality = 10 };
            Item expectedGreenApple = new Item { Name = "Green Apple", SellIn = 9, Quality = 9 };
            IList<Item> Items = new List<Item> { greenApple };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedGreenApple.Quality, Items[0].Quality);
        }

        [Test]
        public void GenericItem_QualityDecrementsTwiceAfterSellby()
        {
            // Given
            Item greenApple = new Item { Name = "Green Apple", SellIn = 0, Quality = 10 };
            Item expectedGreenApple = new Item { Name = "Green Apple", SellIn = -1, Quality = 8 };
            IList<Item> Items = new List<Item> { greenApple };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedGreenApple.Quality, Items[0].Quality);
        }

        [Test]
        public void GenericItem_QualityNeverNegativeBeforeSellby()
        {
            // Given
            Item greenApple = new Item { Name = "Green Apple", SellIn = 10, Quality = 0 };
            Item expectedGreenApple = new Item { Name = "Green Apple", SellIn = 9, Quality = 0 };
            IList<Item> Items = new List<Item> { greenApple };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedGreenApple.Quality, Items[0].Quality);
        }

        [Test]
        public void GenericItem_QualityNeverNegativeAfterSellby()
        {
            // Given
            Item greenApple = new Item { Name = "Green Apple", SellIn = 0, Quality = 0 };
            Item expectedGreenApple = new Item { Name = "Green Apple", SellIn = -1, Quality = 0 };
            IList<Item> Items = new List<Item> { greenApple };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedGreenApple.Quality, Items[0].Quality);
        }
    }
}