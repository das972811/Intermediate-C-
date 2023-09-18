using Treehouse.Collection.Generic;
using Treehouse.Common;
using static Treehouse.Common.StringExtension;

public class Program
{
    public static void Main(string[] args)
    {
        string? myString = null;

        myString.IsNullOrEmpty();
        myString.CSplit(',', 3);

        var synonymsForBest = new List<string>
        {
            "best",
            "finest",
            "greatest",
            "top",
            "foremost",
            "leading",
            "most excellent",
            "preeminent",
            "premier",
            "chief",
            "supreme",
            "unrivaled",
            "ultimate",
            "perfect",
            "incomparable",
            "ideal"
        };

        Console.WriteLine($"My dog Jojo is the {synonymsForBest.RandomItem()} do!");
    }
}