namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class ThrowEx
{
    public static bool IsNotTheSame<T>(string name1, T value1, string name2, T value2)
    {
        return ThrowIsNotNull(Exceptions.IsNotTheSame(FullNameOfExecutedCode(), name1, value1, name2, value2));
    }

    public static bool FolderDoesNotExists(string folder, string additionalInfo = "")
    {
        return ThrowIsNotNull(Exceptions.FolderDoesNotExists(FullNameOfExecutedCode(), folder, additionalInfo));
    }

    public static bool KeyAlreadyExists<T, U>(Dictionary<T, U> dictionary, T key, string dictionaryName)
    {
        return ThrowIsNotNull(Exceptions.KeyAlreadyExists(FullNameOfExecutedCode(), dictionary, key, dictionaryName));
    }

    public static bool HasNotIndex<T>(IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        return ThrowIsNotNull(Exceptions.HasNotIndex(FullNameOfExecutedCode(), list, listName, maxRequiredIndex));
    }

    public static bool ArgumentOutOfRangeException(string argName, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), argName, message));
    }

    public static bool ArrayElementContainsUnAllowedStrings(string arrayName, int dex, string valueElement, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(Exceptions.ArrayElementContainsUnallowedStrings(FullNameOfExecutedCode(), arrayName, dex, valueElement, unallowedStrings));
    }

    public static bool BadFormatOfElementInList(object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return ThrowIsNotNull(Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(), elVal, listName, SH_NullToStringOrDefault));
    }

    public static bool BadMappedXaml(string nameControl, string additionalInfo)
    {
        return ThrowIsNotNull(Exceptions.BadMappedXaml(FullNameOfExecutedCode(), nameControl, additionalInfo));
    }

    public static bool CannotCreateDateTime(int year, int month, int day, int hour, int minute, int seconds, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotCreateDateTime(FullNameOfExecutedCode(), year, month, day, hour, minute, seconds, ex));
    }

    public static bool CannotMoveFolder(string item, string nova, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotMoveFolder(FullNameOfExecutedCode(), item, nova, ex));
    }

    public static bool CheckBackslashEnd(string r)
    {
        return ThrowIsNotNull(Exceptions.CheckBackSlashEnd(FullNameOfExecutedCode(), r));
    }

    public static bool Custom(Exception ex, bool reallyThrow = true)
    {
        return Custom(Exceptions.TextOfExceptions(ex), reallyThrow);
    }

    public static bool Custom(string message, bool reallyThrow = true, string secondMessage = "")
    {
        string joined = string.Join(" ", message, secondMessage);
        string? str = Exceptions.Custom(FullNameOfExecutedCode(), joined);
        return ThrowIsNotNull(str, reallyThrow);
    }

    public static bool CustomWithStackTrace(Exception ex)
    {
        return Custom(Exceptions.TextOfExceptions(ex));
    }

    public static bool DifferentCountInLists<T>(string namefc, IList<T> countfc, string namesc, IList<T> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }

    public static bool DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc, namesc, countsc));
    }

    public static bool DifferentCountInListsTU<T, U>(string namefc, IList<T> countfc, string namesc, IList<U> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc, countsc.Count));
    }

    public static bool DirectoryExists(string path)
    {
        return ThrowIsNotNull(Exceptions.DirectoryExists(FullNameOfExecutedCode(), path));
    }

    public static bool DirectoryWasntFound(string directory)
    {
        return ThrowIsNotNull(Exceptions.DirectoryWasntFound(FullNameOfExecutedCode(), directory));
    }

    public static bool DivideByZero()
    {
        return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode()));
    }

    public static bool DoesntHaveRequiredType(string variableName)
    {
        return ThrowIsNotNull(Exceptions.DoesntHaveRequiredType(FullNameOfExecutedCode(), variableName));
    }

    public static bool DuplicatedElements(string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return ThrowIsNotNull(Exceptions.DuplicatedElements(FullNameOfExecutedCode(), nameOfVariable, duplicatedElements, message));
    }

    public static bool ElementCantBeFound(string nameCollection, string element)
    {
        return ThrowIsNotNull(Exceptions.ElementCantBeFound(FullNameOfExecutedCode(), nameCollection, element));
    }

    public static bool ElementWasntRemoved(string detailLocation, int before, int after)
    {
        return ThrowIsNotNull(Exceptions.ElementWasntRemoved(FullNameOfExecutedCode(), detailLocation, before, after));
    }

    public static bool ExcAsArg(Exception ex, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ExcAsArg, ex, message);
    }

    public static bool FileAlreadyExists(string path)
    {
        return ThrowIsNotNull(Exceptions.FileAlreadyExists, path);
    }

    public static bool FileDoesntExists(string fulLPath)
    {
        return ThrowIsNotNull(Exceptions.FileExists(FullNameOfExecutedCode(), fulLPath));
    }

    public static bool FileHasExtensionNotParseAbleToImageFormat(string fnOri)
    {
        return ThrowIsNotNull(Exceptions.FileHasExtensionNotParseAbleToImageFormat(FullNameOfExecutedCode(), fnOri));
    }

    public static bool FileSystemException(Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FileSystemException(FullNameOfExecutedCode(), ex));
    }

    public static bool FirstLetterIsNotUpper(string selectedFile)
    {
        return ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, selectedFile);
    }

    public static bool FolderCannotBeDeleted(string folder, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(), folder, ex));
    }

    public static bool FolderCantBeRemoved(string folder)
    {
        return ThrowIsNotNull(Exceptions.FolderCantBeRemoved(FullNameOfExecutedCode(), folder));
    }

    public static bool FolderIsNotEmpty(string variableName, string path)
    {
        return ThrowIsNotNull(Exceptions.FolderIsNotEmpty, variableName, path);
    }

    public static bool FunctionalityDenied(string functionalityName)
    {
        return ThrowIsNotNull(Exceptions.FunctionalityDenied(FullNameOfExecutedCode(), functionalityName));
    }

    public static bool HasNotKeyDictionary<Key, Value>(string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        return ThrowIsNotNull(Exceptions.HasNotKeyDictionary(FullNameOfExecutedCode(), nameDict, qsDict, remains));
    }

    public static bool HasOddNumberOfElements(string listName, ICollection list)
    {
        var f = Exceptions.HasOddNumberOfElements;
        return ThrowIsNotNull(f, listName, list);
    }

    public static bool HaveAllInnerSameCount(List<List<string>> elements)
    {
        return ThrowIsNotNull(Exceptions.HaveAllInnerSameCount(FullNameOfExecutedCode(), elements));
    }

    public static bool InvalidExactlyLength(string variableName, int length, int requiredLenght)
    {
        return ThrowIsNotNull(Exceptions.InvalidExactlyLength(FullNameOfExecutedCode(), variableName, length, requiredLenght));
    }

    public static bool InvalidParameter(string valueVar, string nameVar)
    {
        return ThrowIsNotNull(Exceptions.InvalidParameter(FullNameOfExecutedCode(), valueVar, nameVar));
    }

    public static bool IsEmpty(IEnumerable folders, string colName, string additionalMessage = "")
    {
        return ThrowIsNotNull(Exceptions.IsEmpty(FullNameOfExecutedCode(), folders, colName, additionalMessage));
    }

    public static bool IsNotAllowed(string what)
    {
        return ThrowIsNotNull(Exceptions.IsNotAllowed(FullNameOfExecutedCode(), what));
    }

    public static bool IsNotNull(string variableName, object variable)
    {
        return ThrowIsNotNull(Exceptions.IsNotNull(FullNameOfExecutedCode(), variableName, variable));
    }

    public static bool IsNotPositiveNumber(string nameOfVariable, int? n)
    {
        return ThrowIsNotNull(Exceptions.IsNotPositiveNumber(FullNameOfExecutedCode(), nameOfVariable, n));
    }

    public static bool IsNotWindowsPathFormat(string argName, string argValue, bool raiseIsNotWindowsPathFormat, Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsNotWindowsPathFormat(FullNameOfExecutedCode(), argName, argValue, raiseIsNotWindowsPathFormat, SunamoFileSystem_IsWindowsPathFormat));
    }

    public static bool IsNull(string variableName, object? variable = null)
    {
        return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable));
    }

    public static bool IsNullOrEmpty(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, true));
    }

    public static bool IsNullOrWhitespace(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, false));
    }

    public static bool IsTheSame(string fst, string sec)
    {
        return ThrowIsNotNull(Exceptions.IsTheSame(FullNameOfExecutedCode(), fst, sec));
    }

    public static bool IsWhitespaceOrNull(string variable, object data)
    {
        return ThrowIsNotNull(Exceptions.IsWhitespaceOrNull(FullNameOfExecutedCode(), variable, data));
    }

    public static bool IsWindowsPathFormat(string input, Func<string, bool> isWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsWindowsPathFormat(FullNameOfExecutedCode(), input, isWindowsPathFormat));
    }

    public static bool KeyNotFound<T, U>(IDictionary<T, U> en, string dictName, T key)
    {
        return ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(), en, dictName, key));
    }

    public static bool ListNullOrEmpty<T>(string variableName, IEnumerable<T>? list)
    {
        return ThrowIsNotNull(Exceptions.ListNullOrEmpty(FullNameOfExecutedCode(), variableName, list));
    }

    public static bool LockedByBitLocker(string path, Func<char, bool> IsLockedByBitLocker)
    {
        return ThrowIsNotNull(Exceptions.LockedByBitLocker(FullNameOfExecutedCode(), path, IsLockedByBitLocker));
    }

    public static bool MoreThanOneElement(string listName, int count, string moreInfo = "")
    {
        string fn = FullNameOfExecutedCode();
        string? exc = Exceptions.MoreThanOneElement(fn, listName, count, moreInfo);
        return ThrowIsNotNull(exc);
    }

    public static bool NameIsNotSetted(string nameControl, string nameFromProperty)
    {
        return ThrowIsNotNull(Exceptions.NameIsNotSetted(FullNameOfExecutedCode(), nameControl, nameFromProperty));
    }

    public static bool NoPassedFolders(ICollection folders)
    {
        return ThrowIsNotNull(Exceptions.NoPassedFolders(FullNameOfExecutedCode(), folders));
    }

    public static bool NotContains(string text, params string[] shouldContains)
    {
        return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(), text, shouldContains));
    }
}