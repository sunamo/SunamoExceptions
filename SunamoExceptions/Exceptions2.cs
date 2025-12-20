// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoExceptions;
// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
    public static string? NotContains(string before, string originalText, params string[] shouldContains)
    {
        List<string> notContained = [];
        foreach (var requiredText in shouldContains)
            if (!originalText.Contains(requiredText))
                notContained.Add(requiredText);
        return notContained.Count == 0 ? null : CheckBefore(before) + "Original text dont contains: " + string.Join(",", notContained) + ". Original text: " + originalText;
    }

    public static string? HasNotKeyDictionary<Key, Value>(string before, string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        return !qsDict.ContainsKey(remains) ? CheckBefore(before) + nameDict + " does not contains key " + remains : null;
    }

    public static string? IsEmpty(string before, IEnumerable folders, string colName, string additionalMessage = "")
    {
        return !folders.OfType<object>().Any() ? CheckBefore(before) + colName + " has no elements. " + additionalMessage : null;
    }

    public static string? UriFormat(string before, string url, Func<string, bool> uhIsUri)
    {
        if (uhIsUri(url))
        {
            return null;
        }

        return CheckBefore(before) + "Is not correct url format: " + url;
    }

    public static string? IsWindowsPathFormat(string before, string input, Func<string, bool> isWindowsPathFormat)
    {
        if (isWindowsPathFormat(input))
            return CheckBefore(before) + input + "is path but only key is expected";
        return null;
    }

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

    public static string WasAlreadyInitialized(string before)
    {
        return before + " was already initialized!";
    }

    public static string? DifferentCountInLists(string before, string namefc, int countfc, string namesc, int countsc)
    {
        if (countfc != countsc)
            return CheckBefore(before) + " different count elements in collection" + " " + string.Concat(namefc + "-" + countfc) + " vs. " + string.Concat(namesc + "-" + countsc);
        return null;
    }

    public static string? FirstLetterIsNotUpper(string before, string parameter)
    {
        return parameter.Length == 0 ? null : char.IsLower(parameter[0]) ? CheckBefore(before) + "First letter is not upper: " + parameter : null;
    }

    public static string? KeyNotFound<T, U>(string before, IDictionary<T, U> en, string dictName, T key)
    {
        return !en.ContainsKey(key) ? CheckBefore(before) + key + " is not exists in dictionary" + " " + dictName : null;
    }

    public static string? DuplicatedElements(string before, string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return duplicatedElements.Count != 0 ? CheckBefore(before) + $"Duplicated elements in {nameOfVariable} list: " + string.Join(',', [..duplicatedElements]) + " " + message : null;
    }

    public static string? ZeroOrMoreThanOne(string before, string nameOfVariable, List<string> list)
    {
        return list.Count == 0 || list.Count > 1 ? CheckBefore(before) + $"{list.Count} elements in {nameOfVariable} which is zero or more than one" : null;
    }

    public static string? IsNotPositiveNumber(string before, string nameOfVariable, int? n)
    {
        return !n.HasValue ? CheckBefore(before) + nameOfVariable + " is not int" : n.Value > 0 ? null : CheckBefore(before) + nameOfVariable + " is int but not > 0";
    }

    public static string? CheckBackSlashEnd(string before, string r)
    {
        if (!r.EndsWith('\\'))
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