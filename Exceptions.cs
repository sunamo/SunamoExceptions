namespace SunamoExceptions;
// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
    #region Other
    public static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    public static string? IsNotTheSame<T>(string before, string name1, T value1, string name2, T value2)
    {
        if (!EqualityComparer<T>.Default.Equals(value1, value2))
        {
            return $"{before}{name1}({value1}) differs from {name2}({value2})";
        }

        return null;
    }

    public static string? HasNotIndex<T>(string before, IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        if (list.Count() <= maxRequiredIndex)
        {
            return $"{before}{listName} dont have only {list.Count()} items but is required {maxRequiredIndex} indexes";
        }

        return null;
    }

    public static string TextOfExceptions(Exception ex)
    {
        return ex.GetAllMessages();
    }

    internal static Tuple<string, string, string> PlaceOfException(
bool fillAlsoFirstTwo = true)
    {
        StackTrace st = new();
        var v = st.ToString();
        var l = v.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        l.RemoveAt(0);
        var i = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; i < l.Count; i++)
        {
            var item = l[i];
            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                l.Add(string.Empty);
                l.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, l));
    }
    public static void TypeAndMethodName(string l, out string type, out string methodName)
    {
        var s2 = l.Split("at ")[1].Trim();
        var s = s2.Split("(")[0];
        var p = s.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = p[^1];
        p.RemoveAt(p.Count - 1);
        type = string.Join(".", p);
    }
    internal static string CallingMethod(int v = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(v)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion

    #region IsNullOrWhitespace
    public static string? IsNullOrWhitespace(string before, string argName, string argValue, bool notAllowOnlyWhitespace)
    {
        string addParams;
        if (argValue == null)
        {
            addParams = AddParams();
            return CheckBefore(before) + argName + " is null" + addParams;
        }
        if (argValue == string.Empty)
        {
            addParams = AddParams();
            return CheckBefore(before) + argName + " is empty (without trim)" + addParams;
        }
        if (notAllowOnlyWhitespace && argValue.Trim() == string.Empty)
        {
            addParams = AddParams();
            return CheckBefore(before) + argName + " is empty (with trim)" + addParams;
        }
        return null;
    }
    readonly static StringBuilder sbAdditionalInfoInner = new();
    readonly static StringBuilder sbAdditionalInfo = new();
    public static string AddParams()
    {
        sbAdditionalInfo.Insert(0, Environment.NewLine);
        sbAdditionalInfo.Insert(0, "Outer:");
        sbAdditionalInfo.Insert(0, Environment.NewLine);
        sbAdditionalInfoInner.Insert(0, Environment.NewLine);
        sbAdditionalInfoInner.Insert(0, "Inner:");
        sbAdditionalInfoInner.Insert(0, Environment.NewLine);
        var addParams = sbAdditionalInfo.ToString();
        var addParamsInner = sbAdditionalInfoInner.ToString();
        return addParams + addParamsInner;
    }
    #endregion

    #region OnlyReturnString 
    public static string? FolderIsNotEmpty(string before, string variableName, string path)
    {
        return before + $"Folder {path} is not empty. Variable name: {variableName}";
    }

    public static string? NotInRange(string before, string variableName, IEnumerable<string> list, int isLt, int isGt)
    {
        return before + $"{variableName} with items {string.Join(",", list)} is out of range, it is < {isLt} or > {isGt}";
    }

    public static string? NotSupportedExtension(string before, string extension)
    {
        return before + $"Extension {extension} is not supported";
    }

    public static string? UseRlc(string before)
    {
        return CheckBefore(before) + "Don't implement, use methods in rlc";
    }
    public static string? RepeatAfterTimeXTimesFailed(string before, int times, int timeoutInMs, string address,
    int sharedAlgorithmslastError)
    {
        return CheckBefore(before) +
        $"Loading uri {address} failed {times} ({timeoutInMs} ms timeout) HTTP Error: {sharedAlgorithmslastError}";
    }
    public static string? NotValidXml(string before, string path, Exception ex)
    {
        return CheckBefore(before) + path + " is not valid xml. " + TextOfExceptions(ex);
    }

    public static string? IsNotAllowed(string before, string what)
    {
        return CheckBefore(before) + what + " is not allowed.";
    }
    public static string? BadFormatOfElementInList(string before, object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return CheckBefore(before) + " Bad format of element" + " " + SH_NullToStringOrDefault(elVal) +
        " in list " + listName;
    }
    public static string? IsTheSame(string before, string fst, string sec)
    {
        return CheckBefore(before) + $"{fst} and {sec} has the same value";
    }
    public static string? DivideByZero(string before)
    {
        return CheckBefore(before) + " is dividing by zero.";
    }
    public static string? AnyElementIsNullOrEmpty(string before, string nameOfCollection, IEnumerable<int> nulled)
    {
        return CheckBefore(before) + $"In {nameOfCollection} has indexes " + string.Join(",", nulled) +
        " with null value";
    }
    public static string? NotEvenNumberOfElements(string before, string nameOfCollection)
    {
        return CheckBefore(before) + nameOfCollection + " have odd elements count";
    }
    public static string? InvalidExactlyLength(string before, string variableName, int length, int requiredLenght)
    {
        if (length != requiredLenght)
        {
            return CheckBefore(before) + variableName + $" have length {length}, required {requiredLenght}";
        }
        return null;
    }
    public static string? FileHasExtensionNotParseAbleToImageFormat(string before, string fnOri)
    {
        return CheckBefore(before) + "File " + fnOri + " has wrong file extension";
    }
    public static string? WrongCountInList(string before, int numberOfElementsWithoutPause, int numberOfElementsWithPause,
    int arrLength)
    {
        return CheckBefore(before) + string.Format("Array should have {0} or {1} elements, have {2}", numberOfElementsWithoutPause,
        numberOfElementsWithPause, arrLength);
    }
    public static string? FileExists(string before, string fulLPath)
    {
        return CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }
    public static string? FileWasntFoundInDirectory(string before, string path)
    {
        return CheckBefore(before) + "NotFound" + ": " + path;
    }
    public static string? NotSupported(string before)
    {
        return CheckBefore(before) + "Not supported";
    }
    public static string? ToManyElementsInCollection(string before, int max, int actual, string nameCollection)
    {
        return CheckBefore(before) + actual + " elements in " + nameCollection + ", maximum is " + max;
    }
    public static string? FunctionalityDenied(string before, string functionalityName)
    {
        return CheckBefore(before) + $"Functionality {functionalityName} is denied";
    }
    public static string? MoreCandidates(string before, IEnumerable<string> list, string item)
    {
        return CheckBefore(before) + "Under" + " " + item + " is more candidates: " + Environment.NewLine +
        string.Join(Environment.NewLine, list);
    }
    public static string? BadMappedXaml(string before, string nameControl, string additionalInfo)
    {
        return CheckBefore(before) + $"Bad mapped XAML in {nameControl}. {additionalInfo}";
    }
    public static string? ElementCantBeFound(string before, string nameCollection, string element)
    {
        return CheckBefore(before) + element + "cannot be found in " + nameCollection;
    }
    public static string? DoesntHaveRequiredType(string before, string variableName)
    {
        return CheckBefore(before) + variableName + "does not have required type" + ".";
    }
    public static string? ArgumentOutOfRangeException(string before, string paramName, string message)
    {
        return CheckBefore(before) + $"{paramName} is out of range, another info: {message}";
    }
    public static string? Custom(string before, string message)
    {
        return CheckBefore(before) + message;
    }
    public static string? FolderCannotBeDeleted(string before, string folder, Exception ex)
    {
        return CheckBefore(before) + $"{folder} cannot be deleted, another info: " + TextOfExceptions(ex);
    }
    public static string? CannotCreateDateTime(string before, int year, int month, int day, int hour, int minute, int seconds,
Exception ex)
    {
        return CheckBefore(before) +
        $"Cannot create DateTime with: year: {year} month: {month} day: {day} hour: {hour} minute: {minute} seconds: {seconds} " +
        TextOfExceptions(ex);
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
    #endregion

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
            var p = path[0];
            if (IsLockedByBitLocker(p))
            {
                return CheckBefore(before) + $"Drive {p}:\\ is locked by BitLocker";
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

    public static string? WrongNumberOfElements<T>(string before, int requireElements, string nameCollection,
    IEnumerable<T> collection)
    {
        var c = collection.Count();
        return c != requireElements ? CheckBefore(before) + $" {nameCollection} has {c}, it's required {requireElements}" : null;
    }

    public static string? DirectoryWasntFound(string before, string directory)
    {
        return !Directory.Exists(directory)
        ? CheckBefore(before) + " Directory" + " " + directory +
        " wasn't found."
        : null;
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
        else if ((data.ToString() ?? string.Empty).Trim() == string.Empty) isWhitespace = true;
        return isNull || isWhitespace ? CheckBefore(before) + variable + (isNull ? " is null" : " is whitespace") : null;
    }
    public static string? UncommentNextRows(string before)
    {
        return CheckBefore(before) + "Uncomment next rows";
    }
    public static string? OutOfRange(string before, string colName, ICollection col, string indexName, int index)
    {
        return col.Count <= index
        ? CheckBefore(before) + $"{index} (variable {indexName}) is out of range in {colName}"
        : null;
    }
    public static string? HaveAllInnerSameCount(string before, List<List<string>> elements)
    {
        var first = elements[0].Count;
        List<int> wrongCount = [];
        for (var i = 1; i < elements.Count; i++)
            if (first != elements[i].Count)
                wrongCount.Add(i);
        return wrongCount.Count > 0
        ? CheckBefore(before) + $"Elements {string.Join(',', wrongCount)} have different count than 0 (first)"
        : null;
    }
    public static string? DirectoryExists(string before, string fulLPath)
    {
        return Directory.Exists(fulLPath)
        ? null
        : CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
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
    public static string? ArrayElementContainsUnallowedStrings(string before, string arrayName, int dex,
    string valueElement, params string[] unallowedStrings)
    {
        var foundedUnallowed = unallowedStrings.Where(d => valueElement.Contains(d)).ToList();
        return foundedUnallowed.Count != 0
        ? CheckBefore(before) + "Element of" + " " + arrayName + " on index " + dex +
        " with value " + valueElement + " contains unallowed string(" + foundedUnallowed.Count + "): " +
        string.Join(',', unallowedStrings)
        : null;
    }
    public static string? StartIsHigherThanEnd(string before, int start, int end)
    {
        return start > end ? CheckBefore(before) + $"Start {start} is higher than end {end}" : null;
    }
    public static string? WasNotKeysHandler(string before, string name, object keysHandler)
    {
        return keysHandler == null
        ? CheckBefore(before) + name + " " + "was not IKeysHandler"
        : null;
    }
    public static string? FolderCantBeRemoved(string before, string folder)
    {
        return CheckBefore(before) + "Cannot delete folder" + ": " + folder;
    }
    public static string? ElementWasntRemoved(string before, string detailLocation, int before2, int after)
    {
        return before2 == after
        ? CheckBefore(before) + "Element was not removed during" + ": " +
        detailLocation
        : null;
    }
    public static string? NoPassedFolders(string before, ICollection folders)
    {
        return folders.Count == 0 ? CheckBefore(before) + "No passed folder into" : null;
    }
    public static string? FileSystemException(string v, Exception ex)
    {
        return ex != null ? CheckBefore(v) + " " + TextOfExceptions(ex) : null;
    }
    public static string? InvalidParameter(string before, string valueVar, string nameVar)
    {
        return valueVar != WebUtility.UrlDecode(valueVar)
        ? CheckBefore(before) + valueVar + " is url encoded " + nameVar
        : null;
    }
    public static string? MoreThanOneElement(string before, string listName, int count, string moreInfo = "")
    {
        return count > 1
        ? CheckBefore(before) + listName + " has " + count + " elements, which is more than 1. " + moreInfo
        : null;
    }
    public static string? NameIsNotSetted(string before, string nameControl, string nameFromProperty)
    {
        return string.IsNullOrWhiteSpace(nameFromProperty)
        ? CheckBefore(before) + nameControl + " " + "does not have setted name"
        : null;
    }
    public static string? OnlyOneElement(string before, string colName, ICollection list)
    {
        return list.Count == 1 ? CheckBefore(before) + colName + " has only one element" : null;
    }
    public static string? StringContainsUnallowedSubstrings(string before, string input,
    params string[] unallowedStrings)
    {
        List<string> foundedUnallowed = [];
        foreach (var item in unallowedStrings)
            if (input.Contains(item))
                foundedUnallowed.Add(item);
        return foundedUnallowed.Count > 0
        ? CheckBefore(before) + input + " contains unallowed chars: " +
        string.Join(string.Empty, unallowedStrings)
        : null;
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
        return CheckBefore(before) + "Not implemented case" + fr + " . public program error. Please contact developer" +
        ".";
    }
    public static string? NotContains(string before, string originalText, params string[] shouldContains)
    {
        List<string> notContained = [];
        foreach (var item in shouldContains)
            if (!originalText.Contains(item))
                notContained.Add(item);
        return notContained.Count == 0
        ? null
        : CheckBefore(before) + "Original text dont contains: " + string.Join(",", notContained) + ". Original text: " + originalText;
    }
    public static string? HasNotKeyDictionary<Key, Value>(string before, string nameDict, IDictionary<Key, Value> qsDict,
    Key remains)
    {
        return !qsDict.ContainsKey(remains) ? CheckBefore(before) + nameDict + " does not contains key " + remains : null;
    }
    public static string? IsEmpty(string before, IEnumerable folders, string colName,
    string additionalMessage = "")
    {
        return !folders.OfType<object>().Any()
        ? CheckBefore(before) + colName + " has no elements. " + additionalMessage
        : null;
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
            return CheckBefore(before) + " different count elements in collection" + " " +
            string.Concat(namefc + "-" + countfc) + " vs. " +
            string.Concat(namesc + "-" + countsc);
        return null;
    }
    public static string? FirstLetterIsNotUpper(string before, string p)
    {
        return p.Length == 0 ? null :
        char.IsLower(p[0]) ? CheckBefore(before) + "First letter is not upper: " + p : null;
    }
    public static string? KeyNotFound<T, U>(string before, IDictionary<T, U> en, string dictName, T key)
    {
        return !en.ContainsKey(key)
        ? CheckBefore(before) + key + " is not exists in dictionary" + " " + dictName
        : null;
    }
    public static string? DuplicatedElements(string before, string nameOfVariable, List<string> duplicatedElements,
    string message = "")
    {
        return duplicatedElements.Count != 0
        ? CheckBefore(before) + $"Duplicated elements in {nameOfVariable} list: " + string.Join(',', [.. duplicatedElements]) +
        " " + message
        : null;
    }
    public static string? ZeroOrMoreThanOne(string before, string nameOfVariable, List<string> list)
    {
        return list.Count == 0 || list.Count > 1
        ? CheckBefore(before) + $"{list.Count} elements in {nameOfVariable} which is zero or more than one"
        : null;
    }
    public static string? IsNotPositiveNumber(string before, string nameOfVariable, int? n)
    {
        return !n.HasValue ? CheckBefore(before) + nameOfVariable + " is not int" :
        n.Value > 0 ? null : CheckBefore(before) + nameOfVariable + " is int but not > 0";
    }
    public static string? CheckBackSlashEnd(string before, string r)
    {
        if (!r.EndsWith('\\')) return CheckBefore(before) + " " + r + " don't end with \\";
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