using System.Drawing;

namespace TestUnitTest;

public class PointTests
{
    [Fact]
    public void PointTest()
    {
        int x = 5;
        int y = 6;

        Point point = new(x, y);

        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Fact]
    public void DistanceToTest()
    {
        Assert.True(true, "This test needs an implementation");
    }
}