namespace SunamoExceptions;

public sealed partial class Exceptions
{

    /// <summary>
    /// String contains unallowed substrings.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="input">The input.</param>
    /// <param name="unallowedStrings">The unallowed strings.</param>
    /// <returns>The string contains unallowed substrings result.</returns>
    public static string? StringContainsUnallowedSubstrings(string before, string input, params string[] unallowedStrings)
    {
        List<string> foundedUnallowed = [];
        foreach (var item in unallowedStrings)
            if (input.Contains(item))
                foundedUnallowed.Add(item);
        return foundedUnallowed.Count > 0 ? CheckBefore(before) + input + " contains unallowed chars: " + string.Join(string.Empty, unallowedStrings) : null;
    }

    /// <summary>
    /// Is null.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable.</param>
    /// <returns>The is null result.</returns>
    public static string? IsNull(string before, string variableName, object? variable)
    {
        return variable == null ? CheckBefore(before) + variableName + " " + "is null" + "." : null;
    }

    /// <summary>
    /// Not implemented case.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="notImplementedName">The not implemented name.</param>
    /// <returns>The not implemented case result.</returns>
    public static string? NotImplementedCase(string before, object notImplementedName)
    {
        var fr = string.Empty;
        if (notImplementedName != null)
        {
            fr = " for ";
            if (notImplementedName.GetType() == typeof(Type))
                fr += ((Type)notImplementedName).FullName;
            else
                fr += notImplementedName.ToString();
        }

        return CheckBefore(before) + "Not implemented case" + fr + " . public program error. Please contact developer" + ".";
    }
}