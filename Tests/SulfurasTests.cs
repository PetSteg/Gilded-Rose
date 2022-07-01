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
            Item greenApple = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            Item expectedGreenApple = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            IList<Item> Items = new List<Item> { greenApple };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedGreenApple.SellIn, Items[0].SellIn);
        }

        [Test]
        public void Sulfuras_QualityDoesNotDecrement()
        {
            // Given
            Item greenApple = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            Item expectedGreenApple = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            IList<Item> Items = new List<Item> { greenApple };
            GildedRose app = new GildedRose(Items);

            //When
            app.UpdateQuality();

            // Then
            Assert.AreEqual(expectedGreenApple.Quality, Items[0].Quality);
        }
    }
}