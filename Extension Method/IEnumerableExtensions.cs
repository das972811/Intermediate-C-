namespace Treehouse.Common;

public static class IEnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
    {
        return @this == null || !@this.Any();
    }

    public static bool IsEmpty<T>(this IEnumerable<T> @this)
    {
        return !@this.Any();
    }

    public static T FirstOr<T>(this IEnumerable<T> @this, Func<T, bool> predicate, Func<T> onOr)
    {
        if (@this == null)
        {
            throw new ArgumentNullException(nameof(@this));
        }

        T found = @this.FirstOrDefault(predicate)!;

        if (found.Equals(default(T)))
        {
            found = onOr();
        }

        return found;
    }
}