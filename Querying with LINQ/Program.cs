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

        // var test = birds.Any( b => b.Name == "Corw" );
        // var sparrow = new Bird { Name = "Sparrow", Color = "Brown" };
        // Console.WriteLine(birds.Contains(sparrow));

        var queryBirds = birds.Where( b => b.Name == "Canary" ).Single();
        queryBirds = birds.SingleOrDefault(b => b.Name == "Canadry" );

        Console.WriteLine(queryBirds);

    }

    public void MethdLinq(List<Bird> birds)
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