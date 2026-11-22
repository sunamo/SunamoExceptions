namespace SunamoExceptions;

public partial class ThrowEx
{
    /// <summary>
    /// Not exists.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <returns>The not exists result.</returns>
    public static bool NotExists(string what)
    {
        return ThrowIsNotNull(Exceptions.NotExists(FullNameOfExecutedCode(), what));
    }

    /// <summary>
    /// Not implemented case.
    /// </summary>
    /// <param name="notImplementedName">The not implemented name.</param>
    /// <returns>The not implemented case result.</returns>
    public static bool NotImplementedCase(object notImplementedName)
    {
        return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName);
    }

    /// <summary>
    /// Not implemented method.
    /// </summary>
    /// <returns>The not implemented method result.</returns>
    public static bool NotImplementedMethod()
    {
        return ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }

    /// <summary>
    /// Not in range.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="list">The list.</param>
    /// <param name="isLt">The is lt.</param>
    /// <param name="isGt">The is gt.</param>
    /// <returns>The not in range result.</returns>
    public static bool NotInRange(string variableName, IEnumerable<string> list, int isLt, int isGt)
    {
        return ThrowIsNotNull(Exceptions.NotInRange(FullNameOfExecutedCode(), variableName, list, isLt, isGt));
    }

    /// <summary>
    /// Not int.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <param name="value">The value.</param>
    /// <returns>The not int result.</returns>
    public static bool NotInt(string what, int? value)
    {
        return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value));
    }

    /// <summary>
    /// Not supported.
    /// </summary>
    /// <returns>The not supported result.</returns>
    public static bool NotSupported()
    {
        return ThrowIsNotNull(Exceptions.NotSupported(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Not supported extension.
    /// </summary>
    /// <param name="extension">The extension.</param>
    /// <returns>The not supported extension result.</returns>
    public static bool NotSupportedExtension(string extension)
    {
        return ThrowIsNotNull(Exceptions.NotSupportedExtension, extension);
    }

    /// <summary>
    /// Only one element.
    /// </summary>
    /// <param name="colName">The col name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The only one element result.</returns>
    public static bool OnlyOneElement(string colName, ICollection list)
    {
        return ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), colName, list));
    }

    /// <summary>
    /// Out of range.
    /// </summary>
    /// <param name="colName">The col name.</param>
    /// <param name="col">The col.</param>
    /// <param name="indexName">The index name.</param>
    /// <param name="index">The index.</param>
    /// <returns>The out of range result.</returns>
    public static bool OutOfRange(string colName, ICollection col, string indexName, int index)
    {
        return ThrowIsNotNull(Exceptions.OutOfRange(FullNameOfExecutedCode(), colName, col, indexName, index));
    }

    /// <summary>
    /// Passed list instead of array t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="variableName">The variable name.</param>
    /// <param name="array">The array.</param>
    /// <param name="CA_IsListStringWrappedInArray">The CA is list string wrapped in array.</param>
    /// <returns>The passed list instead of array t result.</returns>
    public static bool PassedListInsteadOfArray<T>(string variableName, T[] array, Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        return ThrowIsNotNull(Exceptions.PassedListInsteadOfArray<T>(FullNameOfExecutedCode(), variableName, array.ToList(), CA_IsListStringWrappedInArray));
    }

    /// <summary>
    /// Repeat after time x times failed.
    /// </summary>
    /// <param name="times">The times.</param>
    /// <param name="timeoutInMs">The timeout in ms.</param>
    /// <param name="address">The address.</param>
    /// <param name="sharedAlgorithmSlastError">The shared algorithm slast error.</param>
    /// <returns>The repeat after time x times failed result.</returns>
    public static bool RepeatAfterTimeXTimesFailed(int times, int timeoutInMs, string address, int sharedAlgorithmSlastError)
    {
        return ThrowIsNotNull(Exceptions.RepeatAfterTimeXTimesFailed(FullNameOfExecutedCode(), times, timeoutInMs, address, sharedAlgorithmSlastError));
    }

    /// <summary>
    /// Start is higher than end.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <returns>The start is higher than end result.</returns>
    public static bool StartIsHigherThanEnd(int start, int end)
    {
        return ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(), start, end));
    }

    /// <summary>
    /// String contains un allowed substrings.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="unallowedStrings">The unallowed strings.</param>
    /// <returns>The string contains un allowed substrings result.</returns>
    public static bool StringContainsUnAllowedSubstrings(string input, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(Exceptions.StringContainsUnallowedSubstrings(FullNameOfExecutedCode(), input, unallowedStrings));
    }

    /// <summary>
    /// Uncomment after nugets finished.
    /// </summary>
    /// <returns>The uncomment after nugets finished result.</returns>
    public static bool UncommentAfterNugetsFinished()
    {
        return Custom("Uncomment after nugets finished");
    }

    /// <summary>
    /// Uri format.
    /// </summary>
    /// <param name="url">The url.</param>
    /// <param name="uhIsUri">The uh is uri.</param>
    /// <returns>The uri format result.</returns>
    public static bool UriFormat(string url, Func<string, bool> uhIsUri)
    {
        return ThrowIsNotNull(Exceptions.UriFormat, url, uhIsUri);
    }

    /// <summary>
    /// Use rlc.
    /// </summary>
    /// <returns>The use rlc result.</returns>
    public static bool UseRlc()
    {
        return ThrowIsNotNull(Exceptions.UseRlc(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Was already initialized.
    /// </summary>
    /// <returns>The was already initialized result.</returns>
    public static bool WasAlreadyInitialized()
    {
        return ThrowIsNotNull(Exceptions.WasAlreadyInitialized(FullNameOfExecutedCode()));
    }

    /// <summary>
    /// Was not keys handler.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="keysHandler">The keys handler.</param>
    /// <returns>The was not keys handler result.</returns>
    public static bool WasNotKeysHandler(string name, object keysHandler)
    {
        return ThrowIsNotNull(Exceptions.WasNotKeysHandler(FullNameOfExecutedCode(), name, keysHandler));
    }

    /// <summary>
    /// Wrong extension.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="requiredExt">The required ext.</param>
    /// <returns>The wrong extension result.</returns>
    public static bool WrongExtension(string path, string requiredExt)
    {
        return ThrowIsNotNull(Exceptions.WrongExtension(FullNameOfExecutedCode(), path, requiredExt));
    }

    /// <summary>
    /// Wrong number of elements t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="requireElements">The require elements.</param>
    /// <param name="nameCollection">The name collection.</param>
    /// <param name="collection">The collection.</param>
    /// <returns>The wrong number of elements t result.</returns>
    public static bool WrongNumberOfElements<T>(int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        return ThrowIsNotNull(Exceptions.WrongNumberOfElements(FullNameOfExecutedCode(), requireElements, nameCollection, collection));
    }

    /// <summary>
    /// Zero or more than one.
    /// </summary>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="list">The list.</param>
    /// <returns>The zero or more than one result.</returns>
    public static bool ZeroOrMoreThanOne(string nameOfVariable, List<string> list)
    {
        return ThrowIsNotNull(Exceptions.ZeroOrMoreThanOne(FullNameOfExecutedCode(), nameOfVariable, list));
    }

    /// <summary>
    /// Full name of executed code.
    /// </summary>
    /// <returns>The full name of executed code result.</returns>
    public static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfExc = Exceptions.PlaceOfException();
        string f = FullNameOfExecutedCode(placeOfExc.Item1, placeOfExc.Item2, true);
        return f;
    }

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
    /// Throw is not null.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <returns>The throw is not null result.</returns>
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
    /// Throw is not null.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="reallyThrow">The really throw.</param>
    /// <returns>The throw is not null result.</returns>
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
    /// Throw is not null a b.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="ex">The ex.</param>
    /// <param name="message">The message.</param>
    /// <returns>The throw is not null a b result.</returns>
    public static bool ThrowIsNotNull<A, B>(Func<string, A, B, string?> f, A ex, B message)
    {
        string? exc = f(FullNameOfExecutedCode(), ex, message);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Throw is not null a.
    /// </summary>
    /// <typeparam name="A">The type A.</typeparam>
    /// <param name="f">The f.</param>
    /// <param name="ex">The ex.</param>
    /// <returns>The throw is not null a result.</returns>
    public static bool ThrowIsNotNull<A>(Func<string, A, string?> f, A ex)
    {
        string? exc = f(FullNameOfExecutedCode(), ex);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Throw is not null.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <returns>The throw is not null result.</returns>
    public static bool ThrowIsNotNull(Func<string, string?> f)
    {
        string? exc = f(FullNameOfExecutedCode());
        return ThrowIsNotNull(exc);
    }
}
