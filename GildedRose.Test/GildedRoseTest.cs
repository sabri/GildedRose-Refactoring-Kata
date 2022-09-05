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
                Assert.That(item.Quality, Is.EqualTo(25));
            });
        }
        [Test]
        public void GiledRose_givenRegularItem_PastSellInAndQualityDegradstwiceAsFast()
        {
            Item item = DealingWithItems("foo", 0, 25);
            Assert.Multiple(() =>
            {
                Assert.That(item.SellIn, Is.EqualTo(0));
                Assert.That(item.Quality, Is.EqualTo(23));
            });
        }
    }
}
