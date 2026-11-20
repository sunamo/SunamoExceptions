namespace SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
    /// <summary>
    /// Cannot create date time.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The cannot create date time result.</returns>
    public static string? CannotCreateDateTime(string before, int year, int month, int day, int hour, int minute, int seconds, Exception ex)
    {
        return CheckBefore(before) + $"Cannot create DateTime with: year: {year} month: {month} day: {day} hour: {hour} minute: {minute} seconds: {seconds} " + TextOfExceptions(ex);
    }

    /// <summary>
    /// Cannot move folder.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="sourcePath">The source path.</param>
    /// <param name="destinationPath">The destination path.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The cannot move folder result.</returns>
    public static string? CannotMoveFolder(string before, string sourcePath, string destinationPath, Exception ex)
    {
        return CheckBefore(before) + $"Cannot move folder from {sourcePath} to {destinationPath} " + TextOfExceptions(ex);
    }

    /// <summary>
    /// Exc as arg.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="ex">The ex.</param>
    /// <param name="message">The message.</param>
    /// <returns>The exc as arg result.</returns>
    public static string? ExcAsArg(string before, Exception ex, string message)
    {
        return CheckBefore(before) + message + string.Empty + TextOfExceptions(ex);
    }

    /// <summary>
    /// Not implemented method.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <returns>The not implemented method result.</returns>
    public static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }

    /// <summary>
    /// Not exists.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="what">The what.</param>
    /// <returns>The not exists result.</returns>
    public static string? NotExists(string before, string what)
    {
        return CheckBefore(before) + what + " not exists";
    }

    /// <summary>
    /// Key already exists t u.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key.</param>
    /// <param name="dictionaryName">The dictionary name.</param>
    /// <returns>The key already exists t u result.</returns>
    public static string? KeyAlreadyExists<T, U>(string before, Dictionary<T, U> dictionary, T key, string dictionaryName) where T : notnull
    {
        if (dictionary.ContainsKey(key))
        {
            return before + $"Key {key} already exists in {dictionaryName}";
        }

        return null;
    }

    /// <summary>
    /// File already exists.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="path">The path.</param>
    /// <returns>The file already exists result.</returns>
    public static string? FileAlreadyExists(string before, string path)
    {
        if (File.Exists(path))
        {
            return CheckBefore(before) + path + " already exists";
        }

        return null;
    }

    /// <summary>
    /// List null or empty t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The list null or empty t result.</returns>
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
    /// Locked by bit locker.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="path">The path.</param>
    /// <param name="IsLockedByBitLocker">The is locked by bit locker.</param>
    /// <returns>The locked by bit locker result.</returns>
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
    /// Not int.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="what">The what.</param>
    /// <param name="value">The value.</param>
    /// <returns>The not int result.</returns>
    public static string? NotInt(string before, string what, int? value)
    {
        return !value.HasValue ? CheckBefore(before) + what + " is not with value " + value + " valid integer number" : null;
    }

    /// <summary>
    /// Has odd number of elements.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The has odd number of elements result.</returns>
    public static string? HasOddNumberOfElements(string before, string listName, ICollection list)
    {
        return list.Count % 2 == 1 ? CheckBefore(before) + listName + " has odd number of elements " + list.Count : null;
    }

    /// <summary>
    /// Wrong extension.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="path">The path.</param>
    /// <param name="requiredExt">The required ext.</param>
    /// <returns>The wrong extension result.</returns>
    public static string? WrongExtension(string before, string path, string requiredExt)
    {
        return System.IO.Path.GetExtension(path) != requiredExt ? CheckBefore(before) + path + "don't have " + requiredExt + " extension" : null;
    }

    /// <summary>
    /// Wrong number of elements t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="before">The before.</param>
    /// <param name="requireElements">The require elements.</param>
    /// <param name="nameCollection">The name collection.</param>
    /// <param name="collection">The collection.</param>
    /// <returns>The wrong number of elements t result.</returns>
    public static string? WrongNumberOfElements<T>(string before, int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        var count = collection.Count();
        return count != requireElements ? CheckBefore(before) + $" {nameCollection} has {count}, it's required {requireElements}" : null;
    }

    /// <summary>
    /// Directory wasnt found.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="directory">The directory.</param>
    /// <returns>The directory wasnt found result.</returns>
    public static string? DirectoryWasntFound(string before, string directory)
    {
        return !Directory.Exists(directory) ? CheckBefore(before) + " Directory" + " " + directory + " wasn't found." : null;
    }

    /// <summary>
    /// Passed list instead of array t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="collection">The collection.</param>
    /// <param name="CA_IsListStringWrappedInArray">The CA is list string wrapped in array.</param>
    /// <returns>The passed list instead of array t result.</returns>
    public static string? PassedListInsteadOfArray<T>(string before, string variableName, IEnumerable<T> collection, Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        if (CA_IsListStringWrappedInArray(collection))
            return CheckBefore(before) + $" {variableName} is IEnumerable<string>, was passed IEnumerable<string> into params";
        return null;
    }

    /// <summary>
    /// Is whitespace or null.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="variable">The variable.</param>
    /// <param name="data">The data.</param>
    /// <returns>The is whitespace or null result.</returns>
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
    /// Uncomment next rows.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <returns>The uncomment next rows result.</returns>
    public static string? UncommentNextRows(string before)
    {
        return CheckBefore(before) + "Uncomment next rows";
    }

    /// <summary>
    /// Out of range.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="colName">The col name.</param>
    /// <param name="col">The col.</param>
    /// <param name="indexName">The index name.</param>
    /// <param name="index">The index.</param>
    /// <returns>The out of range result.</returns>
    public static string? OutOfRange(string before, string colName, ICollection col, string indexName, int index)
    {
        return col.Count <= index ? CheckBefore(before) + $"{index} (variable {indexName}) is out of range in {colName}" : null;
    }

    /// <summary>
    /// Have all inner same count.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="elements">The elements.</param>
    /// <returns>The have all inner same count result.</returns>
    public static string? HaveAllInnerSameCount(string before, List<List<string>> elements)
    {
        var first = elements[0].Count;
        List<int> wrongCount = [];
        for (var i = 1; i < elements.Count; i++)
            if (first != elements[i].Count)
                wrongCount.Add(i);
        return wrongCount.Count > 0 ? CheckBefore(before) + $"Elements {string.Join(",", wrongCount)} have different count than 0 (first)" : null;
    }

    /// <summary>
    /// Directory exists.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="fulLPath">The ful l path.</param>
    /// <returns>The directory exists result.</returns>
    public static string? DirectoryExists(string before, string fulLPath)
    {
        return Directory.Exists(fulLPath) ? null : CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }

    /// <summary>
    /// Check backslash end.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="path">The path.</param>
    /// <returns>The check backslash end result.</returns>
    public static string? CheckBackslashEnd(string before, string path)
    {
        if (path.Length != 0)
            if (path[^1] != '\\')
                return CheckBefore(before) + " string has not been in path format" + "!";
        return null;
    }

    /// <summary>
    /// Is not null.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable.</param>
    /// <returns>The is not null result.</returns>
    public static string? IsNotNull(string before, string variableName, object variable)
    {
        return variable != null ? CheckBefore(before) + variableName + " must be null." : null;
    }

    /// <summary>
    /// Array element contains unallowed strings.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="arrayName">The array name.</param>
    /// <param name="dex">The dex.</param>
    /// <param name="valueElement">The value element.</param>
    /// <param name="unallowedStrings">The unallowed strings.</param>
    /// <returns>The array element contains unallowed strings result.</returns>
    public static string? ArrayElementContainsUnallowedStrings(string before, string arrayName, int dex, string valueElement, params string[] unallowedStrings)
    {
        var foundedUnallowed = unallowedStrings.Where(d => valueElement.Contains(d)).ToList();
        return foundedUnallowed.Count != 0 ? CheckBefore(before) + "Element of" + " " + arrayName + " on index " + dex + " with value " + valueElement + " contains unallowed string(" + foundedUnallowed.Count + "): " + string.Join(",", unallowedStrings) : null;
    }

    /// <summary>
    /// Start is higher than end.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <returns>The start is higher than end result.</returns>
    public static string? StartIsHigherThanEnd(string before, int start, int end)
    {
        return start > end ? CheckBefore(before) + $"Start {start} is higher than end {end}" : null;
    }

    /// <summary>
    /// Was not keys handler.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="name">The name.</param>
    /// <param name="keysHandler">The keys handler.</param>
    /// <returns>The was not keys handler result.</returns>
    public static string? WasNotKeysHandler(string before, string name, object keysHandler)
    {
        return keysHandler == null ? CheckBefore(before) + name + " " + "was not IKeysHandler" : null;
    }

    /// <summary>
    /// Folder cant be removed.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="folder">The folder.</param>
    /// <returns>The folder cant be removed result.</returns>
    public static string? FolderCantBeRemoved(string before, string folder)
    {
        return CheckBefore(before) + "Cannot delete folder" + ": " + folder;
    }

    /// <summary>
    /// Element wasnt removed.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="detailLocation">The detail location.</param>
    /// <param name="countBefore">The count before.</param>
    /// <param name="countAfter">The count after.</param>
    /// <returns>The element wasnt removed result.</returns>
    public static string? ElementWasntRemoved(string before, string detailLocation, int countBefore, int countAfter)
    {
        return countBefore == countAfter ? CheckBefore(before) + "Element was not removed during" + ": " + detailLocation : null;
    }

    /// <summary>
    /// No passed folders.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="folders">The folders.</param>
    /// <returns>The no passed folders result.</returns>
    public static string? NoPassedFolders(string before, ICollection folders)
    {
        return folders.Count == 0 ? CheckBefore(before) + "No passed folder into" : null;
    }

    /// <summary>
    /// File system exception.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The file system exception result.</returns>
    public static string? FileSystemException(string value, Exception ex)
    {
        return ex != null ? CheckBefore(value) + " " + TextOfExceptions(ex) : null;
    }

    /// <summary>
    /// Invalid parameter.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="valueVar">The value var.</param>
    /// <param name="nameVar">The name var.</param>
    /// <returns>The invalid parameter result.</returns>
    public static string? InvalidParameter(string before, string valueVar, string nameVar)
    {
        return valueVar != WebUtility.UrlDecode(valueVar) ? CheckBefore(before) + valueVar + " is url encoded " + nameVar : null;
    }

    /// <summary>
    /// More than one element.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="count">The count.</param>
    /// <param name="moreInfo">The more info.</param>
    /// <returns>The more than one element result.</returns>
    public static string? MoreThanOneElement(string before, string listName, int count, string moreInfo = "")
    {
        return count > 1 ? CheckBefore(before) + listName + " has " + count + " elements, which is more than 1. " + moreInfo : null;
    }

    /// <summary>
    /// Name is not setted.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameControl">The name control.</param>
    /// <param name="nameFromProperty">The name from property.</param>
    /// <returns>The name is not setted result.</returns>
    public static string? NameIsNotSetted(string before, string nameControl, string nameFromProperty)
    {
        return string.IsNullOrWhiteSpace(nameFromProperty) ? CheckBefore(before) + nameControl + " " + "does not have setted name" : null;
    }

    /// <summary>
    /// Only one element.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="colName">The col name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The only one element result.</returns>
    public static string? OnlyOneElement(string before, string colName, ICollection list)
    {
        return list.Count == 1 ? CheckBefore(before) + colName + " has only one element" : null;
    }
}
