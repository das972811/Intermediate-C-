namespace LearningLINQ;

public class Program
{
    public static void Main(string[] args)
    {
        // List<int> numbers = new List<int>() { 2, 4, 8, 16, 32, 64 };
        // List<int> _numbersGreaterThanTen = new List<int>();

        // IEnumerable<int> numbersGreaterThanTen = from number in numbers
        //                                             where number > 10
        //                                             select number;

        // Console.WriteLine(numbersGreaterThanTen.Count());

        var birds = new List<Bird>() {
            new Bird() { Name = "Cardinal", Color = "Red", Sightings = 3 },
            new Bird() { Name = "Dove", Color = "White", Sightings = 2 },
        };

        birds.Add( new Bird() { Name = "Robin", Color = "Red", Sightings = 5 } );
        birds.Add( new Bird() { Name = "Blue jay", Color = "Blue", Sightings = 1 } );

        var canary = new Bird() { Name = "Canary", Color = "Yellow", Sightings = 0 };
        birds.Add(canary);

        var anonymousBirds = from b in birds
                                    where b.Color == "Red"
                                    select new {b.Name, b.Color};

        var anonymousCrow = new { Name = "Crow", Color = "Black", Sightings = 11 };

        Console.WriteLine(anonymousCrow.GetType());


        var descendingBirdName = from b in birds orderby b.Name descending select b;
        var birdsByColor = from b in birds group b by b.Color;
        Console.WriteLine(birdsByColor);

        var learning = from b in birds
                        group b by b.Color into _birdsByColor
                        where _birdsByColor.Count() > 1
                        select new { Color = _birdsByColor.Key, Count = _birdsByColor.Count() };

        
    }
}