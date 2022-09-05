using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest

    {
        private Item DealingWithItems(string name, int sellin, int quality){
            IList<Item> items = new List<Item>() { new Item { Name=name, Quality=quality,SellIn=sellin} };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();
            return items[0];
        }
        [Test]
        public void GiledRose_givenRegularItem_SellInAndQualityLower()
        {
            Item item = DealingWithItems("foo", 15, 25);
          
            Assert.Multiple(() =>
            {
                Assert.That(item.SellIn, Is.EqualTo(14));
                Assert.That(item.Quality, Is.EqualTo(24));
            });
        }
        //Once the sell by date has passed, Quality degrades twice as fast
        [Test]
        public void GiledRose_givenRegularItem_PastSellInAndQualityDegradstwiceAsFast()
        {
            Item item = DealingWithItems("foo", 0, 25);

                Assert.That(item.Quality, Is.EqualTo(23));
        }
        //The Quality of an item is never negative
        [Test]
        public void GiledRose_givenRegularItem_QualityNeverNegative()
        {
            Item item = DealingWithItems("foo", -1, 0);
                Assert.That(item.Quality, Is.EqualTo(0));
        }
        //"Aged Brie" actually increases in Quality the older it gets
        [Test]
        public void GiledRose_givenAgedBrie_QualityIncreased()
        {
            Item item = DealingWithItems(GildedRose.AGED_BRIE, 15, 25);
            Assert.That(item.Quality, Is.EqualTo(26));
        }
        //he Quality of an item is never more than 50
        [Test]
        public void GiledRose_givenAgedBrie_QualityNeverMoreThan50()
        {
            Item item = DealingWithItems(GildedRose.AGED_BRIE, 15, 49);
            Assert.That(item.Quality, Is.EqualTo(50));
        }
        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        [Test]
        public void GiledRose_givenSulfuras_QualityNeverdecreases()
        {
            Item item = DealingWithItems(GildedRose.SULFURAS, 15, 80);
            Assert.That(item.Quality, Is.EqualTo(80));
        }
        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
        [Test]
        public void GiledRose_givenSulfurasPastSellin_QualityVNeverdecreases()
        {
            Item item = DealingWithItems(GildedRose.SULFURAS, -1, 80);
            Assert.That(item.Quality, Is.EqualTo(80));
        }
        //"Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
        [Test]
        public void GiledRose_givenBackstage_QualityIncreases()
        {
            Item item = DealingWithItems(GildedRose.BACKSTAGE_PASSES, 15, 26);
            Assert.That(item.Quality, Is.EqualTo(27));
        }
        //	Quality increases by 2 when there are 10 days or less
        [Test]
        public void GiledRose_givenBackstageDaysOut10_QualityIncreaseBy2()
        {
            Item item = DealingWithItems(GildedRose.BACKSTAGE_PASSES, 10, 26);
            Assert.That(item.Quality, Is.EqualTo(28));
        }
        //	by 3 when there are 5 days 
        [Test]
        public void GiledRose_givenBackstageDaysOut5_QualityIncreaseBy3()
        {
            Item item = DealingWithItems(GildedRose.BACKSTAGE_PASSES, 5, 26);
            Assert.That(item.Quality, Is.EqualTo(29));
        }
        //  Quality drops to 0 after the concert 
        [Test]
        public void GiledRose_givenBackstage_QualityDropTo0()
        {
            Item item = DealingWithItems(GildedRose.BACKSTAGE_PASSES, 0, 26);
            Assert.That(item.Quality, Is.EqualTo(0));
        }
        //"Conjured" items degrade in Quality twice as fast as normal items
        [Test]
        public void GiledRose_givenConjured_QualityDegradstwiceAsFast()
        {
            Item item = DealingWithItems("Conjured Mana Cake", 0, 26);
            Assert.That(item.Quality, Is.EqualTo(24));
        }
    }
}
