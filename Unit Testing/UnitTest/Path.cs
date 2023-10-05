namespace TreehouseDefense;

public class Path
{
    private MapLocation[] _pathLocations;

    public Path(MapLocation[] pathLocations)
    {
        _pathLocations = pathLocations;
    }

    public bool IsOnPath(MapLocation mapLocation)
    {
        return Array.IndexOf(_pathLocations, mapLocation) >= 0;
    }
}