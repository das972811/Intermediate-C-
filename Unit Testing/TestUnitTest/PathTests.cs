namespace TestUnitTest;

public class PathTests
{
    private readonly Map _map3x3;
    private readonly MapLocation[] _pathLocations3;

    private readonly TreehouseDefense.Path _path3;

    public PathTests()
    {
        _map3x3 = new Map(3, 3);

        _pathLocations3 = new MapLocation[]
        {
            new(0, 1, _map3x3),
            new(1, 1, _map3x3),
            new(2, 1, _map3x3)
        };

        _path3 = new TreehouseDefense.Path(_pathLocations3);
    }

    [Fact]
    public void MapLocationIsOnPath()
    {
        var target = _path3;
        Assert.True(target.IsOnPath(new MapLocation(0, 1, _map3x3)));
    }

    [Fact]
    public void MapLocationIsNotOnPath()
    {
        var target = _path3;
        Assert.False(target.IsOnPath(new MapLocation(0, 3, _map3x3)));
    }
}