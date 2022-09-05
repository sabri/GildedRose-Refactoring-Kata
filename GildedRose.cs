using System.Collections.Generic;
using System.Linq.Expressions;

namespace csharp
{
    public class GildedRose
    {
        public const string AGED_BRIE = "Aged Brie";
        public const string BACKSTAGE_PASSES = "Backstage passes to a TAFKAL80ETC concert";
        public const string SULFURAS = "Sulfuras, Hand of Ragnaros";
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
                if (!(IsAgedBrie(item.Name)|| IsBackStagePasses(item.Name)))
                {
                    if (item.Quality > 0)
                    {
                        if (!IsSulFuares(item.Name))
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality++;

                        if (IsBackStagePasses(item.Name))
                        {
                            if (item.SellIn < BACKSTAGE_PASSES_THERESHOLD01)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < BACKSTAGE_PASSES_THERESHOL02)
                            {
                                if (item.Quality < MaxQuality)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (!IsSulFuares(item.Name))
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (!IsAgedBrie(item.Name))
                    {
                        if (!IsBackStagePasses(item.Name))
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != SULFURAS)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality=0;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaxQuality)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
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
    }
}
