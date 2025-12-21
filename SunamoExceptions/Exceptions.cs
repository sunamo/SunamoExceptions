namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// © www.sunamo.cz. All Rights Reserved.
public sealed partial class Exceptions
{
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

    internal static Tuple<string, string, string> PlaceOfException(bool fillAlsoFirstTwo = true)
    {
        StackTrace st = new();
        var value = st.ToString();
        var lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var i = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; i < lines.Count; i++)
        {
            var stackLine = lines[i];
            if (fillAlsoFirstTwo)
                if (!stackLine.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(stackLine, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }

            if (stackLine.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }

        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }

    public static void TypeAndMethodName(string lines, out string type, out string methodName)
    {
        var s2 = lines.Split("at ")[1].Trim();
        var text = s2.Split("(")[0];
        var parameter = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parameter[^1];
        parameter.RemoveAt(parameter.Count - 1);
        type = string.Join(".", parameter);
    }

    internal static string CallingMethod(int value = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(value)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }

        var methodName = methodBase.Name;
        return methodName;
    }

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

    public static string? RepeatAfterTimeXTimesFailed(string before, int times, int timeoutInMs, string address, int sharedAlgorithmslastError)
    {
        return CheckBefore(before) + $"Loading uri {address} failed {times} ({timeoutInMs} ms timeout) HTTP Error: {sharedAlgorithmslastError}";
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
        return CheckBefore(before) + " Bad format of element" + " " + SH_NullToStringOrDefault(elVal) + " in list " + listName;
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
        return CheckBefore(before) + $"In {nameOfCollection} has indexes " + string.Join(",", nulled) + " with null value";
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

    public static string? WrongCountInList(string before, int numberOfElementsWithoutPause, int numberOfElementsWithPause, int arrLength)
    {
        return CheckBefore(before) + string.Format("Array should have {0} or {1} elements, have {2}", numberOfElementsWithoutPause, numberOfElementsWithPause, arrLength);
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
        return CheckBefore(before) + "Under" + " " + item + " is more candidates: " + Environment.NewLine + string.Join(Environment.NewLine, list);
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
}