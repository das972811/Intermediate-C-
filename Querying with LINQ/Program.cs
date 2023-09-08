using System.Dynamic;
using BirdLinq;

namespace LearningLINQ;

public class Program
{
    public static void Main(string[] args)
    {
        List<Bird> birds = new()
        {
            new() { Name = "Cardinal", Color = "Red", Sightings = 3 },
            new() { Name = "Dove", Color = "White", Sightings = 2 },
            new() { Name = "Robin", Color = "Red", Sightings = 5 },
            new() { Name = "Blue Jay", Color = "Blue", Sightings = 1 },
            new() { Name =  "Canary", Color = "Yellow", Sightings = 0 }
        };

    }

}