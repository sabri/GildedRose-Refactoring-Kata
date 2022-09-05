using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace csharp
{
    public class GildedRose
    {
        public const string AGED_BRIE = "Aged Brie";
        public const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public const string Conjured = "Conjured Mana Cake";
        public const int MaxQuality = 50;
         public const int BACKSTAGE_PASSES_THERESHOLD01 = 11;
       public  const int BACKSTAGE_PASSES_THERESHOL02 = 6;
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (IsRegular(item))
                {
                    HandleReqularItem(item);

                }
                else if (IsAgedBrie(item.Name))
                {
                    HandleIsAgedBrieItem(item);
                }
                else if (IsBackStagePasses(item.Name))
                {
                    HandleIsBackStageItem(item);
                }
                else if (IsSulFuares(item.Name))
                {
                    HandleIsSulFURAES(item);
                } else if (IsConjured(item.Name))
                {
                    HandleIsConjured(item);
                }
            }
        }

        private static  void HandleIsConjured(Item item)
        {
            item.SellIn--;
            item.Quality-=2;
        }

        private static void HandleIsSulFURAES(Item item)
        {
            item.SellIn--;
        }

        private static void HandleIsBackStageItem(Item item)
        {
            item.SellIn--;
            item.Quality++;
            if (item.SellIn < BACKSTAGE_PASSES_THERESHOLD01)
            {
                item.Quality++;
            }
            if (item.SellIn < BACKSTAGE_PASSES_THERESHOL02)
            {
                item.Quality++;
            }
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            if (item.Quality > MaxQuality)
            {
                item.Quality = MaxQuality;
            }
        }

        private static void HandleIsAgedBrieItem(Item item)
        {
            item.SellIn--;
            item.Quality++;
            if (item.SellIn <= 0)
            {
                item.Quality++;
            }
            if (item.Quality > MaxQuality)
            {
                item.Quality = MaxQuality;
            }
        }

        private static void HandleReqularItem(Item item)
        {
            item.SellIn--;
            item.Quality--;
            if (item.SellIn <= 0)
            {
                item.Quality--;
            }
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }

        private static bool IsRegular(Item item)
        {
            return !(IsAgedBrie(item.Name) || IsBackStagePasses(item.Name) || IsSulFuares(item.Name)|| IsConjured(item.Name));
        }

        private static bool IsAgedBrie(string name)
        {
            return name == AGED_BRIE;
        }
        private static bool IsBackStagePasses(string name)
        {
            return name == BACKSTAGE_PASSES;
        }
        private static bool IsSulFuares(string name)
        {
            return name == SULFURAS;
        }
        private static bool IsConjured(string name)
        {
            return name == Conjured;
        }
    }
}
