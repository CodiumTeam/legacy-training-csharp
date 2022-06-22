using Team.Codium.LegacyTraining.GildeRoseGoldenMaster;

namespace test;

public class GildedRoseTest
{
    [Fact]
    public void Test1()
    {
        new GildedRose(new List<Item>()).UpdateQuality();
    }
}