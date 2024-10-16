namespace SunamoExceptions;
public partial class ThrowEx
{
    #region Other
    public static string FullNameOfExecutedCode()
    {
        var placeOfExc = Exceptions.PlaceOfException();
        var f = FullNameOfExecutedCode(placeOfExc.Item1, placeOfExc.Item2, true);
        return f;
    }
    private static string FullNameOfExecutedCode(object type, string methodName, bool fromThrowEx = false)
    {
        if (methodName == null)
        {
            var depth = 2;
            if (fromThrowEx) depth++;
            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type type2)
        {
            typeFullName = type2.FullName ?? "Type cannot be get via type is Type type2";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            var t = type.GetType();
            typeFullName = t.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }
    public static bool ThrowIsNotNull(string? exception, bool reallyThrow = true)
    {
        if (exception == null)
        {
            Debugger.Break();
            if (reallyThrow)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }
    public static bool ThrowIsNotNull(Exception exception, bool reallyThrow = true)
    {
        if (exception != null)
        {
            ThrowIsNotNull(exception.Message, reallyThrow);
            return false;
        }
        return true;
    }
    public static bool ThrowIsNotNull<A, B>(Func<string, A, B, string?> f, A ex, B message)
    {
        var exc = f(FullNameOfExecutedCode(), ex, message);
        return ThrowIsNotNull(exc);
    }
    public static bool ThrowIsNotNull<A>(Func<string, A, string?> f, A o)
    {
        var exc = f(FullNameOfExecutedCode(), o);
        return ThrowIsNotNull(exc);
    }
    public static bool ThrowIsNotNull(Func<string, string?> f)
    {
        var exc = f(FullNameOfExecutedCode());
        return ThrowIsNotNull(exc);
    }
    #endregion

    public static bool NotContains(string text, params string[] shouldContains)
    {
        return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(), text, shouldContains));
    }

    public static bool IsNotAllowed(string what)
    {
        return ThrowIsNotNull(Exceptions.IsNotAllowed(FullNameOfExecutedCode(), what));
    }
    public static bool BadFormatOfElementInList(object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return ThrowIsNotNull(Exceptions.BadFormatOfElementInList(FullNameOfExecutedCode(), elVal, listName, SH_NullToStringOrDefault));
    }

    public static bool IsTheSame(string fst, string sec)
    {
        return ThrowIsNotNull(Exceptions.IsTheSame(FullNameOfExecutedCode(), fst, sec));
    }
    public static bool WrongNumberOfElements(int requireElements, string nameCount, IEnumerable<string> ele)
    {
        return ThrowIsNotNull(Exceptions.WrongNumberOfElements(FullNameOfExecutedCode(), requireElements,
        nameCount, ele));
    }







    public static bool DirectoryWasntFound(string folder)
    {
        return ThrowIsNotNull(Exceptions.DirectoryWasntFound(FullNameOfExecutedCode(), folder));
    }
    public static bool DivideByZero()
    {
        return ThrowIsNotNull(Exceptions.DivideByZero(FullNameOfExecutedCode()));
    }
    public static bool ViolationSqlIndex(string tableName, string abcToStringColumnsInIndex)
    {
        return ThrowIsNotNull(Exceptions.ViolationSqlIndex(FullNameOfExecutedCode(), tableName,
        abcToStringColumnsInIndex));
    }
    public static bool Custom(Exception message, bool reallyThrow = true)
    {
        return Custom(Exceptions.TextOfExceptions(message), reallyThrow);
    }
    public static bool WrongExtension(string path, string ext)
    {
        return ThrowIsNotNull(Exceptions.WrongExtension(FullNameOfExecutedCode(), path, ext));
    }
    public static bool DuplicatedElements(string nameOfVariable, IList<string> d, string message = "")
    {
        return ThrowIsNotNull(Exceptions.DuplicatedElements(FullNameOfExecutedCode(), nameOfVariable, d, message));
    }
    public static bool ZeroOrMoreThanOne(string nameOfVariable, List<string> list)
    {
        return ThrowIsNotNull(Exceptions.ZeroOrMoreThanOne(FullNameOfExecutedCode(), nameOfVariable, list));
    }
    public static bool IsNotPositiveNumber(string nameOfVariable, int? n)
    {
        return ThrowIsNotNull(
        Exceptions.IsNotPositiveNumber(FullNameOfExecutedCode(), nameOfVariable, n)
        );
    }




    public static bool NotExists(string item)
    {
        return ThrowIsNotNull(
        Exceptions.NotExists(FullNameOfExecutedCode(), item)
        );
    }
    public static bool Socket(int socketError)
    {
        return ThrowIsNotNull(
        Exceptions.Socket(FullNameOfExecutedCode(), socketError)
        );
    }









    public static bool NotFoundTranslationKeyWithCustomError(string message)
    {
        return Custom(message);
    }
    public static bool NotFoundTranslationKeyWithoutCustomError(string message)
    {
        return Custom(message);
    }

    public static bool InvalidExactlyLength(string variableName, int length, int requiredLenght)
    {
        return ThrowIsNotNull(Exceptions.InvalidExactlyLength(FullNameOfExecutedCode(), variableName, length, requiredLenght));
    }

    public static bool LockedByBitLocker(string path, Func<char, bool> IsLockedByBitLocker)
    {
        return ThrowIsNotNull(Exceptions.LockedByBitLocker(FullNameOfExecutedCode(), path, IsLockedByBitLocker));

    }
    public static bool CallingSyncMethodInAsyncApp()
    {
        return Custom("Calling sync method in async app");
    }

    public static bool ExcAsArg(Exception ex, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ExcAsArg, ex, message);
    }
    public static bool Ftp(string message, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.Ftp, ex, message);
    }
    public static bool IO(string v)
    {
        return ThrowIsNotNull(Exceptions.IO, v);
    }
    public static bool InvalidOperation(string s)
    {
        return ThrowIsNotNull(Exceptions.InvalidOperation, s);
    }
    public static bool ArgumentOutOfRange(string s)
    {
        return ThrowIsNotNull(Exceptions.ArgumentOutOfRange, s);
    }

    public static bool InvalidCast(string v)
    {
        return ThrowIsNotNull(Exceptions.InvalidCast, v);
    }
    public static bool ObjectDisposed(string v)
    {
        return ThrowIsNotNull(Exceptions.ObjectDisposed, v);
    }
    public static bool Timeout(string v)
    {
        return ThrowIsNotNull(Exceptions.Timeout, v);
    }
    public static bool FtpSecurityNotAvailable(string v)
    {
        return ThrowIsNotNull(Exceptions.FtpSecurityNotAvailable, v);
    }

    public static bool FtpMissingSocket(Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FtpMissingSocket, ex);
    }
    public static bool UriFormat(string url, Func<string, bool> uhIsUri)
    {
        return ThrowIsNotNull(Exceptions.UriFormat, url, uhIsUri);
    }

    public static bool Format(string v)
    {
        return ThrowIsNotNull(Exceptions.Format, v);
    }


    public static bool UncommentAfterNugetsFinished()
    {
        return ThrowIsNotNull(FullNameOfExecutedCode());
    }


    public static bool FileAlreadyExists(string file)
    {
        return ThrowIsNotNull(Exceptions.FileAlreadyExists, file);
    }

    public static bool ListNullOrEmpty<T>(string variableName, IEnumerable<T>? t)
    {
        return ThrowIsNotNull(Exceptions.ListNullOrEmpty(FullNameOfExecutedCode(), variableName, t));
    }

    public static bool IsOdd(string colName, ICollection e)
    {
        var f = Exceptions.IsOdd;
        return ThrowIsNotNull(f, colName, e);
    }

    public static bool DifferentCountInListsTU<T, U>(string namefc, List<T> countfc, string namesc, List<U> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc,
        countsc.Count));
    }
    public static bool DifferentCountInLists<T>(string namefc, List<T> countfc, string namesc, List<T> countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc.Count, namesc,
        countsc.Count));
    }
    public static bool DifferentCountInLists(string namefc, int countfc, string namesc, int countsc)
    {
        return ThrowIsNotNull(Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), namefc, countfc, namesc,
        countsc));
    }
    public static bool Custom(string message, bool reallyThrow = true, string v2 = "")
    {
        var joined = string.Join(string.Empty, message, v2);
        var str = Exceptions.Custom(FullNameOfExecutedCode(), joined);
        return ThrowIsNotNull(str, reallyThrow);
    }

    public static bool IsNotWindowsPathFormat(string argName, string argValue, bool raiseIsNotWindowsPathFormat, Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsNotWindowsPathFormat(FullNameOfExecutedCode(), argName, argValue, raiseIsNotWindowsPathFormat, SunamoFileSystem_IsWindowsPathFormat));
    }

    public static bool IsNullOrEmpty(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue));
    }
    public static bool IsNullOrWhitespace(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue));
    }
    public static bool ArgumentOutOfRangeException(string paramName, string message = "")
    {
        return ThrowIsNotNull(Exceptions.ArgumentOutOfRangeException(FullNameOfExecutedCode(), paramName, message));
    }
    public static bool IsNull(string variableName, object? variable = null)
    {
        return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable));
    }

    public static bool NotImplementedCase(object niCase)
    {
        return ThrowIsNotNull(Exceptions.NotImplementedCase, niCase);
    }
    public static bool NotImplementedMethod()
    {
        return ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }

    public static bool StartIsHigherThanEnd(int start, int end)
    {
        return ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(), start, end));
    }
    public static bool FolderCannotBeDeleted(string repairedBlogPostsFolder, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FolderCannotBeDeleted(FullNameOfExecutedCode(), repairedBlogPostsFolder, ex));
    }










    public static bool KeyNotFound<T, U>(IDictionary<T, U> en, string dictName, T key)
    {
        return ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(), en, dictName,
        key));
    }
    public static bool FirstLetterIsNotUpper(string selectedFile)
    {
        return ThrowIsNotNull(Exceptions.FirstLetterIsNotUpper, selectedFile);
    }
    public static bool NotSupportedExtension(string extension)
    {
        return Custom("Extensions is not supported: " + extension);
    }

    public static bool BadMappedXaml(string nameControl, string additionalInfo)
    {
        return ThrowIsNotNull(Exceptions.BadMappedXaml(FullNameOfExecutedCode(), nameControl, additionalInfo));
    }
    public static bool CannotCreateDateTime(int year, int month, int day, int hour, int minute, int seconds,
    Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotCreateDateTime(FullNameOfExecutedCode(), year, month, day, hour, minute,
        seconds, ex));
    }







    public static bool FileDoesntExists(string fulLPath)
    {
        return ThrowIsNotNull(Exceptions.FileExists(FullNameOfExecutedCode(), fulLPath));
    }
    public static bool UseRlc()
    {
        return ThrowIsNotNull(Exceptions.UseRlc(FullNameOfExecutedCode()));
    }
    public static bool OutOfRange(string colName, ICollection col, string indexName, int index)
    {
        return ThrowIsNotNull(Exceptions.OutOfRange(FullNameOfExecutedCode(), colName, col, indexName,
        index));
    }
    public static bool CustomWithStackTrace(Exception ex)
    {
        return Custom(Exceptions.TextOfExceptions(ex));
    }






    public static bool DirectoryExists(string path)
    {
        return ThrowIsNotNull(Exceptions.DirectoryExists(FullNameOfExecutedCode(), path));
    }
    public static bool IsWhitespaceOrNull(string variable, object data)
    {
        return ThrowIsNotNull(Exceptions.IsWhitespaceOrNull(FullNameOfExecutedCode(), variable, data));
    }
    public static bool HaveAllInnerSameCount(List<List<string>> elements)
    {
        return ThrowIsNotNull(Exceptions.HaveAllInnerSameCount(FullNameOfExecutedCode(), elements));
    }

    public static bool NameIsNotSetted(string nameControl, string nameFromProperty)
    {
        return ThrowIsNotNull(Exceptions.NameIsNotSetted(FullNameOfExecutedCode(), nameControl, nameFromProperty));
    }
    public static bool HasNotKeyDictionary<Key, Value>(string nameDict, IDictionary<Key, Value> qsDict, Key remains)
    {
        return ThrowIsNotNull(Exceptions.HasNotKeyDictionary(FullNameOfExecutedCode(), nameDict,
        qsDict, remains));
    }
    public static bool DoesntHaveRequiredType(string variableName)
    {
        return ThrowIsNotNull(Exceptions.DoesntHaveRequiredType(FullNameOfExecutedCode(), variableName));
    }

    public static bool MoreThanOneElement(string listName, int count, string moreInfo = "")
    {
        var fn = FullNameOfExecutedCode();
        var exc = Exceptions.MoreThanOneElement(fn, listName, count, moreInfo);
        return ThrowIsNotNull(exc);
    }
    public static bool NotInt(string what, int? value)
    {
        return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value));
    }

    public static bool IsNotNull(string variableName, object variable)
    {
        return ThrowIsNotNull(Exceptions.IsNotNull(FullNameOfExecutedCode(), variableName, variable));
    }
    public static bool ArrayElementContainsUnAllowedStrings(string arrayName, int dex, string valueElement,
    params string[] unallowedStrings)
    {
        return ThrowIsNotNull(Exceptions.ArrayElementContainsUnallowedStrings(FullNameOfExecutedCode(), arrayName, dex,
        valueElement, unallowedStrings));
    }
    public static bool OnlyOneElement(string colName, ICollection list)
    {
        return ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), colName, list));
    }
    public static bool StringContainsUnAllowedSubstrings(string input, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(
        Exceptions.StringContainsUnallowedSubstrings(FullNameOfExecutedCode(), input, unallowedStrings));
    }








    public static bool InvalidParameter(string valueVar, string nameVar)
    {
        return ThrowIsNotNull(Exceptions.InvalidParameter(FullNameOfExecutedCode(), valueVar, nameVar));
    }
    public static bool ElementCantBeFound(string nameCollection, string element)
    {
        return ThrowIsNotNull(Exceptions.ElementCantBeFound(FullNameOfExecutedCode(), nameCollection, element));
    }

    public static bool NotSupported()
    {
        return ThrowIsNotNull(Exceptions.NotSupported(FullNameOfExecutedCode()));
    }
    public static bool CheckBackslashEnd(string r)
    {
        return ThrowIsNotNull(Exceptions.CheckBackSlashEnd(FullNameOfExecutedCode(), r));
    }
    public static bool WasNotKeysHandler(string name, object keysHandler)
    {
        return ThrowIsNotNull(Exceptions.WasNotKeysHandler(FullNameOfExecutedCode(), name, keysHandler));
    }
    public static bool IsEmpty(IEnumerable folders, string colName, string additionalMessage = "")
    {
        return ThrowIsNotNull(Exceptions.IsEmpty(FullNameOfExecutedCode(), folders, colName, additionalMessage));
    }
    public static bool NoPassedFolders(ICollection folders)
    {
        return ThrowIsNotNull(Exceptions.NoPassedFolders(FullNameOfExecutedCode(), folders));
    }
    public static bool RepeatAfterTimeXTimesFailed(int times, int timeoutInMs, string address,
    int sharedAlgorithmSlastError)
    {
        return ThrowIsNotNull(Exceptions.RepeatAfterTimeXTimesFailed(FullNameOfExecutedCode(), times,
        timeoutInMs, address, sharedAlgorithmSlastError));
    }








    public static bool ElementWasntRemoved(string detailLocation, int before, int after)
    {
        return ThrowIsNotNull(Exceptions.ElementWasntRemoved(FullNameOfExecutedCode(), detailLocation, before, after));
    }
    public static bool FolderCantBeRemoved(string folder)
    {
        return ThrowIsNotNull(Exceptions.FolderCantBeRemoved(FullNameOfExecutedCode(), folder));
    }
    public static bool FileHasExtensionNotParseAbleToImageFormat(string fnOri)
    {
        return ThrowIsNotNull(
        Exceptions.FileHasExtensionNotParseAbleToImageFormat(FullNameOfExecutedCode(), fnOri));
    }
    public static bool FileSystemException(Exception ex)
    {
        return ThrowIsNotNull(Exceptions.FileSystemException(FullNameOfExecutedCode(), ex));
    }
    public static bool FunctionalityDenied(string description)
    {
        return ThrowIsNotNull(Exceptions.FunctionalityDenied(FullNameOfExecutedCode(), description));
    }
    public static bool CannotMoveFolder(string item, string nova, Exception ex)
    {
        return ThrowIsNotNull(Exceptions.CannotMoveFolder(FullNameOfExecutedCode(), item, nova, ex));
    }

    public static bool WasAlreadyInitialized()
    {
        return ThrowIsNotNull(FullNameOfExecutedCode() + " was already initialized!");
    }

    public static bool IsWindowsPathFormat(string input, Func<string, bool> isWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsWindowsPathFormat(FullNameOfExecutedCode(), input, isWindowsPathFormat));
    }

    public static bool FolderIsNotEmpty(string variableName, string path)
    {
        return ThrowIsNotNull(FullNameOfExecutedCode() +
        $"Folder {path} is not empty. Variable name: {variableName}");
    }
    public static bool NotInRange(string variableName, List<string> item, int isLt, int isGt)
    {
        return ThrowIsNotNull(FullNameOfExecutedCode() +
        $"{variableName} with items {string.Join(",", item)} is out of range, it is < {isLt} or > {isGt}");
    }
    public static bool PassedListInsteadOfArray<T>(string variableName, T[] v, Func<List<T>, bool> CA_IsListStringWrappedInArray)
    {
        return ThrowIsNotNull(Exceptions.PassedListInsteadOfArray<T>(FullNameOfExecutedCode(), variableName, v.ToList(), CA_IsListStringWrappedInArray));
    }
}