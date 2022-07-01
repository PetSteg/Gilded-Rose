using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Tests
{
    [TestFixture]
    public class SulfurasTests
    {
        [Test]
        public void Sulfuras_SellInDoesNotDecrement()
        {
            // Given
            Item Sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            Item expectedSulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            IList<Item> Items = new List<Item> { Sulfuras };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedSulfuras.SellIn, Items[0].SellIn);
        }

        [Test]
        public void Sulfuras_QualityDoesNotDecrement()
        {
            // Given
            Item Sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            Item expectedSulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            IList<Item> Items = new List<Item> { Sulfuras };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedSulfuras.Quality, Items[0].Quality);
        }
    }
}