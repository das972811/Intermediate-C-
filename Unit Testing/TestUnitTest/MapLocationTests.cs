namespace TestUnitTest;

public class MapLocationTests
{
    [Fact]
    public void ShouldTrhowIfNotOnMap()
    {
        Map map = new(3, 3);
        var exception = Assert.Throws<OutOfBoundsException>(() => new MapLocation(3, 3, map));
    }

    [Fact]
    public void InRangeOfWithRange1()
    {
        var map = new Map(3, 3);
        var target = new MapLocation(0, 0, map);
        Assert.True(target.InRangeOf(new MapLocation(0, 2, map), 1));
    }
}