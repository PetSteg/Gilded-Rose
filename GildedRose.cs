using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;


        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private void UpdateQualityBy(Item item, int quality)
        {
            var newQuality = item.Quality + quality;

            if (newQuality > 50)
            {
                newQuality = 50;
            }
            else if (newQuality < 0)
            {
                newQuality = 0;
            }

            item.Quality = newQuality;
        }

        private void UpdateGenericItemQuality(Item item)
        {
            // regular items lose quality as normal, while conjured items lose quality twice as fast
            int decreaseMultiplier = item.Name.Contains("Conjured") ? 2 : 1;

            if (item.SellIn > 0)
            {
                UpdateQualityBy(item, -1 * decreaseMultiplier);
            }
            else
            {
                UpdateQualityBy(item, -2 * decreaseMultiplier);
            }
        }

        private void UpdateAgedBrieQuality(Item item)
        {
            if (item.SellIn > 0)
            {
                UpdateQualityBy(item, 1);
            }
            else
            {
                UpdateQualityBy(item, 2);
            }
        }

        private void UpdateBackstagePassesQuality(Item item)
        {
            if (item.SellIn > 10)
            {
                UpdateQualityBy(item, 1);
            }
            else if (item.SellIn > 5)
            {
                UpdateQualityBy(item, 2);
            }
            else if (item.SellIn > 0)
            {
                UpdateQualityBy(item, 3);
            }
            else
            {
                item.Quality = 0;
            }
        }

        private void UpdateSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn--;
            }
        }

        private void UpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    UpdateAgedBrieQuality(item);
                    break;
                case string name when name.StartsWith("Backstage passes"):
                    UpdateBackstagePassesQuality(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    // Do nothing
                    break;
                default:
                    UpdateGenericItemQuality(item);
                    break;
            }
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateSellIn(item);
                UpdateQuality(item);
            }
        }
    }
}