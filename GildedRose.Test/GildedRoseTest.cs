using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void GiledRose_givenRegularItem_SellInAndQualityLower()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 14, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Multiple(() =>
            {
                Assert.That(Items[0].SellIn, Is.EqualTo(13));
                Assert.That(Items[0].Quality, Is.EqualTo(0));
            });
        }
    }
}
