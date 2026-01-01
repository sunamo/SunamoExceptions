namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

/// <summary>
/// Provides static methods for throwing exceptions with automatic context information.
/// Each method validates a condition and throws an exception if the condition fails.
/// </summary>
public partial class ThrowEx
{
    /// <summary>
    /// Throws an exception if two values are not the same.
    /// </summary>
    public static bool IsNotTheSame<T>(string name1, T value1, string name2, T value2)
    {
        return ThrowIsNotNull(Exceptions.IsNotTheSame(FullNameOfExecutedCode(), name1, value1, name2, value2));
    }

    /// <summary>
    /// Throws an exception if a folder does not exist.
    /// </summary>
    public static bool FolderDoesNotExists(string folder, string additionalInfo = "")
    {
        return ThrowIsNotNull(Exceptions.FolderDoesNotExists(FullNameOfExecutedCode(), folder, additionalInfo));
    }

    /// <summary>
    /// Throws an exception if a key already exists in a dictionary.
    /// </summary>
    public static bool KeyAlreadyExists<T, U>(Dictionary<T, U> dictionary, T key, string dictionaryName) where T : notnull
    {
        return ThrowIsNotNull(Exceptions.KeyAlreadyExists(FullNameOfExecutedCode(), dictionary, key, dictionaryName));
    }

    /// <summary>
    /// Throws an exception if a list doesn't have the required index.
    /// </summary>
    public static bool HasNotIndex<T>(IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        return ThrowIsNotNull(Exceptions.HasNotIndex(FullNameOfExecutedCode(), list, listName, maxRequiredIndex));
    }

    /// <summary>
    /// Throws an ArgumentOutOfRangeException with the specified parameters.
    /// </summary>
    public static bool ArgumentOutOfRangeException(string argName, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), argName, message));
    }

    /// <summary>
    /// Throws an exception if an array element contains unallowed strings.
    /// </summary>
    public static bool ArrayElementContainsUnAllowedStrings(string arrayName, int dex, string valueElement, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(Exceptions.ArrayElementContainsUnallowedStrings(FullNameOfExecutedCode(), arrayName, dex, valueElement, unallowedStrings));
    }

    /// <summary>
    /// Throws an exception if a list element has a bad format.
    /// </summary>
    public static bool BadFormatOfElementInList(object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return ThrowIsNotNull(Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(), elVal, listName, SH_NullToStringOrDefault));
    }

    /// <summary>
    /// Throws an exception if XAML is badly mapped.
    /// </summary>
    public static bool BadMappedXaml(string nameControl, string additionalInfo)
    {
        return ThrowIsNotNull(Exceptions.BadMappedXaml(FullNameOfExecutedCode(), nameControl, additionalInfo));
    }

    /// <summary>
    /// Throws an exception if a DateTime cannot be created with the specified parameters.
    /// </summary>
    public static bool CannotCreateDateTime(int year, int month, int day, int hour, int minute, int seconds, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotCreateDateTime(FullNameOfExecutedCode(), year, month, day, hour, minute, seconds, ex));
    }

    /// <summary>
    /// Throws an exception if a folder cannot be moved.
    /// </summary>
    public static bool CannotMoveFolder(string item, string destinationPath, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotMoveFolder(FullNameOfExecutedCode(), item, destinationPath, ex));
    }

    /// <summary>
    /// Throws an exception if a string doesn't end with a backslash.
    /// </summary>
    public static bool CheckBackslashEnd(string r)
    {
        return ThrowIsNotNull(Exceptions.CheckBackSlashEnd(FullNameOfExecutedCode(), r));
    }

    /// <summary>
    /// Throws a custom exception from an Exception object.
    /// </summary>
    public static bool Custom(Exception ex, bool reallyThrow = true)
    {
        return Custom(Exceptions.TextOfExceptions(ex), reallyThrow);
    }

    /// <summary>
    /// Throws a custom exception with the specified message.
    /// </summary>
    public static bool Custom(string message, bool reallyThrow = true, string secondMessage = "")
    {
        string joined = string.Join(" ", message, secondMessage);
        string? str = Exceptions.Custom(FullNameOfExecutedCode(), joined);
        return ThrowIsNotNull(str, reallyThrow);
    }

    /// <summary>
    /// Throws a custom exception with stack trace from an Exception object.
    /// </summary>
    public static bool CustomWithStackTrace(Exception ex)
    {
        return Custom(Exceptions.TextOfExceptions(ex));
    }

    /// <summary>
    /// Throws an exception if two lists have different element counts.
    /// </summary>
    public static bool DifferentCountInLists<T>(string namefc, IList<T> countfc, string namesc, IList<T> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }

    /// <summary>
    /// Throws an exception if two collections have different element counts.
    /// </summary>
    public static bool DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc, namesc, countsc));
    }

    /// <summary>
    /// Throws an exception if two lists of different types have different element counts.
    /// </summary>
    public static bool DifferentCountInListsTU<T, U>(string namefc, IList<T> countfc, string namesc, IList<U> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }

    /// <summary>
    /// Throws an exception if a directory doesn't exist.
    /// </summary>
    public static bool DirectoryExists(string path)
    {
        return ThrowIsNotNull(Exceptions.DirectoryExists(FullNameOfExecutedCode(), path));
    }

    /// <summary>
    /// Throws an exception if a directory wasn't found.
    /// </summary>
    public static bool DirectoryWasntFound(string directory)
    {
        return ThrowIsNotNull(Exceptions.DirectoryWasntFound(FullNameOfExecutedCode(), directory));
    }

    /// <summary>
    /// Throws an exception for division by zero.
    /// </summary>
    public static bool DivideByZero()
    {
        return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Throws an exception if a variable doesn't have the required type.
    /// </summary>
    public static bool DoesntHaveRequiredType(string variableName)
    {
        return ThrowIsNotNull(Exceptions.DoesntHaveRequiredType(FullNameOfExecutedCode(), variableName));
    }

    /// <summary>
    /// Throws an exception if a list contains duplicated elements.
    /// </summary>
    public static bool DuplicatedElements(string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return ThrowIsNotNull(Exceptions.DuplicatedElements(FullNameOfExecutedCode(), nameOfVariable, duplicatedElements, message));
    }

    /// <summary>
    /// Throws an exception if an element can't be found in a collection.
    /// </summary>
    public static bool ElementCantBeFound(string nameCollection, string element)
    {
        return ThrowIsNotNull(Exceptions.ElementCantBeFound(FullNameOfExecutedCode(), nameCollection, element));
    }

    /// <summary>
    /// Throws an exception if an element wasn't removed from a collection.
    /// </summary>
    public static bool ElementWasntRemoved(string detailLocation, int before, int after)
    {
        return ThrowIsNotNull(Exceptions.ElementWasntRemoved(FullNameOfExecutedCode(), detailLocation, before, after));
    }

    /// <summary>
    /// Throws an exception with exception information as argument.
    /// </summary>
    public static bool ExcAsArg(Exception ex, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ExcAsArg, ex, message);
    }

    /// <summary>
    /// Throws an exception if a file already exists.
    /// </summary>
    public static bool FileAlreadyExists(string path)
    {
        return ThrowIsNotNull(Exceptions.FileAlreadyExists, path);
    }

    /// <summary>
    /// Throws an exception if a file doesn't exist.
    /// </summary>
    public static bool FileDoesntExists(string fulLPath)
    {
        return ThrowIsNotNull(Exceptions.FileExists(FullNameOfExecutedCode(), fulLPath));
    }

    /// <summary>
    /// Throws an exception if a file has an extension that cannot be parsed to image format.
    /// </summary>
    public static bool FileHasExtensionNotParseAbleToImageFormat(string fnOri)
    {
        return ThrowIsNotNull(Exceptions.FileHasExtensionNotParseAbleToImageFormat(FullNameOfExecutedCode(), fnOri));
    }

    /// <summary>
    /// Throws a file system exception.
    /// </summary>
    public static bool FileSystemException(Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FileSystemException(FullNameOfExecutedCode(), ex));
    }

    /// <summary>
    /// Throws an exception if the first letter is not uppercase.
    /// </summary>
    public static bool FirstLetterIsNotUpper(string selectedFile)
    {
        return ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, selectedFile);
    }

    /// <summary>
    /// Throws an exception if a folder cannot be deleted.
    /// </summary>
    public static bool FolderCannotBeDeleted(string folder, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(), folder, ex));
    }

    /// <summary>
    /// Throws an exception if a folder can't be removed.
    /// </summary>
    public static bool FolderCantBeRemoved(string folder)
    {
        return ThrowIsNotNull(Exceptions.FolderCantBeRemoved(FullNameOfExecutedCode(), folder));
    }

    /// <summary>
    /// Throws an exception if a folder is not empty.
    /// </summary>
    public static bool FolderIsNotEmpty(string variableName, string path)
    {
        return ThrowIsNotNull(Exceptions.FolderIsNotEmpty, variableName, path);
    }

    /// <summary>
    /// Throws an exception if functionality is denied.
    /// </summary>
    public static bool FunctionalityDenied(string functionalityName)
    {
        return ThrowIsNotNull(Exceptions.FunctionalityDenied(FullNameOfExecutedCode(), functionalityName));
    }

    /// <summary>
    /// Throws an exception if a dictionary doesn't have the specified key.
    /// </summary>
    public static bool HasNotKeyDictionary<Key, Value>(string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        return ThrowIsNotNull(Exceptions.HasNotKeyDictionary(FullNameOfExecutedCode(), nameDict, qsDict, remains));
    }

    /// <summary>
    /// Throws an exception if a list has an odd number of elements.
    /// </summary>
    public static bool HasOddNumberOfElements(string listName, ICollection list)
    {
        var f = Exceptions.HasOddNumberOfElements;
        return ThrowIsNotNull(f, listName, list);
    }

    /// <summary>
    /// Throws an exception if all inner lists don't have the same count.
    /// </summary>
    public static bool HaveAllInnerSameCount(List<List<string>> elements)
    {
        return ThrowIsNotNull(Exceptions.HaveAllInnerSameCount(FullNameOfExecutedCode(), elements));
    }

    /// <summary>
    /// Throws an exception if a variable doesn't have the exact required length.
    /// </summary>
    public static bool InvalidExactlyLength(string variableName, int length, int requiredLenght)
    {
        return ThrowIsNotNull(Exceptions.InvalidExactlyLength(FullNameOfExecutedCode(), variableName, length, requiredLenght));
    }

    /// <summary>
    /// Throws an exception if a parameter is invalid (URL encoded).
    /// </summary>
    public static bool InvalidParameter(string valueVar, string nameVar)
    {
        return ThrowIsNotNull(Exceptions.InvalidParameter(FullNameOfExecutedCode(), valueVar, nameVar));
    }

    /// <summary>
    /// Throws an exception if a collection is empty.
    /// </summary>
    public static bool IsEmpty(IEnumerable folders, string colName, string additionalMessage = "")
    {
        return ThrowIsNotNull(Exceptions.IsEmpty(FullNameOfExecutedCode(), folders, colName, additionalMessage));
    }

    /// <summary>
    /// Throws an exception if something is not allowed.
    /// </summary>
    public static bool IsNotAllowed(string what)
    {
        return ThrowIsNotNull(Exceptions.IsNotAllowed(FullNameOfExecutedCode(), what));
    }

    /// <summary>
    /// Throws an exception if a variable is not null when it should be.
    /// </summary>
    public static bool IsNotNull(string variableName, object variable)
    {
        return ThrowIsNotNull(Exceptions.IsNotNull(FullNameOfExecutedCode(), variableName, variable));
    }

    /// <summary>
    /// Throws an exception if a value is not a positive number.
    /// </summary>
    public static bool IsNotPositiveNumber(string nameOfVariable, int? n)
    {
        return ThrowIsNotNull(Exceptions.IsNotPositiveNumber(FullNameOfExecutedCode(), nameOfVariable, n));
    }

    /// <summary>
    /// Throws an exception if a string is not in Windows path format.
    /// </summary>
    public static bool IsNotWindowsPathFormat(string argName, string argValue, bool raiseIsNotWindowsPathFormat, Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsNotWindowsPathFormat(FullNameOfExecutedCode(), argName, argValue, raiseIsNotWindowsPathFormat, SunamoFileSystem_IsWindowsPathFormat));
    }

    /// <summary>
    /// Throws an exception if a variable is null.
    /// </summary>
    public static bool IsNull(string variableName, object? variable = null)
    {
        return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable));
    }

    /// <summary>
    /// Throws an exception if a string argument is null or empty.
    /// </summary>
    public static bool IsNullOrEmpty(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, true));
    }

    /// <summary>
    /// Throws an exception if a string argument is null or whitespace.
    /// </summary>
    public static bool IsNullOrWhitespace(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, false));
    }

    /// <summary>
    /// Throws an exception if two values are the same when they should differ.
    /// </summary>
    public static bool IsTheSame(string fst, string sec)
    {
        return ThrowIsNotNull(Exceptions.IsTheSame(FullNameOfExecutedCode(), fst, sec));
    }

    /// <summary>
    /// Throws an exception if a value is whitespace or null.
    /// </summary>
    public static bool IsWhitespaceOrNull(string variable, object data)
    {
        return ThrowIsNotNull(Exceptions.IsWhitespaceOrNull(FullNameOfExecutedCode(), variable, data));
    }

    /// <summary>
    /// Throws an exception if a string is in Windows path format when it shouldn't be.
    /// </summary>
    public static bool IsWindowsPathFormat(string input, Func<string, bool> isWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsWindowsPathFormat(FullNameOfExecutedCode(), input, isWindowsPathFormat));
    }

    /// <summary>
    /// Throws an exception if a key is not found in a dictionary.
    /// </summary>
    public static bool KeyNotFound<T, U>(IDictionary<T, U> en, string dictName, T key)
    {
        return ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(), en, dictName, key));
    }

    /// <summary>
    /// Throws an exception if a list is null or empty.
    /// </summary>
    public static bool ListNullOrEmpty<T>(string variableName, IEnumerable<T>? list)
    {
        return ThrowIsNotNull(Exceptions.ListNullOrEmpty(FullNameOfExecutedCode(), variableName, list));
    }

    /// <summary>
    /// Throws an exception if a drive is locked by BitLocker.
    /// </summary>
    public static bool LockedByBitLocker(string path, Func<char, bool> IsLockedByBitLocker)
    {
        return ThrowIsNotNull(Exceptions.LockedByBitLocker(FullNameOfExecutedCode(), path, IsLockedByBitLocker));
    }

    /// <summary>
    /// Throws an exception if a list has more than one element.
    /// </summary>
    public static bool MoreThanOneElement(string listName, int count, string moreInfo = "")
    {
        string fn = FullNameOfExecutedCode();
        string? exc = Exceptions.MoreThanOneElement(fn, listName, count, moreInfo);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Throws an exception if a control's name is not set.
    /// </summary>
    public static bool NameIsNotSetted(string nameControl, string nameFromProperty)
    {
        return ThrowIsNotNull(Exceptions.NameIsNotSetted(FullNameOfExecutedCode(), nameControl, nameFromProperty));
    }

    /// <summary>
    /// Throws an exception if no folders were passed.
    /// </summary>
    public static bool NoPassedFolders(ICollection folders)
    {
        return ThrowIsNotNull(Exceptions.NoPassedFolders(FullNameOfExecutedCode(), folders));
    }

    /// <summary>
    /// Throws an exception if a string doesn't contain required substrings.
    /// </summary>
    public static bool NotContains(string text, params string[] shouldContains)
    {
        return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(), text, shouldContains));
    }
}
