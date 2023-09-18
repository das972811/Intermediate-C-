using static GenericsDemo.EnumerableCompositor;

public class Program
{
    public static void Main(string[] args)
    {
        var list1 = new List<int> { 1, 2, 3, 4, 5 };
        var list2 = new List<int> { 2, 4, 6, 8, 10 };
        var set1 = new HashSet<int> { 3, 6, 9, 12, 15 };
        var array1 = new [] { 4, 8, 12, 16, 20 };

        int numOdd = Create(list1, list2, set1, array1).Count(x => IsOdd(x));
        Console.WriteLine(numOdd);

        HashSet<int> set = Create(list1, list2, set1, array1).To<HashSet<int>>();

        Console.WriteLine(set);

        // var ec = new EnumerableCompositor<int>(new IEnumerable<int>[] { list1, list2, set1, array1 });
        // var ec = new EnumerableCompositor<int> { list1, list2, set1, array1 };
        // IEnumerable<int> firstThree = Utils.Take(list1, 3);
    }


    public static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
}