using System.Dynamic;
using BirdLinq;

namespace LearningLINQ;

public class Program
{
    // delegate void SayGreeting(string name);

    // public static void SayHello(string name)
    // {
    //     Console.WriteLine($"Hello, {name}");
    // }

    // public static void SayGoodbye(string name)
    // {
    //     Console.WriteLine($"Later, {name}");
    // }

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



    public static void ConversionOperators(IEnumerable<Bird> birds)
    {
        var redBirdList = birds.Where(b => b.Color == "Red").ToList();
        var redBirdArray = birds.Where(b => b.Color == "Red").ToArray();
    }

    public static void GenerationOperators()
    {
        var colors = new List<string>() { "Red", "Blue", "Purple" };
        var newColors = new List<string>() { "Pink", "Blue", "Teal" };

        var numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var generateNumber = Enumerable.Range(0, 10);
        var blankBirds = Enumerable.Repeat(new Bird(), 5);

        var emptyBirds = Enumerable.Empty<Bird>();

        var emptyNumbers = Enumerable.Empty<int>();
        emptyNumbers.DefaultIfEmpty();
    }

    public static void SetOperators(IEnumerable<Bird> birds, IEnumerable<string> colors)
    {
        colors.Except(birds.Select(b => b.Color).Distinct());
        birds.Select(b => b.Color).Distinct();
    }

    public static void Aggregates(IEnumerable<Bird> birds)
    {
        var queryBirds = birds.GroupBy( b => b.Color );
        birds.GroupBy(b => b.Color).Select(g => new { Color = g.Key, Count = g.Count() });

        birds.Sum(b => b.Sightings);
        birds.GroupBy(b =>  b.Color).Select(g => new { Color = g.Key, Sightings = g.Sum( b => b.Sightings ) });
        birds.Average(b => b.Sightings);
        birds.Min(b => b.Sightings);
    }

    public static void MethodJoinLinq(IEnumerable<Bird> birds, IEnumerable<string> colors)
    {

        var favoriteBirds = from b in birds join c in colors on b.Color equals c select b;

        favoriteBirds = birds.Join(
            colors,
            b => b.Color,
            c => c,
            (bird, color) => bird
        );

        var anonymousFavoriteBirds = birds.Join
        (
            colors,
            b => b.Color,
            c => c,
            (bird, color) => new { Color = color, Bird = bird }
        );

        var groupedBirds = colors.GroupJoin(
            birds,
            c => c,
            b => b.Color,
            (color, bird) => new { Color = color, Birds = bird }
        );

        var groupedBirdsTest = groupedBirds.Select( g => g.Color );
        var groupedBirdsTeste = groupedBirds.SelectMany( g => g.Birds );



        // var test = birds.Any( b => b.Name == "Corw" );
        // var sparrow = new Bird { Name = "Sparrow", Color = "Brown" };
        // Console.WriteLine(birds.Contains(sparrow));

        var queryBirds = birds.Where( b => b.Name == "Canary" ).Single();
        queryBirds = birds.SingleOrDefault(b => b.Name == "Canadry" );

        birds.OrderBy( b => b.Name.Length).Skip(3).Take(3);
        birds.OrderBy( b => b.Name.Length ).TakeWhile( b => b.Name.Length < 6 );



        Console.WriteLine(queryBirds);

    }

    public static void MethdLinq(List<Bird> birds)
    {
        IEnumerable<Bird> queryBirds = birds.Where( b => b.Color == "Red" );
        IEnumerable<Bird> orderedBirds = birds.OrderBy( b => b.Color );
        queryBirds = birds
                        .Where ( b => b.Color == "Red" )
                        .OrderBy( b => b.Name )
                        .ThenBy( b => b.Sightings );

        var anonymousBirds = birds.Select( b => new { b.Name, b.Color } );
    }

    public static void Delegates()
    {
        Action<string> sayGreeting;
        
        Func<string, string> converstate = message =>
        {
            Console.WriteLine(message);
            string input = Console.ReadLine()!;
            return input;
        };

        string input = converstate("What's your name?");
        

        sayGreeting = (greeting) =>
        {
            Console.WriteLine(string.Format(greeting, input));
        };

        sayGreeting("Hello, {0}");
        converstate("Nice to see you!");
        converstate("Are you doing well?");
        sayGreeting("Later, {0}");


        // Anonymous method
        // sayGreeting = delegate(string name)
        // {
        //     Console.WriteLine($"Hello, {name}");
        // };
        // sayGreeting("Diego");
    }
}