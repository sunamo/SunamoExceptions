namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
    /// <summary>
    /// Creates an error message when DateTime cannot be created with the specified parameters.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="year">The year value.</param>
    /// <param name="month">The month value.</param>
    /// <param name="day">The day value.</param>
    /// <param name="hour">The hour value.</param>
    /// <param name="minute">The minute value.</param>
    /// <param name="seconds">The seconds value.</param>
    /// <param name="ex">The exception that occurred.</param>
    /// <returns>An error message.</returns>
    public static string? CannotCreateDateTime(string before, int year, int month, int day, int hour, int minute, int seconds, Exception ex)
    {
        return CheckBefore(before) + $"Cannot create DateTime with: year: {year} month: {month} day: {day} hour: {hour} minute: {minute} seconds: {seconds} " + TextOfExceptions(ex);
    }

    /// <summary>
    /// Creates an error message when a folder cannot be moved.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="sourcePath">The source folder path.</param>
    /// <param name="destinationPath">The destination folder path.</param>
    /// <param name="ex">The exception that occurred.</param>
    /// <returns>An error message.</returns>
    public static string? CannotMoveFolder(string before, string sourcePath, string destinationPath, Exception ex)
    {
        return CheckBefore(before) + $"Cannot move folder from {sourcePath} to {destinationPath} " + TextOfExceptions(ex);
    }

    /// <summary>
    /// Creates an error message from an exception with an additional message.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="ex">The exception.</param>
    /// <param name="message">Additional message.</param>
    /// <returns>An error message.</returns>
    public static string? ExcAsArg(string before, Exception ex, string message)
    {
        return CheckBefore(before) + message + string.Empty + TextOfExceptions(ex);
    }

    /// <summary>
    /// Creates an error message for a method that is not implemented.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <returns>An error message.</returns>
    public static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }

    /// <summary>
    /// Creates an error message when something does not exist.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="what">What does not exist.</param>
    /// <returns>An error message.</returns>
    public static string? NotExists(string before, string what)
    {
        return CheckBefore(before) + what + " not exists";
    }

    /// <summary>
    /// Checks if a key already exists in a dictionary.
    /// </summary>
    /// <typeparam name="T">The type of the dictionary key.</typeparam>
    /// <typeparam name="U">The type of the dictionary value.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="dictionary">The dictionary to check.</param>
    /// <param name="key">The key to check for.</param>
    /// <param name="dictionaryName">The name of the dictionary.</param>
    /// <returns>An error message if the key exists, otherwise null.</returns>
    public static string? KeyAlreadyExists<T, U>(string before, Dictionary<T, U> dictionary, T key, string dictionaryName) where T : notnull
    {
        if (dictionary.ContainsKey(key))
        {
            return before + $"Key {key} already exists in {dictionaryName}";
        }

        return null;
    }

    /// <summary>
    /// Checks if a file already exists.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="path">The file path to check.</param>
    /// <returns>An error message if the file exists, otherwise null.</returns>
    public static string? FileAlreadyExists(string before, string path)
    {
        if (File.Exists(path))
        {
            return CheckBefore(before) + path + " already exists";
        }

        return null;
    }

    /// <summary>
    /// Checks if a list is null or empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The name of the variable.</param>
    /// <param name="list">The list to check.</param>
    /// <returns>An error message if the list is null or empty, otherwise null.</returns>
    public static string? ListNullOrEmpty<T>(string before, string variableName, IEnumerable<T>? list)
    {
        if (list == null)
        {
            return CheckBefore(before) + variableName + " is null";
        }

        bool isEmpty = true;
        foreach (var item in list)
        {
            isEmpty = false;
            break;
        }

        if (isEmpty)
        {
            return CheckBefore(before) + variableName + " is empty!";
        }

        return null;
    }

    /// <summary>
    /// Checks if a drive is locked by BitLocker.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="path">The path to check.</param>
    /// <param name="IsLockedByBitLocker">Function to check if a drive is locked.</param>
    /// <returns>An error message if the drive is locked, otherwise null.</returns>
    public static string? LockedByBitLocker(string before, string path, Func<char, bool> IsLockedByBitLocker)
    {
        if (IsLockedByBitLocker != null)
        {
            var driveLetter = path[0];
            if (IsLockedByBitLocker(driveLetter))
            {
                return CheckBefore(before) + $"Drive {driveLetter}:\\ is locked by BitLocker";
            }
        }

        return null;
    }

    /// <summary>
    /// Checks if a value is not a valid integer.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="what">Description of what should be an integer.</param>
    /// <param name="value">The value to check.</param>
    /// <returns>An error message if the value is not a valid integer, otherwise null.</returns>
    public static string? NotInt(string before, string what, int? value)
    {
        return !value.HasValue ? CheckBefore(before) + what + " is not with value " + value + " valid integer number" : null;
    }

    /// <summary>
    /// Checks if a list has an odd number of elements.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="listName">The name of the list.</param>
    /// <param name="list">The list to check.</param>
    /// <returns>An error message if the list has an odd number of elements, otherwise null.</returns>
    public static string? HasOddNumberOfElements(string before, string listName, ICollection list)
    {
        return list.Count % 2 == 1 ? CheckBefore(before) + listName + " has odd number of elements " + list.Count : null;
    }

    /// <summary>
    /// Checks if a file has the wrong extension.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="path">The file path.</param>
    /// <param name="requiredExt">The required extension.</param>
    /// <returns>An error message if the extension is wrong, otherwise null.</returns>
    public static string? WrongExtension(string before, string path, string requiredExt)
    {
        return System.IO.Path.GetExtension(path) != requiredExt ? CheckBefore(before) + path + "don't have " + requiredExt + " extension" : null;
    }

    /// <summary>
    /// Checks if a collection has the wrong number of elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="requireElements">The required number of elements.</param>
    /// <param name="nameCollection">The name of the collection.</param>
    /// <param name="collection">The collection to check.</param>
    /// <returns>An error message if the count is wrong, otherwise null.</returns>
    public static string? WrongNumberOfElements<T>(string before, int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        var count = collection.Count();
        return count != requireElements ? CheckBefore(before) + $" {nameCollection} has {count}, it's required {requireElements}" : null;
    }

    /// <summary>
    /// Checks if a directory exists.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="directory">The directory path to check.</param>
    /// <returns>An error message if the directory doesn't exist, otherwise null.</returns>
    public static string? DirectoryWasntFound(string before, string directory)
    {
        return !Directory.Exists(directory) ? CheckBefore(before) + " Directory" + " " + directory + " wasn't found." : null;
    }

    /// <summary>
    /// Checks if a list was passed instead of an array to a params parameter.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The name of the variable.</param>
    /// <param name="collection">The collection to check.</param>
    /// <param name="CA_IsListStringWrappedInArray">Function to check if it's a wrapped list.</param>
    /// <returns>An error message if a list was passed instead of an array, otherwise null.</returns>
    public static string? PassedListInsteadOfArray<T>(string before, string variableName, IEnumerable<T> collection, Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        if (CA_IsListStringWrappedInArray(collection))
            return CheckBefore(before) + $" {variableName} is IEnumerable<string>, was passed IEnumerable<string> into params";
        return null;
    }

    /// <summary>
    /// Checks if a value is whitespace or null.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variable">The variable name.</param>
    /// <param name="data">The data to check.</param>
    /// <returns>An error message if the value is whitespace or null, otherwise null.</returns>
    public static string? IsWhitespaceOrNull(string before, string variable, object data)
    {
        var isNull = false;
        var isWhitespace = false;
        if (data == null)
            isNull = true;
        else if ((data.ToString() ?? string.Empty).Trim() == string.Empty)
            isWhitespace = true;
        return isNull || isWhitespace ? CheckBefore(before) + variable + (isNull ? " is null" : " is whitespace") : null;
    }

    /// <summary>
    /// Creates an error message prompting to uncomment next rows.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <returns>An error message.</returns>
    public static string? UncommentNextRows(string before)
    {
        return CheckBefore(before) + "Uncomment next rows";
    }

    /// <summary>
    /// Checks if an index is out of range for a collection.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="colName">The collection name.</param>
    /// <param name="col">The collection.</param>
    /// <param name="indexName">The index variable name.</param>
    /// <param name="index">The index value.</param>
    /// <returns>An error message if the index is out of range, otherwise null.</returns>
    public static string? OutOfRange(string before, string colName, ICollection col, string indexName, int index)
    {
        return col.Count <= index ? CheckBefore(before) + $"{index} (variable {indexName}) is out of range in {colName}" : null;
    }

    /// <summary>
    /// Checks if all inner lists have the same count.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="elements">The list of lists to check.</param>
    /// <returns>An error message if counts differ, otherwise null.</returns>
    public static string? HaveAllInnerSameCount(string before, List<List<string>> elements)
    {
        var first = elements[0].Count;
        List<int> wrongCount = [];
        for (var i = 1; i < elements.Count; i++)
            if (first != elements[i].Count)
                wrongCount.Add(i);
        return wrongCount.Count > 0 ? CheckBefore(before) + $"Elements {string.Join(',', wrongCount)} have different count than 0 (first)" : null;
    }

    /// <summary>
    /// Checks if a directory exists.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="fulLPath">The full directory path.</param>
    /// <returns>Null if directory exists, otherwise an error message.</returns>
    public static string? DirectoryExists(string before, string fulLPath)
    {
        return Directory.Exists(fulLPath) ? null : CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }

    /// <summary>
    /// Checks if a string ends with a backslash.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="path">The string to check.</param>
    /// <returns>An error message if the string doesn't end with a backslash, otherwise null.</returns>
    public static string? CheckBackslashEnd(string before, string path)
    {
        if (path.Length != 0)
            if (path[^1] != '\\')
                return CheckBefore(before) + " string has not been in path format" + "!";
        return null;
    }

    /// <summary>
    /// Checks if a variable is not null when it should be.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable to check.</param>
    /// <returns>An error message if the variable is not null, otherwise null.</returns>
    public static string? IsNotNull(string before, string variableName, object variable)
    {
        return variable != null ? CheckBefore(before) + variableName + " must be null." : null;
    }

    /// <summary>
    /// Checks if an array element contains unallowed strings.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="arrayName">The array name.</param>
    /// <param name="dex">The index of the element.</param>
    /// <param name="valueElement">The element value.</param>
    /// <param name="unallowedStrings">The unallowed strings to check for.</param>
    /// <returns>An error message if unallowed strings are found, otherwise null.</returns>
    public static string? ArrayElementContainsUnallowedStrings(string before, string arrayName, int dex, string valueElement, params string[] unallowedStrings)
    {
        var foundedUnallowed = unallowedStrings.Where(d => valueElement.Contains(d)).ToList();
        return foundedUnallowed.Count != 0 ? CheckBefore(before) + "Element of" + " " + arrayName + " on index " + dex + " with value " + valueElement + " contains unallowed string(" + foundedUnallowed.Count + "): " + string.Join(',', unallowedStrings) : null;
    }

    /// <summary>
    /// Checks if start value is higher than end value.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="start">The start value.</param>
    /// <param name="end">The end value.</param>
    /// <returns>An error message if start is higher than end, otherwise null.</returns>
    public static string? StartIsHigherThanEnd(string before, int start, int end)
    {
        return start > end ? CheckBefore(before) + $"Start {start} is higher than end {end}" : null;
    }

    /// <summary>
    /// Checks if an object is not an IKeysHandler.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="name">The name of the object.</param>
    /// <param name="keysHandler">The object to check.</param>
    /// <returns>An error message if the object is not an IKeysHandler, otherwise null.</returns>
    public static string? WasNotKeysHandler(string before, string name, object keysHandler)
    {
        return keysHandler == null ? CheckBefore(before) + name + " " + "was not IKeysHandler" : null;
    }

    /// <summary>
    /// Creates an error message when a folder can't be removed.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="folder">The folder path.</param>
    /// <returns>An error message.</returns>
    public static string? FolderCantBeRemoved(string before, string folder)
    {
        return CheckBefore(before) + "Cannot delete folder" + ": " + folder;
    }

    /// <summary>
    /// Checks if an element wasn't removed from a collection.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="detailLocation">Details about where the removal was attempted.</param>
    /// <param name="countBefore">The count before removal.</param>
    /// <param name="countAfter">The count after removal.</param>
    /// <returns>An error message if the element wasn't removed, otherwise null.</returns>
    public static string? ElementWasntRemoved(string before, string detailLocation, int countBefore, int countAfter)
    {
        return countBefore == countAfter ? CheckBefore(before) + "Element was not removed during" + ": " + detailLocation : null;
    }

    /// <summary>
    /// Checks if no folders were passed.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="folders">The folders collection.</param>
    /// <returns>An error message if no folders were passed, otherwise null.</returns>
    public static string? NoPassedFolders(string before, ICollection folders)
    {
        return folders.Count == 0 ? CheckBefore(before) + "No passed folder into" : null;
    }

    /// <summary>
    /// Creates an error message from a file system exception.
    /// </summary>
    /// <param name="value">The prefix value.</param>
    /// <param name="ex">The exception.</param>
    /// <returns>An error message if exception is not null, otherwise null.</returns>
    public static string? FileSystemException(string value, Exception ex)
    {
        return ex != null ? CheckBefore(value) + " " + TextOfExceptions(ex) : null;
    }

    /// <summary>
    /// Checks if a parameter is URL encoded when it shouldn't be.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="valueVar">The variable value.</param>
    /// <param name="nameVar">The variable name.</param>
    /// <returns>An error message if the parameter is URL encoded, otherwise null.</returns>
    public static string? InvalidParameter(string before, string valueVar, string nameVar)
    {
        return valueVar != WebUtility.UrlDecode(valueVar) ? CheckBefore(before) + valueVar + " is url encoded " + nameVar : null;
    }

    /// <summary>
    /// Checks if a list has more than one element.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="count">The actual count.</param>
    /// <param name="moreInfo">Additional information.</param>
    /// <returns>An error message if the list has more than one element, otherwise null.</returns>
    public static string? MoreThanOneElement(string before, string listName, int count, string moreInfo = "")
    {
        return count > 1 ? CheckBefore(before) + listName + " has " + count + " elements, which is more than 1. " + moreInfo : null;
    }

    /// <summary>
    /// Checks if a control's name is not set.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameControl">The control name.</param>
    /// <param name="nameFromProperty">The name from the property.</param>
    /// <returns>An error message if the name is not set, otherwise null.</returns>
    public static string? NameIsNotSetted(string before, string nameControl, string nameFromProperty)
    {
        return string.IsNullOrWhiteSpace(nameFromProperty) ? CheckBefore(before) + nameControl + " " + "does not have setted name" : null;
    }

    /// <summary>
    /// Checks if a collection has only one element.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="colName">The collection name.</param>
    /// <param name="list">The collection.</param>
    /// <returns>An error message if the collection has only one element, otherwise null.</returns>
    public static string? OnlyOneElement(string before, string colName, ICollection list)
    {
        return list.Count == 1 ? CheckBefore(before) + colName + " has only one element" : null;
    }

    /// <summary>
    /// Checks if a string contains unallowed substrings.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="input">The input string to check.</param>
    /// <param name="unallowedStrings">The unallowed substrings.</param>
    /// <returns>An error message if unallowed substrings are found, otherwise null.</returns>
    public static string? StringContainsUnallowedSubstrings(string before, string input, params string[] unallowedStrings)
    {
        List<string> foundedUnallowed = [];
        foreach (var item in unallowedStrings)
            if (input.Contains(item))
                foundedUnallowed.Add(item);
        return foundedUnallowed.Count > 0 ? CheckBefore(before) + input + " contains unallowed chars: " + string.Join(string.Empty, unallowedStrings) : null;
    }

    /// <summary>
    /// Checks if a variable is null.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable to check.</param>
    /// <returns>An error message if the variable is null, otherwise null.</returns>
    public static string? IsNull(string before, string variableName, object? variable)
    {
        return variable == null ? CheckBefore(before) + variableName + " " + "is null" + "." : null;
    }

    /// <summary>
    /// Creates an error message for a not implemented case.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="notImplementedName">The name or type of the not implemented case.</param>
    /// <returns>An error message.</returns>
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