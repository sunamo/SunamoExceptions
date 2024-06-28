namespace SunamoExceptions;

internal static class StringExtensions
{
    internal static string ToUnixLineEnding(this string s)
    {
        return s.ReplaceLineEndings("\n");
    }
}
