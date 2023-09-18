namespace GenericsDemo;
public class Utils
{
    public static IEnumerable<T> Take<T>(IEnumerable<T> source, int n)
    {
        int i = 0;

        foreach(var item in source)
        {
            yield return item;

            if (++i == n)
            {
                yield break;
            }
        }
    }

    // Generic Type Constraints
    public static T Min<T>(T item1, T item2) where T : IComparable<T>
    {
        return (item1.CompareTo(item2) < 0) ? item1 : item2;
    }
}