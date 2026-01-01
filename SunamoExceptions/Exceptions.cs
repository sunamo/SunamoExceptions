namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// © www.sunamo.cz. All Rights Reserved.

/// <summary>
/// Provides static methods for generating exception messages with consistent formatting.
/// </summary>
public sealed partial class Exceptions
{
    /// <summary>
    /// Checks and formats the 'before' parameter, adding a colon separator if not empty.
    /// </summary>
    /// <param name="before">The prefix text to check and format.</param>
    /// <returns>Empty string if <paramref name="before"/> is null or whitespace, otherwise <paramref name="before"/> with ": " appended.</returns>
    public static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Checks if two values are not equal and returns an error message if they differ.
    /// </summary>
    /// <typeparam name="T">The type of values to compare.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="name1">The name of the first value.</param>
    /// <param name="value1">The first value to compare.</param>
    /// <param name="name2">The name of the second value.</param>
    /// <param name="value2">The second value to compare.</param>
    /// <returns>An error message if values differ, otherwise null.</returns>
    public static string? IsNotTheSame<T>(string before, string name1, T value1, string name2, T value2)
    {
        if (!EqualityComparer<T>.Default.Equals(value1, value2))
        {
            return $"{before}{name1}({value1}) differs from {name2}({value2})";
        }

        return null;
    }

    /// <summary>
    /// Checks if a list has enough elements to access the specified index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="list">The list to check.</param>
    /// <param name="listName">The name of the list for the error message.</param>
    /// <param name="maxRequiredIndex">The maximum index that must be accessible.</param>
    /// <returns>An error message if the list doesn't have enough elements, otherwise null.</returns>
    public static string? HasNotIndex<T>(string before, IEnumerable<T> list, string listName, int maxRequiredIndex)
    {
        if (list.Count() <= maxRequiredIndex)
        {
            return $"{before}{listName} dont have only {list.Count()} items but is required {maxRequiredIndex} indexes";
        }

        return null;
    }

    /// <summary>
    /// Gets all messages from an exception and its inner exceptions.
    /// </summary>
    /// <param name="ex">The exception to extract messages from.</param>
    /// <returns>A string containing all exception messages.</returns>
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

    /// <summary>
    /// Extracts type and method name from a stack trace line.
    /// </summary>
    /// <param name="lines">The stack trace line to parse.</param>
    /// <param name="type">The extracted type name.</param>
    /// <param name="methodName">The extracted method name.</param>
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

    /// <summary>
    /// Checks if a string argument is null, empty, or whitespace.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="argValue">The value to check.</param>
    /// <param name="notAllowOnlyWhitespace">If true, whitespace-only strings are also considered invalid.</param>
    /// <returns>An error message if validation fails, otherwise null.</returns>
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
    /// Adds additional parameter information to exception messages.
    /// </summary>
    /// <returns>A formatted string containing additional parameter information.</returns>
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
    /// Creates an error message indicating that a folder is not empty.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The name of the variable.</param>
    /// <param name="path">The path to the folder.</param>
    /// <returns>An error message.</returns>
    public static string? FolderIsNotEmpty(string before, string variableName, string path)
    {
        return before + $"Folder {path} is not empty. Variable name: {variableName}";
    }

    /// <summary>
    /// Checks if a variable is within the specified range.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The name of the variable.</param>
    /// <param name="list">The list of items.</param>
    /// <param name="isLt">The lower bound.</param>
    /// <param name="isGt">The upper bound.</param>
    /// <returns>An error message if out of range, otherwise null.</returns>
    public static string? NotInRange(string before, string variableName, IEnumerable<string> list, int isLt, int isGt)
    {
        return before + $"{variableName} with items {string.Join(",", list)} is out of range, it is < {isLt} or > {isGt}";
    }

    /// <summary>
    /// Creates an error message for an unsupported file extension.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="extension">The unsupported extension.</param>
    /// <returns>An error message.</returns>
    public static string? NotSupportedExtension(string before, string extension)
    {
        return before + $"Extension {extension} is not supported";
    }

    /// <summary>
    /// Creates an error message indicating that RLC methods should be used instead.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <returns>An error message.</returns>
    public static string? UseRlc(string before)
    {
        return CheckBefore(before) + "Don't implement, use methods in rlc";
    }

    /// <summary>
    /// Creates an error message for repeated failed attempts to load a URI.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="times">Number of failed attempts.</param>
    /// <param name="timeoutInMs">Timeout in milliseconds.</param>
    /// <param name="address">The URI address.</param>
    /// <param name="sharedAlgorithmslastError">The last HTTP error code.</param>
    /// <returns>An error message.</returns>
    public static string? RepeatAfterTimeXTimesFailed(string before, int times, int timeoutInMs, string address, int sharedAlgorithmslastError)
    {
        return CheckBefore(before) + $"Loading uri {address} failed {times} ({timeoutInMs} ms timeout) HTTP Error: {sharedAlgorithmslastError}";
    }

    /// <summary>
    /// Creates an error message for invalid XML.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="path">The path to the XML file.</param>
    /// <param name="ex">The exception that occurred.</param>
    /// <returns>An error message.</returns>
    public static string? NotValidXml(string before, string path, Exception ex)
    {
        return CheckBefore(before) + path + " is not valid xml. " + TextOfExceptions(ex);
    }

    /// <summary>
    /// Creates an error message indicating that something is not allowed.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="what">What is not allowed.</param>
    /// <returns>An error message.</returns>
    public static string? IsNotAllowed(string before, string what)
    {
        return CheckBefore(before) + what + " is not allowed.";
    }

    /// <summary>
    /// Creates an error message for a badly formatted element in a list.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="elVal">The element value.</param>
    /// <param name="listName">The name of the list.</param>
    /// <param name="SH_NullToStringOrDefault">Function to convert null to string.</param>
    /// <returns>An error message.</returns>
    public static string? BadFormatOfElementInList(string before, object elVal, string listName, Func<object, string> SH_NullToStringOrDefault)
    {
        return CheckBefore(before) + " Bad format of element" + " " + SH_NullToStringOrDefault(elVal) + " in list " + listName;
    }

    /// <summary>
    /// Creates an error message when two values are the same but should differ.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="fst">The first value name.</param>
    /// <param name="sec">The second value name.</param>
    /// <returns>An error message.</returns>
    public static string? IsTheSame(string before, string fst, string sec)
    {
        return CheckBefore(before) + $"{fst} and {sec} has the same value";
    }

    /// <summary>
    /// Creates an error message for division by zero.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <returns>An error message.</returns>
    public static string? DivideByZero(string before)
    {
        return CheckBefore(before) + " is dividing by zero.";
    }

    /// <summary>
    /// Creates an error message when collection elements are null or empty.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameOfCollection">The name of the collection.</param>
    /// <param name="nulled">Indexes of null/empty elements.</param>
    /// <returns>An error message.</returns>
    public static string? AnyElementIsNullOrEmpty(string before, string nameOfCollection, IEnumerable<int> nulled)
    {
        return CheckBefore(before) + $"In {nameOfCollection} has indexes " + string.Join(",", nulled) + " with null value";
    }

    /// <summary>
    /// Creates an error message when a collection has an odd number of elements.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameOfCollection">The name of the collection.</param>
    /// <returns>An error message.</returns>
    public static string? NotEvenNumberOfElements(string before, string nameOfCollection)
    {
        return CheckBefore(before) + nameOfCollection + " have odd elements count";
    }

    /// <summary>
    /// Validates that a variable has the exact required length.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The name of the variable.</param>
    /// <param name="length">The actual length.</param>
    /// <param name="requiredLenght">The required length.</param>
    /// <returns>An error message if lengths don't match, otherwise null.</returns>
    public static string? InvalidExactlyLength(string before, string variableName, int length, int requiredLenght)
    {
        if (length != requiredLenght)
        {
            return CheckBefore(before) + variableName + $" have length {length}, required {requiredLenght}";
        }

        return null;
    }

    /// <summary>
    /// Creates an error message for files with extensions that cannot be parsed to image format.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="fnOri">The original filename.</param>
    /// <returns>An error message.</returns>
    public static string? FileHasExtensionNotParseAbleToImageFormat(string before, string fnOri)
    {
        return CheckBefore(before) + "File " + fnOri + " has wrong file extension";
    }

    /// <summary>
    /// Creates an error message for wrong element count in a list.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="numberOfElementsWithoutPause">Expected count without pause.</param>
    /// <param name="numberOfElementsWithPause">Expected count with pause.</param>
    /// <param name="arrLength">Actual array length.</param>
    /// <returns>An error message.</returns>
    public static string? WrongCountInList(string before, int numberOfElementsWithoutPause, int numberOfElementsWithPause, int arrLength)
    {
        return CheckBefore(before) + string.Format("Array should have {0} or {1} elements, have {2}", numberOfElementsWithoutPause, numberOfElementsWithPause, arrLength);
    }

    /// <summary>
    /// Creates an error message when a file doesn't exist.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="fulLPath">The full path to the file.</param>
    /// <returns>An error message.</returns>
    public static string? FileExists(string before, string fulLPath)
    {
        return CheckBefore(before) + " " + "does not exists" + ": " + fulLPath;
    }

    /// <summary>
    /// Creates an error message when a file wasn't found in a directory.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="path">The path where the file was expected.</param>
    /// <returns>An error message.</returns>
    public static string? FileWasntFoundInDirectory(string before, string path)
    {
        return CheckBefore(before) + "NotFound" + ": " + path;
    }

    /// <summary>
    /// Creates a generic "not supported" error message.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <returns>An error message.</returns>
    public static string? NotSupported(string before)
    {
        return CheckBefore(before) + "Not supported";
    }

    /// <summary>
    /// Creates an error message when a collection has too many elements.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="max">Maximum allowed elements.</param>
    /// <param name="actual">Actual number of elements.</param>
    /// <param name="nameCollection">The name of the collection.</param>
    /// <returns>An error message.</returns>
    public static string? ToManyElementsInCollection(string before, int max, int actual, string nameCollection)
    {
        return CheckBefore(before) + actual + " elements in " + nameCollection + ", maximum is " + max;
    }

    /// <summary>
    /// Creates an error message when functionality is denied.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="functionalityName">The name of the denied functionality.</param>
    /// <returns>An error message.</returns>
    public static string? FunctionalityDenied(string before, string functionalityName)
    {
        return CheckBefore(before) + $"Functionality {functionalityName} is denied";
    }

    /// <summary>
    /// Creates an error message when there are multiple candidates.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="list">The list of candidates.</param>
    /// <param name="item">The item with multiple candidates.</param>
    /// <returns>An error message.</returns>
    public static string? MoreCandidates(string before, IEnumerable<string> list, string item)
    {
        return CheckBefore(before) + "Under" + " " + item + " is more candidates: " + Environment.NewLine + string.Join(Environment.NewLine, list);
    }

    /// <summary>
    /// Creates an error message for badly mapped XAML.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameControl">The name of the control.</param>
    /// <param name="additionalInfo">Additional information about the error.</param>
    /// <returns>An error message.</returns>
    public static string? BadMappedXaml(string before, string nameControl, string additionalInfo)
    {
        return CheckBefore(before) + $"Bad mapped XAML in {nameControl}. {additionalInfo}";
    }

    /// <summary>
    /// Creates an error message when an element cannot be found in a collection.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="nameCollection">The name of the collection.</param>
    /// <param name="element">The element that cannot be found.</param>
    /// <returns>An error message.</returns>
    public static string? ElementCantBeFound(string before, string nameCollection, string element)
    {
        return CheckBefore(before) + element + "cannot be found in " + nameCollection;
    }

    /// <summary>
    /// Creates an error message when a variable doesn't have the required type.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="variableName">The name of the variable.</param>
    /// <returns>An error message.</returns>
    public static string? DoesntHaveRequiredType(string before, string variableName)
    {
        return CheckBefore(before) + variableName + "does not have required type" + ".";
    }

    /// <summary>
    /// Creates an ArgumentOutOfRangeException error message.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="paramName">The name of the parameter.</param>
    /// <param name="message">Additional information.</param>
    /// <returns>An error message.</returns>
    public static string? ArgumentOutOfRangeException(string before, string paramName, string message)
    {
        return CheckBefore(before) + $"{paramName} is out of range, another info: {message}";
    }

    /// <summary>
    /// Creates a custom error message.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="message">The custom message.</param>
    /// <returns>An error message.</returns>
    public static string? Custom(string before, string message)
    {
        return CheckBefore(before) + message;
    }

    /// <summary>
    /// Creates an error message when a folder cannot be deleted.
    /// </summary>
    /// <param name="before">The prefix for the error message.</param>
    /// <param name="folder">The folder path.</param>
    /// <param name="ex">The exception that occurred.</param>
    /// <returns>An error message.</returns>
    public static string? FolderCannotBeDeleted(string before, string folder, Exception ex)
    {
        return CheckBefore(before) + $"{folder} cannot be deleted, another info: " + TextOfExceptions(ex);
    }
}