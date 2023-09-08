namespace BirdLinq;

public class BirdLinq
{
    public static void QueryBirds()
    {
        List<Bird> birds = new()
        {
            new() { Name = "Cardinal", Color = "Red", Sightings = 3 },
            new() { Name = "Dove", Color = "White", Sightings = 2 },
            new() { Name = "Robin", Color = "Red", Sightings = 5 },
            new() { Name = "Blue Jay", Color = "Blue", Sightings = 1 },
            new() { Name =  "Canary", Color = "Yellow", Sightings = 0 }
        };

        var orderedBirds = from b in birds
                        orderby b.Name, b.Sightings descending
                        select new { b.Name, b.Sightings };

        var birdsByColor = from b in birds
                            group b by b.Color;
        
        var birdsByColorTest = from b in birds
                                group b by b.Color into birdsByColorT
                                where birdsByColorT.Count() > 1
                                select new { Color = birdsByColorT.Key, Count = birdsByColor.Count() };

        foreach (var bird in birdsByColor)
        {
            Console.WriteLine(bird.Key + " "  + bird.Count());
        }
    }

    public static void QueryBirdsLinq(List<Bird> birds)
    {
        IEnumerable<Bird> RedBirds = from bird in birds
                                    where bird.Color == "Red"
                                    select bird;

        var anonymousRedBirds = from b in birds
                    where b.Color == "Red"
                    select new { BirdName = b.Name, BirdColor = b.Color };
    }

    public static void LearningLinq()
    {
        List<int> numbers = new() { 2, 4, 8, 16, 32, 64 };
        IEnumerable<int> numbersGreaterThanTen = from number in numbers
                            where number > 10
                            select number;
    }
}