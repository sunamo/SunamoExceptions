namespace SunamoExceptions;

/// <summary>
/// Represents the throw ex type.
/// </summary>
public partial class ThrowEx
{
    /// <summary>
    /// Is not the same t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="name1">The name 1.</param>
    /// <param name="value1">The value 1.</param>
    /// <param name="name2">The name 2.</param>
    /// <param name="value2">The value 2.</param>
    /// <returns>The is not the same t result.</returns>
    public static bool IsNotTheSame<T>(string name1, T value1, string name2, T value2)
    {
        return ThrowIsNotNull(Exceptions.IsNotTheSame(FullNameOfExecutedCode(), name1, value1, name2, value2));
    }

    /// <summary>
    /// Folder does not exists.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="additionalInfo">The additional info.</param>
    /// <returns>The folder does not exists result.</returns>
    public static bool FolderDoesNotExists(string folder, string additionalInfo = "")
    {
        return ThrowIsNotNull(Exceptions.FolderDoesNotExists(FullNameOfExecutedCode(), folder, additionalInfo));
    }

    /// <summary>
    /// Key already exists t u.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key.</param>
    /// <param name="dictionaryName">The dictionary name.</param>
    /// <returns>The key already exists t u result.</returns>
    public static bool KeyAlreadyExists<T, U>(Dictionary<T, U> dictionary, T key, string dictionaryName) where T : notnull
    {
        return ThrowIsNotNull(Exceptions.KeyAlreadyExists(FullNameOfExecutedCode(), dictionary, key, dictionaryName));
    }

    /// <summary>
    /// Has not index t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="maxRequiredIndex">The max required index.</param>
    /// <returns>The has not index t result.</returns>
    public static bool HasNotIndex<T>(IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        return ThrowIsNotNull(Exceptions.HasNotIndex(FullNameOfExecutedCode(), list, listName, maxRequiredIndex));
    }

    /// <summary>
    /// Argument out of range exception.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="message">The message.</param>
    /// <returns>The argument out of range exception result.</returns>
    public static bool ArgumentOutOfRangeException(string argName, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), argName, message));
    }

    /// <summary>
    /// Array element contains un allowed strings.
    /// </summary>
    /// <param name="arrayName">The array name.</param>
    /// <param name="dex">The dex.</param>
    /// <param name="valueElement">The value element.</param>
    /// <param name="unallowedStrings">The unallowed strings.</param>
    /// <returns>The array element contains un allowed strings result.</returns>
    public static bool ArrayElementContainsUnAllowedStrings(string arrayName, int dex, string valueElement, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(Exceptions.ArrayElementContainsUnallowedStrings(FullNameOfExecutedCode(), arrayName, dex, valueElement, unallowedStrings));
    }

    /// <summary>
    /// Bad format of element in list.
    /// </summary>
    /// <param name="elVal">The el val.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="SH_NullToStringOrDefault">The SH null to string or default.</param>
    /// <returns>The bad format of element in list result.</returns>
    public static bool BadFormatOfElementInList(object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return ThrowIsNotNull(Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(), elVal, listName, SH_NullToStringOrDefault));
    }

    /// <summary>
    /// Bad mapped xaml.
    /// </summary>
    /// <param name="nameControl">The name control.</param>
    /// <param name="additionalInfo">The additional info.</param>
    /// <returns>The bad mapped xaml result.</returns>
    public static bool BadMappedXaml(string nameControl, string additionalInfo)
    {
        return ThrowIsNotNull(Exceptions.BadMappedXaml(FullNameOfExecutedCode(), nameControl, additionalInfo));
    }

    /// <summary>
    /// Cannot create date time.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <param name="hour">The hour.</param>
    /// <param name="minute">The minute.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The cannot create date time result.</returns>
    public static bool CannotCreateDateTime(int year, int month, int day, int hour, int minute, int seconds, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotCreateDateTime(FullNameOfExecutedCode(), year, month, day, hour, minute, seconds, ex));
    }

    /// <summary>
    /// Cannot move folder.
    /// </summary>
    /// <param name="sourcePath">The source path.</param>
    /// <param name="destinationPath">The destination path.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The cannot move folder result.</returns>
    public static bool CannotMoveFolder(string sourcePath, string destinationPath, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotMoveFolder(FullNameOfExecutedCode(), sourcePath, destinationPath, ex));
    }

    /// <summary>
    /// Check backslash end.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The check backslash end result.</returns>
    public static bool CheckBackslashEnd(string path)
    {
        return ThrowIsNotNull(Exceptions.CheckBackSlashEnd(FullNameOfExecutedCode(), path));
    }

    /// <summary>
    /// Custom.
    /// </summary>
    /// <param name="ex">The ex.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <returns>The custom result.</returns>
    public static bool Custom(Exception ex, bool reallyThrow = true)
    {
        return Custom(Exceptions.TextOfExceptions(ex), reallyThrow);
    }

    /// <summary>
    /// Custom.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <param name="secondMessage">The second message.</param>
    /// <returns>The custom result.</returns>
    public static bool Custom(string message, bool reallyThrow = true, string secondMessage = "")
    {
        string joined = string.Join(" ", message, secondMessage);
        string? str = Exceptions.Custom(FullNameOfExecutedCode(), joined);
        return ThrowIsNotNull(str, reallyThrow);
    }

    /// <summary>
    /// Custom with stack trace.
    /// </summary>
    /// <param name="ex">The ex.</param>
    /// <returns>The custom with stack trace result.</returns>
    public static bool CustomWithStackTrace(Exception ex)
    {
        return Custom(Exceptions.TextOfExceptions(ex));
    }

    /// <summary>
    /// Different count in lists t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="firstCollectionName">The first collection name.</param>
    /// <param name="firstCollection">The first collection.</param>
    /// <param name="secondCollectionName">The second collection name.</param>
    /// <param name="secondCollection">The second collection.</param>
    /// <returns>The different count in lists t result.</returns>
    public static bool DifferentCountInLists<T>(string firstCollectionName, IList<T> firstCollection, string secondCollectionName, IList<T> secondCollection)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), firstCollectionName, firstCollection.Count, secondCollectionName, secondCollection.Count));
    }

    /// <summary>
    /// Different count in lists.
    /// </summary>
    /// <param name="firstCollectionName">The first collection name.</param>
    /// <param name="firstCollectionCount">The first collection count.</param>
    /// <param name="secondCollectionName">The second collection name.</param>
    /// <param name="secondCollectionCount">The second collection count.</param>
    /// <returns>The different count in lists result.</returns>
    public static bool DifferentCountInLists(string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), firstCollectionName, firstCollectionCount, secondCollectionName, secondCollectionCount));
    }

    /// <summary>
    /// Different count in lists TU t u.
    /// </summary>
    /// <param name="firstCollectionName">The first collection name.</param>
    /// <param name="firstCollection">The first collection.</param>
    /// <param name="secondCollectionName">The second collection name.</param>
    /// <param name="secondCollection">The second collection.</param>
    /// <returns>The different count in lists TU t u result.</returns>
    public static bool DifferentCountInListsTU<T, U>(string firstCollectionName, IList<T> firstCollection, string secondCollectionName, IList<U> secondCollection)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), firstCollectionName, firstCollection.Count, secondCollectionName, secondCollection.Count));
    }

    /// <summary>
    /// Directory exists.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The directory exists result.</returns>
    public static bool DirectoryExists(string path)
    {
        return ThrowIsNotNull(Exceptions.DirectoryExists(FullNameOfExecutedCode(), path));
    }

    /// <summary>
    /// Directory wasnt found.
    /// </summary>
    /// <param name="directory">The directory.</param>
    /// <returns>The directory wasnt found result.</returns>
    public static bool DirectoryWasntFound(string directory)
    {
        return ThrowIsNotNull(Exceptions.DirectoryWasntFound(FullNameOfExecutedCode(), directory));
    }

    /// <summary>
    /// Divide by zero.
    /// </summary>
    /// <returns>The divide by zero result.</returns>
    public static bool DivideByZero()
    {
        return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Doesnt have required type.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The doesnt have required type result.</returns>
    public static bool DoesntHaveRequiredType(string variableName)
    {
        return ThrowIsNotNull(Exceptions.DoesntHaveRequiredType(FullNameOfExecutedCode(), variableName));
    }

    /// <summary>
    /// Duplicated elements.
    /// </summary>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="duplicatedElements">The duplicated elements.</param>
    /// <param name="message">The message.</param>
    /// <returns>The duplicated elements result.</returns>
    public static bool DuplicatedElements(string nameOfVariable, List<string> duplicatedElements, string message = "")
    {
        return ThrowIsNotNull(Exceptions.DuplicatedElements(FullNameOfExecutedCode(), nameOfVariable, duplicatedElements, message));
    }

    /// <summary>
    /// Element cant be found.
    /// </summary>
    /// <param name="nameCollection">The name collection.</param>
    /// <param name="element">The element.</param>
    /// <returns>The element cant be found result.</returns>
    public static bool ElementCantBeFound(string nameCollection, string element)
    {
        return ThrowIsNotNull(Exceptions.ElementCantBeFound(FullNameOfExecutedCode(), nameCollection, element));
    }

    /// <summary>
    /// Element wasnt removed.
    /// </summary>
    /// <param name="detailLocation">The detail location.</param>
    /// <param name="countBefore">The count before.</param>
    /// <param name="countAfter">The count after.</param>
    /// <returns>The element wasnt removed result.</returns>
    public static bool ElementWasntRemoved(string detailLocation, int countBefore, int countAfter)
    {
        return ThrowIsNotNull(Exceptions.ElementWasntRemoved(FullNameOfExecutedCode(), detailLocation, countBefore, countAfter));
    }

    /// <summary>
    /// Exc as arg.
    /// </summary>
    /// <param name="ex">The ex.</param>
    /// <param name="message">The message.</param>
    /// <returns>The exc as arg result.</returns>
    public static bool ExcAsArg(Exception ex, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ExcAsArg, ex, message);
    }

    /// <summary>
    /// File already exists.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The file already exists result.</returns>
    public static bool FileAlreadyExists(string path)
    {
        return ThrowIsNotNull(Exceptions.FileAlreadyExists, path);
    }

    /// <summary>
    /// File doesnt exists.
    /// </summary>
    /// <param name="fulLPath">The ful l path.</param>
    /// <returns>The file doesnt exists result.</returns>
    public static bool FileDoesntExists(string fulLPath)
    {
        return ThrowIsNotNull(Exceptions.FileExists(FullNameOfExecutedCode(), fulLPath));
    }

    /// <summary>
    /// File has extension not parse able to image format.
    /// </summary>
    /// <param name="fnOri">The fn ori.</param>
    /// <returns>The file has extension not parse able to image format result.</returns>
    public static bool FileHasExtensionNotParseAbleToImageFormat(string fnOri)
    {
        return ThrowIsNotNull(Exceptions.FileHasExtensionNotParseAbleToImageFormat(FullNameOfExecutedCode(), fnOri));
    }

    /// <summary>
    /// File system exception.
    /// </summary>
    /// <param name="ex">The ex.</param>
    /// <returns>The file system exception result.</returns>
    public static bool FileSystemException(Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FileSystemException(FullNameOfExecutedCode(), ex));
    }

    /// <summary>
    /// First letter is not upper.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The first letter is not upper result.</returns>
    public static bool FirstLetterIsNotUpper(string text)
    {
        return ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, text);
    }

    /// <summary>
    /// Folder cannot be deleted.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The folder cannot be deleted result.</returns>
    public static bool FolderCannotBeDeleted(string folder, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(), folder, ex));
    }

    /// <summary>
    /// Folder cant be removed.
    /// </summary>
    /// <param name="folder">The folder.</param>
    /// <returns>The folder cant be removed result.</returns>
    public static bool FolderCantBeRemoved(string folder)
    {
        return ThrowIsNotNull(Exceptions.FolderCantBeRemoved(FullNameOfExecutedCode(), folder));
    }

    /// <summary>
    /// Folder is not empty.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="path">The path.</param>
    /// <returns>The folder is not empty result.</returns>
    public static bool FolderIsNotEmpty(string variableName, string path)
    {
        return ThrowIsNotNull(Exceptions.FolderIsNotEmpty, variableName, path);
    }

    /// <summary>
    /// Functionality denied.
    /// </summary>
    /// <param name="functionalityName">The functionality name.</param>
    /// <returns>The functionality denied result.</returns>
    public static bool FunctionalityDenied(string functionalityName)
    {
        return ThrowIsNotNull(Exceptions.FunctionalityDenied(FullNameOfExecutedCode(), functionalityName));
    }

    /// <summary>
    /// Has not key dictionary key value.
    /// </summary>
    /// <param name="nameDict">The name dict.</param>
    /// <param name="qsDict">The qs dict.</param>
    /// <param name="remains">The remains.</param>
    /// <returns>The has not key dictionary key value result.</returns>
    public static bool HasNotKeyDictionary<Key, Value>(string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        return ThrowIsNotNull(Exceptions.HasNotKeyDictionary(FullNameOfExecutedCode(), nameDict, qsDict, remains));
    }

    /// <summary>
    /// Has odd number of elements.
    /// </summary>
    /// <param name="listName">The list name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The has odd number of elements result.</returns>
    public static bool HasOddNumberOfElements(string listName, ICollection list)
    {
        var f = Exceptions.HasOddNumberOfElements;
        return ThrowIsNotNull(f, listName, list);
    }

    /// <summary>
    /// Have all inner same count.
    /// </summary>
    /// <param name="elements">The elements.</param>
    /// <returns>The have all inner same count result.</returns>
    public static bool HaveAllInnerSameCount(List<List<string>> elements)
    {
        return ThrowIsNotNull(Exceptions.HaveAllInnerSameCount(FullNameOfExecutedCode(), elements));
    }

    /// <summary>
    /// Invalid exactly length.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="length">The length.</param>
    /// <param name="requiredLenght">The required lenght.</param>
    /// <returns>The invalid exactly length result.</returns>
    public static bool InvalidExactlyLength(string variableName, int length, int requiredLenght)
    {
        return ThrowIsNotNull(Exceptions.InvalidExactlyLength(FullNameOfExecutedCode(), variableName, length, requiredLenght));
    }

    /// <summary>
    /// Invalid parameter.
    /// </summary>
    /// <param name="valueVar">The value var.</param>
    /// <param name="nameVar">The name var.</param>
    /// <returns>The invalid parameter result.</returns>
    public static bool InvalidParameter(string valueVar, string nameVar)
    {
        return ThrowIsNotNull(Exceptions.InvalidParameter(FullNameOfExecutedCode(), valueVar, nameVar));
    }

    /// <summary>
    /// Is empty.
    /// </summary>
    /// <param name="folders">The folders.</param>
    /// <param name="colName">The col name.</param>
    /// <param name="additionalMessage">The additional message.</param>
    /// <returns>The is empty result.</returns>
    public static bool IsEmpty(IEnumerable folders, string colName, string additionalMessage = "")
    {
        return ThrowIsNotNull(Exceptions.IsEmpty(FullNameOfExecutedCode(), folders, colName, additionalMessage));
    }
}
