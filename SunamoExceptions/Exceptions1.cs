// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoExceptions;
// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
    public static string? CannotCreateDateTime(string before, int year, int month, int day, int hour, int minute, int seconds, Exception ex)
    {
        return CheckBefore(before) + $"Cannot create DateTime with: year: {year} month: {month} day: {day} hour: {hour} minute: {minute} seconds: {seconds} " + TextOfExceptions(ex);
    }

    public static string? CannotMoveFolder(string before, string item, string nova, Exception ex)
    {
        return CheckBefore(before) + $"Cannot move folder from {item} to {nova} " + TextOfExceptions(ex);
    }

    public static string? ExcAsArg(string before, Exception ex, string message)
    {
        return CheckBefore(before) + message + string.Empty + TextOfExceptions(ex);
    }

    public static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }

    public static string? NotExists(string before, string what)
    {
        return CheckBefore(before) + what + " not exists";
    }

    public static string? KeyAlreadyExists<T, U>(string before, Dictionary<T, U> dictionary, T key, string dictionaryName)
    {
        if (dictionary.ContainsKey(key))
        {
            return before + $"Key {key} already exists in {dictionaryName}";
        }

        return null;
    }

    public static string? FileAlreadyExists(string before, string path)
    {
        if (File.Exists(path))
        {
            return CheckBefore(before) + path + " already exists";
        }

        return null;
    }

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

    public static string? LockedByBitLocker(string before, string path, Func<char, bool> IsLockedByBitLocker)
    {
        if (IsLockedByBitLocker != null)
        {
            var parameter = path[0];
            if (IsLockedByBitLocker(parameter))
            {
                return CheckBefore(before) + $"Drive {parameter}:\\ is locked by BitLocker";
            }
        }

        return null;
    }

    public static string? NotInt(string before, string what, int? value)
    {
        return !value.HasValue ? CheckBefore(before) + what + " is not with value " + value + " valid integer number" : null;
    }

    public static string? HasOddNumberOfElements(string before, string listName, ICollection list)
    {
        return list.Count % 2 == 1 ? CheckBefore(before) + listName + " has odd number of elements " + list.Count : null;
    }

    public static string? WrongExtension(string before, string path, string requiredExt)
    {
        return System.IO.Path.GetExtension(path) != requiredExt ? CheckBefore(before) + path + "don't have " + requiredExt + " extension" : null;
    }

    public static string? WrongNumberOfElements<T>(string before, int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        var count = collection.Count();
        return count != requireElements ? CheckBefore(before) + $" {nameCollection} has {count}, it's required {requireElements}" : null;
    }

    public static string? DirectoryWasntFound(string before, string directory)
    {
        return !Directory.Exists(directory) ? CheckBefore(before) + " Directory" + " " + directory + " wasn't found." : null;
    }

    public static string? PassedListInsteadOfArray<T>(string before, string variableName, IEnumerable<T> v2, Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        if (CA_IsListStringWrappedInArray(v2))
            return CheckBefore(before) + $" {variableName} is IEnumerable<string>, was passed IEnumerable<string> into params";
        return null;
    }

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

    public static string? UncommentNextRows(string before)
    {
        return CheckBefore(before) + "Uncomment next rows";
    }

    public static string? OutOfRange(string before, string colName, ICollection col, string indexName, int index)
    {
        return col.Count <= index ? CheckBefore(before) + $"{index} (variable {indexName}) is out of range in {colName}" : null;
    }

    public static string? HaveAllInnerSameCount(string before, List<List<string>> elements)
    {
        var first = elements[0].Count;
        List<int> wrongCount = [];
        for (var i = 1; i < elements.Count; i++)
            if (first != elements[i].Count)
                wrongCount.Add(i);
        return wrongCount.Count > 0 ? CheckBefore(before) + $"Elements {string.Join(',', wrongCount)} have different count than 0 (first)" : null;
    }

    public static string? DirectoryExists(string before, string fulLPath)
    {
        return Directory.Exists(fulLPath) ? null : CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }

    public static string? CheckBackslashEnd(string before, string r)
    {
        if (r.Length != 0)
            if (r[^1] != '\\')
                return CheckBefore(before) + " string has not been in path format" + "!";
        return null;
    }

    public static string? IsNotNull(string before, string variableName, object variable)
    {
        return variable != null ? CheckBefore(before) + variableName + " must be null." : null;
    }

    public static string? ArrayElementContainsUnallowedStrings(string before, string arrayName, int dex, string valueElement, params string[] unallowedStrings)
    {
        var foundedUnallowed = unallowedStrings.Where(d => valueElement.Contains(d)).ToList();
        return foundedUnallowed.Count != 0 ? CheckBefore(before) + "Element of" + " " + arrayName + " on index " + dex + " with value " + valueElement + " contains unallowed string(" + foundedUnallowed.Count + "): " + string.Join(',', unallowedStrings) : null;
    }

    public static string? StartIsHigherThanEnd(string before, int start, int end)
    {
        return start > end ? CheckBefore(before) + $"Start {start} is higher than end {end}" : null;
    }

    public static string? WasNotKeysHandler(string before, string name, object keysHandler)
    {
        return keysHandler == null ? CheckBefore(before) + name + " " + "was not IKeysHandler" : null;
    }

    public static string? FolderCantBeRemoved(string before, string folder)
    {
        return CheckBefore(before) + "Cannot delete folder" + ": " + folder;
    }

    public static string? ElementWasntRemoved(string before, string detailLocation, int before2, int after)
    {
        return before2 == after ? CheckBefore(before) + "Element was not removed during" + ": " + detailLocation : null;
    }

    public static string? NoPassedFolders(string before, ICollection folders)
    {
        return folders.Count == 0 ? CheckBefore(before) + "No passed folder into" : null;
    }

    public static string? FileSystemException(string value, Exception ex)
    {
        return ex != null ? CheckBefore(value) + " " + TextOfExceptions(ex) : null;
    }

    public static string? InvalidParameter(string before, string valueVar, string nameVar)
    {
        return valueVar != WebUtility.UrlDecode(valueVar) ? CheckBefore(before) + valueVar + " is url encoded " + nameVar : null;
    }

    public static string? MoreThanOneElement(string before, string listName, int count, string moreInfo = "")
    {
        return count > 1 ? CheckBefore(before) + listName + " has " + count + " elements, which is more than 1. " + moreInfo : null;
    }

    public static string? NameIsNotSetted(string before, string nameControl, string nameFromProperty)
    {
        return string.IsNullOrWhiteSpace(nameFromProperty) ? CheckBefore(before) + nameControl + " " + "does not have setted name" : null;
    }

    public static string? OnlyOneElement(string before, string colName, ICollection list)
    {
        return list.Count == 1 ? CheckBefore(before) + colName + " has only one element" : null;
    }

    public static string? StringContainsUnallowedSubstrings(string before, string input, params string[] unallowedStrings)
    {
        List<string> foundedUnallowed = [];
        foreach (var item in unallowedStrings)
            if (input.Contains(item))
                foundedUnallowed.Add(item);
        return foundedUnallowed.Count > 0 ? CheckBefore(before) + input + " contains unallowed chars: " + string.Join(string.Empty, unallowedStrings) : null;
    }

    public static string? IsNull(string before, string variableName, object? variable)
    {
        return variable == null ? CheckBefore(before) + variableName + " " + "is null" + "." : null;
    }

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