using TreehouseDefense;

namespace TestUnitTest;

public class PointTests
{
    [Fact]
    public void PointTest()
    {
        int x = 5, y = 6;

        Point point = new(x, y);

        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Fact]
    public void DistanceToTest()
    {
        var point = new Point(3, 4);
        var target = new Point(0, 0);

        var expected = 5.0;

        var actual = target.DistanceTo(point);

        Assert.Equal(expected, actual);
    }
}