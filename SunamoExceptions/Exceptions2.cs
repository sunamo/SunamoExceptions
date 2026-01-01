namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
    /// <summary>
    /// Checks if a string does not contain required substrings.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="originalText">The original text to check.</param>
    /// <param name="shouldContains">The substrings that should be contained.</param>
    /// <returns>An error message if any required substring is missing, otherwise null.</returns>
    public static string? NotContains(string before, string originalText, params string[] shouldContains)
    {
        List<string> notContained = [];
        foreach (var requiredText in shouldContains)
            if (!originalText.Contains(requiredText))
                notContained.Add(requiredText);
        return notContained.Count == 0 ? null : CheckBefore(before) + "Original text dont contains: " + string.Join(",", notContained) + ". Original text: " + originalText;
    }

    /// <summary>
    /// Checks if a dictionary does not contain a specified key.
    /// </summary>
    /// <typeparam name="Key">The type of the dictionary key.</typeparam>
    /// <typeparam name="Value">The type of the dictionary value.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameDict">The name of the dictionary.</param>
    /// <param name="qsDict">The dictionary to check.</param>
    /// <param name="remains">The key to check for.</param>
    /// <returns>An error message if the key is not found, otherwise null.</returns>
    public static string? HasNotKeyDictionary<Key, Value>(string before, string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        return !qsDict.ContainsKey(remains) ? CheckBefore(before) + nameDict + " does not contains key " + remains : null;
    }

    /// <summary>
    /// Checks if a collection is empty.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="folders">The collection to check.</param>
    /// <param name="colName">The name of the collection.</param>
    /// <param name="additionalMessage">Additional message to append.</param>
    /// <returns>An error message if the collection is empty, otherwise null.</returns>
    public static string? IsEmpty(string before, IEnumerable folders, string colName, string additionalMessage = "")
    {
        return !folders.OfType<object>().Any() ? CheckBefore(before) + colName + " has no elements. " + additionalMessage : null;
    }

    /// <summary>
    /// Checks if a URL is in valid URI format.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="url">The URL to check.</param>
    /// <param name="uhIsUri">Function to validate URI format.</param>
    /// <returns>An error message if the URL format is invalid, otherwise null.</returns>
    public static string? UriFormat(string before, string url, Func<string, bool> uhIsUri)
    {
        if (uhIsUri(url))
        {
            return null;
        }

        return CheckBefore(before) + "Is not correct url format: " + url;
    }

    /// <summary>
    /// Checks if a string is in Windows path format when it shouldn't be.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="isWindowsPathFormat">Function to check Windows path format.</param>
    /// <returns>An error message if the input is a path when only a key is expected, otherwise null.</returns>
    public static string? IsWindowsPathFormat(string before, string input, Func<string, bool> isWindowsPathFormat)
    {
        if (isWindowsPathFormat(input))
            return CheckBefore(before) + input + "is path but only key is expected";
        return null;
    }

    /// <summary>
    /// Checks if a string is not in Windows path format.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="argName">The argument name.</param>
    /// <param name="argValue">The argument value to check.</param>
    /// <param name="raiseIsNotWindowsPathFormat">Whether to raise the check.</param>
    /// <param name="SunamoFileSystem_IsWindowsPathFormat">Function to check Windows path format.</param>
    /// <returns>An error message if the format is invalid, otherwise null.</returns>
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
    /// Creates an error message indicating that something was already initialized.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <returns>An error message.</returns>
    public static string WasAlreadyInitialized(string before)
    {
        return before + " was already initialized!";
    }

    /// <summary>
    /// Checks if two collections have different element counts.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="namefc">The name of the first collection.</param>
    /// <param name="countfc">The count of the first collection.</param>
    /// <param name="namesc">The name of the second collection.</param>
    /// <param name="countsc">The count of the second collection.</param>
    /// <returns>An error message if counts differ, otherwise null.</returns>
    public static string? DifferentCountInLists(string before, string namefc, int countfc, string namesc, int countsc)
    {
        if (countfc != countsc)
            return CheckBefore(before) + " different count elements in collection" + " " + string.Concat(namefc + "-" + countfc) + " vs. " + string.Concat(namesc + "-" + countsc);
        return null;
    }

    /// <summary>
    /// Checks if the first letter of a string is not uppercase.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="parameter">The string to check.</param>
    /// <returns>An error message if the first letter is not uppercase, otherwise null.</returns>
    public static string? FirstLetterIsNotUpper(string before, string parameter)
    {
        return parameter.Length == 0 ? null : char.IsLower(parameter[0]) ? CheckBefore(before) + "First letter is not upper: " + parameter : null;
    }

    /// <summary>
    /// Checks if a key is not found in a dictionary.
    /// </summary>
    /// <typeparam name="T">The type of the dictionary key.</typeparam>
    /// <typeparam name="U">The type of the dictionary value.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="en">The dictionary to check.</param>
    /// <param name="dictName">The name of the dictionary.</param>
    /// <param name="key">The key to find.</param>
    /// <returns>An error message if the key is not found, otherwise null.</returns>
    public static string? KeyNotFound<T, U>(string before, IDictionary<T, U> en, string dictName, T key)
    {
        return !en.ContainsKey(key) ? CheckBefore(before) + key + " is not exists in dictionary" + " " + dictName : null;
    }

    /// <summary>
    /// Checks if a list contains duplicated elements.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameOfVariable">The variable name.</param>
    /// <param name="duplicatedElements">The list of duplicated elements.</param>
    /// <param name="message">Additional message.</param>
    /// <returns>An error message if duplicates are found, otherwise null.</returns>
    public static string? DuplicatedElements(string before, string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return duplicatedElements.Count != 0 ? CheckBefore(before) + $"Duplicated elements in {nameOfVariable} list: " + string.Join(',', [..duplicatedElements]) + " " + message : null;
    }

    /// <summary>
    /// Checks if a list has zero or more than one element.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameOfVariable">The variable name.</param>
    /// <param name="list">The list to check.</param>
    /// <returns>An error message if the list has zero or more than one element, otherwise null.</returns>
    public static string? ZeroOrMoreThanOne(string before, string nameOfVariable, List<string> list)
    {
        return list.Count == 0 || list.Count > 1 ? CheckBefore(before) + $"{list.Count} elements in {nameOfVariable} which is zero or more than one" : null;
    }

    /// <summary>
    /// Checks if a value is not a positive number.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameOfVariable">The variable name.</param>
    /// <param name="n">The value to check.</param>
    /// <returns>An error message if the value is not a positive number, otherwise null.</returns>
    public static string? IsNotPositiveNumber(string before, string nameOfVariable, int? n)
    {
        return !n.HasValue ? CheckBefore(before) + nameOfVariable + " is not int" : n.Value > 0 ? null : CheckBefore(before) + nameOfVariable + " is int but not > 0";
    }

    /// <summary>
    /// Checks if a string ends with a backslash.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="r">The string to check.</param>
    /// <returns>An error message if the string doesn't end with a backslash, otherwise null.</returns>
    public static string? CheckBackSlashEnd(string before, string r)
    {
        if (!r.EndsWith('\\'))
            return CheckBefore(before) + " " + r + " don't end with \\";
        return null;
    }

    /// <summary>
    /// Checks if a folder does not exist.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="folder">The folder path to check.</param>
    /// <param name="additionalInfo">Additional information.</param>
    /// <returns>An error message if the folder doesn't exist, otherwise null.</returns>
    internal static string? FolderDoesNotExists(string before, string folder, string additionalInfo)
    {
        if (!Directory.Exists(folder))
        {
            return before + $"Folder {folder} does not exists. {additionalInfo}";
        }

        return null;
    }
}
