using System.Collections.Generic;
using Xunit;

namespace Team.Codium.LegacyTraining.GildedRoseCharacterizationTesting.Tests
{
    public class GildedRoseTest
    {
        [Fact]
        public void xxx()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Book", SellIn = 10, Quality = 5 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.Equal("Book", Items[0].Name);
        }
    }
}
