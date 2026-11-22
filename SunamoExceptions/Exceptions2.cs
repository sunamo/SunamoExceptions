namespace SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
    /// <summary>
    /// Not contains.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="originalText">The original text.</param>
    /// <param name="shouldContains">The should contains.</param>
    /// <returns>The not contains result.</returns>
    public static string? NotContains(string before, string originalText, params string[] shouldContains)
    {
        List<string> notContained = [];
        foreach (var requiredText in shouldContains)
            if (!originalText.Contains(requiredText))
                notContained.Add(requiredText);
        return notContained.Count == 0 ? null : CheckBefore(before) + "Original text dont contains: " + string.Join(",", notContained) + ". Original text: " + originalText;
    }

    /// <summary>
    /// Has not key dictionary key value.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameDict">The name dict.</param>
    /// <param name="qsDict">The qs dict.</param>
    /// <param name="remains">The remains.</param>
    /// <returns>The has not key dictionary key value result.</returns>
    public static string? HasNotKeyDictionary<Key, Value>(string before, string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        return !qsDict.ContainsKey(remains) ? CheckBefore(before) + nameDict + " does not contains key " + remains : null;
    }

    /// <summary>
    /// Is empty.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="folders">The folders.</param>
    /// <param name="colName">The col name.</param>
    /// <param name="additionalMessage">The additional message.</param>
    /// <returns>The is empty result.</returns>
    public static string? IsEmpty(string before, IEnumerable folders, string colName, string additionalMessage = "")
    {
        return !folders.OfType<object>().Any() ? CheckBefore(before) + colName + " has no elements. " + additionalMessage : null;
    }

    /// <summary>
    /// Uri format.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="url">The url.</param>
    /// <param name="uhIsUri">The uh is uri.</param>
    /// <returns>The uri format result.</returns>
    public static string? UriFormat(string before, string url, Func<string, bool> uhIsUri)
    {
        if (uhIsUri(url))
        {
            return null;
        }

        return CheckBefore(before) + "Is not correct url format: " + url;
    }

    /// <summary>
    /// Is windows path format.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="input">The input.</param>
    /// <param name="isWindowsPathFormat">The is windows path format.</param>
    /// <returns>The is windows path format result.</returns>
    public static string? IsWindowsPathFormat(string before, string input, Func<string, bool> isWindowsPathFormat)
    {
        if (isWindowsPathFormat(input))
            return CheckBefore(before) + input + "is path but only key is expected";
        return null;
    }

    /// <summary>
    /// Is not windows path format.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <param name="raiseIsNotWindowsPathFormat">The raise is not windows path format.</param>
    /// <param name="SunamoFileSystem_IsWindowsPathFormat">The sunamo file system is windows path format.</param>
    /// <returns>The is not windows path format result.</returns>
    public static string? IsNotWindowsPathFormat(string before, string argName, string argValue, bool raiseIsNotWindowsPathFormat, Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        if (raiseIsNotWindowsPathFormat)
        {
            var badFormat = !SunamoFileSystem_IsWindowsPathFormat(argValue);
            if (badFormat)
                return CheckBefore(before) + " " + argName + " is not in Windows path format";
        }

        return null;
    }

    /// <summary>
    /// Was already initialized.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <returns>The was already initialized result.</returns>
    public static string WasAlreadyInitialized(string before)
    {
        return before + " was already initialized!";
    }

    /// <summary>
    /// Different count in lists.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="namefc">The namefc.</param>
    /// <param name="countfc">The countfc.</param>
    /// <param name="namesc">The namesc.</param>
    /// <param name="countsc">The countsc.</param>
    /// <returns>The different count in lists result.</returns>
    public static string? DifferentCountInLists(string before, string namefc, int countfc, string namesc, int countsc)
    {
        if (countfc != countsc)
            return CheckBefore(before) + " different count elements in collection" + " " + string.Concat(namefc + "-" + countfc) + " vs. " + string.Concat(namesc + "-" + countsc);
        return null;
    }

    /// <summary>
    /// First letter is not upper.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="text">The text.</param>
    /// <returns>The first letter is not upper result.</returns>
    public static string? FirstLetterIsNotUpper(string before, string text)
    {
        return text.Length == 0 ? null : char.IsLower(text[0]) ? CheckBefore(before) + "First letter is not upper: " + text : null;
    }

    /// <summary>
    /// Key not found t u.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="en">The en.</param>
    /// <param name="dictName">The dict name.</param>
    /// <param name="key">The key.</param>
    /// <returns>The key not found t u result.</returns>
    public static string? KeyNotFound<T, U>(string before, IDictionary<T, U> en, string dictName, T key)
    {
        return !en.ContainsKey(key) ? CheckBefore(before) + key + " is not exists in dictionary" + " " + dictName : null;
    }

    /// <summary>
    /// Duplicated elements.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="duplicatedElements">The duplicated elements.</param>
    /// <param name="message">The message.</param>
    /// <returns>The duplicated elements result.</returns>
    public static string? DuplicatedElements(string before, string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return duplicatedElements.Count != 0 ? CheckBefore(before) + $"Duplicated elements in {nameOfVariable} list: " + string.Join(",", duplicatedElements) + " " + message : null;
    }

    /// <summary>
    /// Zero or more than one.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="list">The list.</param>
    /// <returns>The zero or more than one result.</returns>
    public static string? ZeroOrMoreThanOne(string before, string nameOfVariable, List<string> list)
    {
        return list.Count == 0 || list.Count > 1 ? CheckBefore(before) + $"{list.Count} elements in {nameOfVariable} which is zero or more than one" : null;
    }

    /// <summary>
    /// Is not positive number.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="n">The n.</param>
    /// <returns>The is not positive number result.</returns>
    public static string? IsNotPositiveNumber(string before, string nameOfVariable, int? n)
    {
        return !n.HasValue ? CheckBefore(before) + nameOfVariable + " is not int" : n.Value > 0 ? null : CheckBefore(before) + nameOfVariable + " is int but not > 0";
    }

    /// <summary>
    /// Check back slash end.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="r">The r.</param>
    /// <returns>The check back slash end result.</returns>
    public static string? CheckBackSlashEnd(string before, string r)
    {
        if (!r.EndsWith("\\"))
            return CheckBefore(before) + " " + r + " don't end with \\";
        return null;
    }

    internal static string? FolderDoesNotExists(string before, string folder, string additionalInfo)
    {
        if (!Directory.Exists(folder))
        {
            return before + $"Folder {folder} does not exists. {additionalInfo}";
        }

        return null;
    }
}
