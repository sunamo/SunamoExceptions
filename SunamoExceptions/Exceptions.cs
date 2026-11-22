namespace SunamoExceptions;

/// <summary>
/// Represents the exceptions type.
/// </summary>
public sealed partial class Exceptions
{
    /// <summary>
    /// Check before.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <returns>The check before result.</returns>
    public static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Is not the same t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="before">The before.</param>
    /// <param name="name1">The name 1.</param>
    /// <param name="value1">The value 1.</param>
    /// <param name="name2">The name 2.</param>
    /// <param name="value2">The value 2.</param>
    /// <returns>The is not the same t result.</returns>
    public static string? IsNotTheSame<T>(string before, string name1, T value1, string name2, T value2)
    {
        if (!EqualityComparer<T>.Default.Equals(value1, value2))
        {
            return $"{before}{name1}({value1}) differs from {name2}({value2})";
        }

        return null;
    }

    /// <summary>
    /// Has not index t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="before">The before.</param>
    /// <param name="list">The list.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="maxRequiredIndex">The max required index.</param>
    /// <returns>The has not index t result.</returns>
    public static string? HasNotIndex<T>(string before, IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        if (list.Count() <= maxRequiredIndex)
        {
            return $"{before}{listName} dont have only {list.Count()} items but is required {maxRequiredIndex} indexes";
        }

        return null;
    }

    /// <summary>
    /// Text of exceptions.
    /// </summary>
    /// <param name="ex">The ex.</param>
    /// <returns>The text of exceptions result.</returns>
    public static string TextOfExceptions(Exception ex)
    {
        return ex.GetAllMessages();
    }

    internal static Tuple<string, string, string> PlaceOfException(bool isFillAlsoFirstTwo = true)
    {
        StackTrace st = new();
        var stackTraceText = st.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var i = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; i < lines.Count; i++)
        {
            var stackLine = lines[i];
            if (isFillAlsoFirstTwo)
                if (!stackLine.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(stackLine, out type, out methodName);
                    isFillAlsoFirstTwo = false;
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

    /// <summary>
    /// Type and method name.
    /// </summary>
    /// <param name="stackTraceLine">The stack trace line.</param>
    /// <param name="type">The type.</param>
    /// <param name="methodName">The method name.</param>
    public static void TypeAndMethodName(string stackTraceLine, out string type, out string methodName)
    {
        var methodFullName = stackTraceLine.Split(new[] { "at " }, StringSplitOptions.None)[1].Trim();
        var methodSignature = methodFullName.Split(new[] { "(" }, StringSplitOptions.None)[0];
        var parts = methodSignature.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        type = string.Join(".", parts);
    }

    /// <summary>
    /// Returns the name of the method at the given depth of the current call stack (1 = the caller of the method that calls this).
    /// </summary>
    /// <param name="stackFrameDepth">Depth in the call stack; 1 is the caller of the calling method.</param>
    /// <returns>The method name, or a fixed message when it cannot be determined.</returns>
    public static string CallingMethod(int stackFrameDepth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(stackFrameDepth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }

        var methodName = methodBase.Name;
        return methodName;
    }

    /// <summary>
    /// Is null or whitespace.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <param name="notAllowOnlyWhitespace">The not allow only whitespace.</param>
    /// <returns>The is null or whitespace result.</returns>
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

    /// <summary>
    /// Add params.
    /// </summary>
    /// <returns>The add params result.</returns>
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

    /// <summary>
    /// Folder is not empty.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="path">The path.</param>
    /// <returns>The folder is not empty result.</returns>
    public static string? FolderIsNotEmpty(string before, string variableName, string path)
    {
        return before + $"Folder {path} is not empty. Variable name: {variableName}";
    }

    /// <summary>
    /// Not in range.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="list">The list.</param>
    /// <param name="isLt">The is lt.</param>
    /// <param name="isGt">The is gt.</param>
    /// <returns>The not in range result.</returns>
    public static string? NotInRange(string before, string variableName, IEnumerable<string> list, int isLt, int isGt)
    {
        return before + $"{variableName} with items {string.Join(",", list)} is out of range, it is < {isLt} or > {isGt}";
    }

    /// <summary>
    /// Not supported extension.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="extension">The extension.</param>
    /// <returns>The not supported extension result.</returns>
    public static string? NotSupportedExtension(string before, string extension)
    {
        return before + $"Extension {extension} is not supported";
    }

    /// <summary>
    /// Use rlc.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <returns>The use rlc result.</returns>
    public static string? UseRlc(string before)
    {
        return CheckBefore(before) + "Don't implement, use methods in rlc";
    }

    /// <summary>
    /// Repeat after time x times failed.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="times">The times.</param>
    /// <param name="timeoutInMs">The timeout in ms.</param>
    /// <param name="address">The address.</param>
    /// <param name="sharedAlgorithmslastError">The shared algorithmslast error.</param>
    /// <returns>The repeat after time x times failed result.</returns>
    public static string? RepeatAfterTimeXTimesFailed(string before, int times, int timeoutInMs, string address, int sharedAlgorithmslastError)
    {
        return CheckBefore(before) + $"Loading uri {address} failed {times} ({timeoutInMs} ms timeout) HTTP Error: {sharedAlgorithmslastError}";
    }

    /// <summary>
    /// Not valid xml.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="path">The path.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The not valid xml result.</returns>
    public static string? NotValidXml(string before, string path, Exception ex)
    {
        return CheckBefore(before) + path + " is not valid xml. " + TextOfExceptions(ex);
    }

    /// <summary>
    /// Is not allowed.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="what">The what.</param>
    /// <returns>The is not allowed result.</returns>
    public static string? IsNotAllowed(string before, string what)
    {
        return CheckBefore(before) + what + " is not allowed.";
    }

    /// <summary>
    /// Bad format of element in list.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="elVal">The el val.</param>
    /// <param name="listName">The list name.</param>
    /// <param name="SH_NullToStringOrDefault">The SH null to string or default.</param>
    /// <returns>The bad format of element in list result.</returns>
    public static string? BadFormatOfElementInList(string before, object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return CheckBefore(before) + " Bad format of element" + " " + SH_NullToStringOrDefault(elVal) + " in list " + listName;
    }

    /// <summary>
    /// Is the same.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="fst">The fst.</param>
    /// <param name="sec">The sec.</param>
    /// <returns>The is the same result.</returns>
    public static string? IsTheSame(string before, string fst, string sec)
    {
        return CheckBefore(before) + $"{fst} and {sec} has the same value";
    }

    /// <summary>
    /// Divide by zero.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <returns>The divide by zero result.</returns>
    public static string? DivideByZero(string before)
    {
        return CheckBefore(before) + " is dividing by zero.";
    }

    /// <summary>
    /// Any element is null or empty.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameOfCollection">The name of collection.</param>
    /// <param name="nulled">The nulled.</param>
    /// <returns>The any element is null or empty result.</returns>
    public static string? AnyElementIsNullOrEmpty(string before, string nameOfCollection, IEnumerable<int> nulled)
    {
        return CheckBefore(before) + $"In {nameOfCollection} has indexes " + string.Join(",", nulled) + " with null value";
    }

    /// <summary>
    /// Not even number of elements.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameOfCollection">The name of collection.</param>
    /// <returns>The not even number of elements result.</returns>
    public static string? NotEvenNumberOfElements(string before, string nameOfCollection)
    {
        return CheckBefore(before) + nameOfCollection + " have odd elements count";
    }

    /// <summary>
    /// Invalid exactly length.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <param name="length">The length.</param>
    /// <param name="requiredLenght">The required lenght.</param>
    /// <returns>The invalid exactly length result.</returns>
    public static string? InvalidExactlyLength(string before, string variableName, int length, int requiredLenght)
    {
        if (length != requiredLenght)
        {
            return CheckBefore(before) + variableName + $" have length {length}, required {requiredLenght}";
        }

        return null;
    }

    /// <summary>
    /// File has extension not parse able to image format.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="fnOri">The fn ori.</param>
    /// <returns>The file has extension not parse able to image format result.</returns>
    public static string? FileHasExtensionNotParseAbleToImageFormat(string before, string fnOri)
    {
        return CheckBefore(before) + "File " + fnOri + " has wrong file extension";
    }

    /// <summary>
    /// Wrong count in list.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="numberOfElementsWithoutPause">The number of elements without pause.</param>
    /// <param name="numberOfElementsWithPause">The number of elements with pause.</param>
    /// <param name="arrLength">The arr length.</param>
    /// <returns>The wrong count in list result.</returns>
    public static string? WrongCountInList(string before, int numberOfElementsWithoutPause, int numberOfElementsWithPause, int arrLength)
    {
        return CheckBefore(before) + string.Format("Array should have {0} or {1} elements, have {2}", numberOfElementsWithoutPause, numberOfElementsWithPause, arrLength);
    }

    /// <summary>
    /// File exists.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="fulLPath">The ful l path.</param>
    /// <returns>The file exists result.</returns>
    public static string? FileExists(string before, string fulLPath)
    {
        return CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }

    /// <summary>
    /// File wasnt found in directory.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="path">The path.</param>
    /// <returns>The file wasnt found in directory result.</returns>
    public static string? FileWasntFoundInDirectory(string before, string path)
    {
        return CheckBefore(before) + "NotFound" + ": " + path;
    }

    /// <summary>
    /// Not supported.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <returns>The not supported result.</returns>
    public static string? NotSupported(string before)
    {
        return CheckBefore(before) + "Not supported";
    }

    /// <summary>
    /// To many elements in collection.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="max">The max.</param>
    /// <param name="actual">The actual.</param>
    /// <param name="nameCollection">The name collection.</param>
    /// <returns>The to many elements in collection result.</returns>
    public static string? ToManyElementsInCollection(string before, int max, int actual, string nameCollection)
    {
        return CheckBefore(before) + actual + " elements in " + nameCollection + ", maximum is " + max;
    }

    /// <summary>
    /// Functionality denied.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="functionalityName">The functionality name.</param>
    /// <returns>The functionality denied result.</returns>
    public static string? FunctionalityDenied(string before, string functionalityName)
    {
        return CheckBefore(before) + $"Functionality {functionalityName} is denied";
    }

    /// <summary>
    /// More candidates.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="list">The list.</param>
    /// <param name="item">The item.</param>
    /// <returns>The more candidates result.</returns>
    public static string? MoreCandidates(string before, IEnumerable<string> list, string item)
    {
        return CheckBefore(before) + "Under" + " " + item + " is more candidates: " + Environment.NewLine + string.Join(Environment.NewLine, list);
    }

    /// <summary>
    /// Bad mapped xaml.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameControl">The name control.</param>
    /// <param name="additionalInfo">The additional info.</param>
    /// <returns>The bad mapped xaml result.</returns>
    public static string? BadMappedXaml(string before, string nameControl, string additionalInfo)
    {
        return CheckBefore(before) + $"Bad mapped XAML in {nameControl}. {additionalInfo}";
    }

    /// <summary>
    /// Element cant be found.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="nameCollection">The name collection.</param>
    /// <param name="element">The element.</param>
    /// <returns>The element cant be found result.</returns>
    public static string? ElementCantBeFound(string before, string nameCollection, string element)
    {
        return CheckBefore(before) + element + "cannot be found in " + nameCollection;
    }

    /// <summary>
    /// Doesnt have required type.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="variableName">The variable name.</param>
    /// <returns>The doesnt have required type result.</returns>
    public static string? DoesntHaveRequiredType(string before, string variableName)
    {
        return CheckBefore(before) + variableName + "does not have required type" + ".";
    }

    /// <summary>
    /// Argument out of range exception.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="paramName">The param name.</param>
    /// <param name="message">The message.</param>
    /// <returns>The argument out of range exception result.</returns>
    public static string? ArgumentOutOfRangeException(string before, string paramName, string message)
    {
        return CheckBefore(before) + $"{paramName} is out of range, another info: {message}";
    }

    /// <summary>
    /// Custom.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="message">The message.</param>
    /// <returns>The custom result.</returns>
    public static string? Custom(string before, string message)
    {
        return CheckBefore(before) + message;
    }

    /// <summary>
    /// Folder cannot be deleted.
    /// </summary>
    /// <param name="before">The before.</param>
    /// <param name="folder">The folder.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The folder cannot be deleted result.</returns>
    public static string? FolderCannotBeDeleted(string before, string folder, Exception ex)
    {
        return CheckBefore(before) + $"{folder} cannot be deleted, another info: " + TextOfExceptions(ex);
    }
}
