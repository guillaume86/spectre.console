namespace Spectre.Console;

/// <summary>
/// Contains extension methods for <see cref="string"/>.
/// </summary>
internal static class InternalStringExtensions
{
    internal static string Repeat(this string text, int count)
    {
        if (text is null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (count <= 0)
        {
            return string.Empty;
        }

        if (count == 1)
        {
            return text;
        }

        return string.Concat(Enumerable.Repeat(text, count));
    }

    private static Func<string, string, Style?, string> _hightlightFn =
        (Func<string, string, Style?, string>)Delegate.CreateDelegate(typeof(Func<string, string, Style?, string>),
            typeof(Spectre.Console.StringExtensions)
            .GetMethod("Highlight", BindingFlags.NonPublic | BindingFlags.Static));

    internal static string Highlight(this string value, string searchText, Style? highlightStyle)
    {
        return _hightlightFn(value, searchText, highlightStyle);
    }
}