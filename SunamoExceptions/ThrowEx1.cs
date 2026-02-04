namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class ThrowEx
{
    /// <summary>
    /// Throws an exception if something does not exist.
    /// </summary>
    /// <param name="what">Description of what does not exist.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool NotExists(string what)
    {
        return ThrowIsNotNull(Exceptions.NotExists(FullNameOfExecutedCode(), what));
    }

    /// <summary>
    /// Throws an exception for a not implemented case.
    /// </summary>
    /// <param name="notImplementedName">Name or description of the not implemented case.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool NotImplementedCase(object notImplementedName)
    {
        return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName);
    }

    /// <summary>
    /// Throws an exception for a not implemented method.
    /// </summary>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool NotImplementedMethod()
    {
        return ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }

    /// <summary>
    /// Throws an exception if a variable is not in the expected range.
    /// </summary>
    /// <param name="variableName">Name of the variable being checked.</param>
    /// <param name="list">List of string values for context.</param>
    /// <param name="isLt">Lower bound threshold.</param>
    /// <param name="isGt">Upper bound threshold.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool NotInRange(string variableName, IEnumerable<string> list, int isLt, int isGt)
    {
        return ThrowIsNotNull(Exceptions.NotInRange(FullNameOfExecutedCode(), variableName, list, isLt, isGt));
    }

    /// <summary>
    /// Throws an exception if a value is not a valid integer.
    /// </summary>
    /// <param name="what">Description of what was expected to be an integer.</param>
    /// <param name="value">The value that failed integer validation.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool NotInt(string what, int? value)
    {
        return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value));
    }

    /// <summary>
    /// Throws an exception for a not supported operation.
    /// </summary>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool NotSupported()
    {
        return ThrowIsNotNull(Exceptions.NotSupported(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Throws an exception for a not supported file extension.
    /// </summary>
    /// <param name="extension">The unsupported file extension.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool NotSupportedExtension(string extension)
    {
        return ThrowIsNotNull(Exceptions.NotSupportedExtension, extension);
    }

    /// <summary>
    /// Throws an exception if a collection contains only one element when more were expected.
    /// </summary>
    /// <param name="colName">Name of the collection.</param>
    /// <param name="list">The collection being checked.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool OnlyOneElement(string colName, ICollection list)
    {
        return ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), colName, list));
    }

    /// <summary>
    /// Throws an exception if an index is out of range for a collection.
    /// </summary>
    /// <param name="colName">Name of the collection.</param>
    /// <param name="col">The collection being accessed.</param>
    /// <param name="indexName">Name of the index variable.</param>
    /// <param name="index">The index that is out of range.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool OutOfRange(string colName, ICollection col, string indexName, int index)
    {
        return ThrowIsNotNull(Exceptions.OutOfRange(FullNameOfExecutedCode(), colName, col, indexName, index));
    }

    /// <summary>
    /// Throws an exception if a list was passed instead of an array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="array">The array to check.</param>
    /// <param name="CA_IsListStringWrappedInArray">Function to check if the array wraps a list.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool PassedListInsteadOfArray<T>(string variableName, T[] array, Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        return ThrowIsNotNull(Exceptions.PassedListInsteadOfArray<T>(FullNameOfExecutedCode(), variableName, array.ToList(), CA_IsListStringWrappedInArray));
    }

    /// <summary>
    /// Throws an exception if a retry operation failed after multiple attempts.
    /// </summary>
    /// <param name="times">Number of retry attempts.</param>
    /// <param name="timeoutInMs">Timeout between retries in milliseconds.</param>
    /// <param name="address">Address or identifier of the operation that failed.</param>
    /// <param name="sharedAlgorithmSlastError">Last error code from the shared algorithm.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool RepeatAfterTimeXTimesFailed(int times, int timeoutInMs, string address, int sharedAlgorithmSlastError)
    {
        return ThrowIsNotNull(Exceptions.RepeatAfterTimeXTimesFailed(FullNameOfExecutedCode(), times, timeoutInMs, address, sharedAlgorithmSlastError));
    }

    /// <summary>
    /// Throws an exception if start index is higher than end index.
    /// </summary>
    /// <param name="start">The start index.</param>
    /// <param name="end">The end index.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool StartIsHigherThanEnd(int start, int end)
    {
        return ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(), start, end));
    }

    /// <summary>
    /// Throws an exception if a string contains unallowed substrings.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    /// <param name="unallowedStrings">Array of unallowed substrings.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool StringContainsUnAllowedSubstrings(string input, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(Exceptions.StringContainsUnallowedSubstrings(FullNameOfExecutedCode(), input, unallowedStrings));
    }

    /// <summary>
    /// Throws an exception prompting to uncomment code after NuGet packages are finished.
    /// </summary>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool UncommentAfterNugetsFinished()
    {
        return Custom("Uncomment after nugets finished");
    }

    /// <summary>
    /// Throws an exception if a URL has invalid URI format.
    /// </summary>
    /// <param name="url">The URL to validate.</param>
    /// <param name="uhIsUri">Function to check if the URL is a valid URI.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool UriFormat(string url, Func<string, bool> uhIsUri)
    {
        return ThrowIsNotNull(Exceptions.UriFormat, url, uhIsUri);
    }

    /// <summary>
    /// Throws an exception prompting to use RLC (Runtime Location Cache).
    /// </summary>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool UseRlc()
    {
        return ThrowIsNotNull(Exceptions.UseRlc(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Throws an exception if something was already initialized.
    /// </summary>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool WasAlreadyInitialized()
    {
        return ThrowIsNotNull(Exceptions.WasAlreadyInitialized(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Throws an exception if a keys handler is invalid.
    /// </summary>
    /// <param name="name">Name of the handler.</param>
    /// <param name="keysHandler">The keys handler object.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool WasNotKeysHandler(string name, object keysHandler)
    {
        return ThrowIsNotNull(Exceptions.WasNotKeysHandler(FullNameOfExecutedCode(), name, keysHandler));
    }

    /// <summary>
    /// Throws an exception if a file has the wrong extension.
    /// </summary>
    /// <param name="path">Path to the file.</param>
    /// <param name="requiredExt">The required file extension.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool WrongExtension(string path, string requiredExt)
    {
        return ThrowIsNotNull(Exceptions.WrongExtension(FullNameOfExecutedCode(), path, requiredExt));
    }

    /// <summary>
    /// Throws an exception if a collection has the wrong number of elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="requireElements">Required number of elements.</param>
    /// <param name="nameCollection">Name of the collection.</param>
    /// <param name="collection">The collection to check.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool WrongNumberOfElements<T>(int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        return ThrowIsNotNull(Exceptions.WrongNumberOfElements(FullNameOfExecutedCode(), requireElements, nameCollection, collection));
    }

    /// <summary>
    /// Throws an exception if a list has zero or more than one element.
    /// </summary>
    /// <param name="nameOfVariable">Name of the variable containing the list.</param>
    /// <param name="list">The list to check.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool ZeroOrMoreThanOne(string nameOfVariable, List<string> list)
    {
        return ThrowIsNotNull(Exceptions.ZeroOrMoreThanOne(FullNameOfExecutedCode(), nameOfVariable, list));
    }

    /// <summary>
    /// Gets the full name of the currently executing code (type and method name).
    /// </summary>
    /// <returns>A string in the format "FullTypeName.MethodName".</returns>
    public static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfExc = Exceptions.PlaceOfException();
        string f = FullNameOfExecutedCode(placeOfExc.Item1, placeOfExc.Item2, true);
        return f;
    }

    /// <summary>
    /// Gets the full name of the executing code from type and method name.
    /// </summary>
    /// <param name="type">The type object (can be Type, MethodBase, string, or any object).</param>
    /// <param name="methodName">Name of the method. If null, will be determined from call stack.</param>
    /// <param name="fromThrowEx">Indicates if called from ThrowEx (affects call stack depth).</param>
    /// <returns>A string in the format "FullTypeName.MethodName".</returns>
    static string FullNameOfExecutedCode(object type, string methodName, bool fromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (fromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }

        string typeFullName = "";
        if (type == null)
        {
            typeFullName = "";
        }

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
            Type? t = type?.GetType();
            typeFullName = t?.FullName ?? "Type cannot be get via type.GetType()";
        }

        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws an exception if the exception string is not null.
    /// </summary>
    /// <param name="exception">The exception message string. If not null, throws an exception.</param>
    /// <param name="reallyThrow">Whether to actually throw the exception (true) or just break in debugger (false).</param>
    /// <returns>True if exception was detected, false if exception is null.</returns>
    public static bool ThrowIsNotNull(string? exception, bool reallyThrow = true)
    {
        if (exception != null)
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

    /// <summary>
    /// Throws an exception if the exception object is not null.
    /// </summary>
    /// <param name="exception">The exception object. If not null, throws an exception with its message.</param>
    /// <param name="reallyThrow">Whether to actually throw the exception (true) or just break in debugger (false).</param>
    /// <returns>True if no exception was thrown, false otherwise.</returns>
    public static bool ThrowIsNotNull(Exception exception, bool reallyThrow = true)
    {
        if (exception != null)
        {
            ThrowIsNotNull(exception.Message, reallyThrow);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Throws an exception using a factory function with two arguments.
    /// </summary>
    /// <typeparam name="A">Type of the first argument.</typeparam>
    /// <typeparam name="B">Type of the second argument.</typeparam>
    /// <param name="f">Factory function that generates the exception message.</param>
    /// <param name="ex">First argument to the factory function.</param>
    /// <param name="message">Second argument to the factory function.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool ThrowIsNotNull<A, B>(Func<string, A, B, string?> f, A ex, B message)
    {
        string? exc = f(FullNameOfExecutedCode(), ex, message);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Throws an exception using a factory function with one argument.
    /// </summary>
    /// <typeparam name="A">Type of the argument.</typeparam>
    /// <param name="f">Factory function that generates the exception message.</param>
    /// <param name="ex">Argument to the factory function.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool ThrowIsNotNull<A>(Func<string, A, string?> f, A ex)
    {
        string? exc = f(FullNameOfExecutedCode(), ex);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Throws an exception using a factory function with no arguments.
    /// </summary>
    /// <param name="f">Factory function that generates the exception message.</param>
    /// <returns>True if exception was thrown, false otherwise.</returns>
    public static bool ThrowIsNotNull(Func<string, string?> f)
    {
        string? exc = f(FullNameOfExecutedCode());
        return ThrowIsNotNull(exc);
    }
}