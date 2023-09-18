namespace Treehouse.Common;

public static class StringExtension
{
    public static string[] CSplit(this string? @this, char sepearator, int count)
    {
        if (@this == null)
        {
            throw new ArgumentNullException(nameof(@this));
        }

        return @this.Split(new[] { sepearator }, count);
    }

    public static bool IsNullOrEmpty(this string? @this)
    {
        return string.IsNullOrEmpty(@this);
    }
}