using System.Collections.Generic;

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
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != AGED_BRIE && Items[i].Name != BACKSTAGE_PASSES)
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != SULFURAS)
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < MaxQuality)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == BACKSTAGE_PASSES)
                        {
                            if (Items[i].SellIn < BACKSTAGE_PASSES_THERESHOLD01)
                            {
                                if (Items[i].Quality < MaxQuality)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < BACKSTAGE_PASSES_THERESHOL02)
                            {
                                if (Items[i].Quality < MaxQuality)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != SULFURAS)
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != AGED_BRIE)
                    {
                        if (Items[i].Name != BACKSTAGE_PASSES)
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != SULFURAS)
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < MaxQuality)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
