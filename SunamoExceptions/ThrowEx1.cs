namespace SunamoExceptions;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class ThrowEx
{
    public static bool NotExists(string what)
    {
        return ThrowIsNotNull(Exceptions.NotExists(FullNameOfExecutedCode(), what));
    }

    public static bool NotImplementedCase(object notImplementedName)
    {
        return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName);
    }

    public static bool NotImplementedMethod()
    {
        return ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }

    public static bool NotInRange(string variableName, IEnumerable<string> list, int isLt, int isGt)
    {
        return ThrowIsNotNull(Exceptions.NotInRange(FullNameOfExecutedCode(), variableName, list, isLt, isGt));
    }

    public static bool NotInt(string what, int? value)
    {
        return ThrowIsNotNull(Exceptions.NotInt(FullNameOfExecutedCode(), what, value));
    }

    public static bool NotSupported()
    {
        return ThrowIsNotNull(Exceptions.NotSupported(FullNameOfExecutedCode()));
    }

    public static bool NotSupportedExtension(string extension)
    {
        return ThrowIsNotNull(Exceptions.NotSupportedExtension, extension);
    }

    public static bool OnlyOneElement(string colName, ICollection list)
    {
        return ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), colName, list));
    }

    public static bool OutOfRange(string colName, ICollection col, string indexName, int index)
    {
        return ThrowIsNotNull(Exceptions.OutOfRange(FullNameOfExecutedCode(), colName, col, indexName, index));
    }

    public static bool PassedListInsteadOfArray<T>(string variableName, T[] v, Func<IEnumerable<T>, bool> CA_IsListStringWrappedInArray)
    {
        return ThrowIsNotNull(Exceptions.PassedListInsteadOfArray<T>(FullNameOfExecutedCode(), variableName, v.ToList(), CA_IsListStringWrappedInArray));
    }

    public static bool RepeatAfterTimeXTimesFailed(int times, int timeoutInMs, string address, int sharedAlgorithmSlastError)
    {
        return ThrowIsNotNull(Exceptions.RepeatAfterTimeXTimesFailed(FullNameOfExecutedCode(), times, timeoutInMs, address, sharedAlgorithmSlastError));
    }

    public static bool StartIsHigherThanEnd(int start, int end)
    {
        return ThrowIsNotNull(Exceptions.StartIsHigherThanEnd(FullNameOfExecutedCode(), start, end));
    }

    public static bool StringContainsUnAllowedSubstrings(string input, params string[] unallowedStrings)
    {
        return ThrowIsNotNull(Exceptions.StringContainsUnallowedSubstrings(FullNameOfExecutedCode(), input, unallowedStrings));
    }

    public static bool UncommentAfterNugetsFinished()
    {
        return Custom("Uncomment after nugets finished");
    }

    public static bool UriFormat(string url, Func<string, bool> uhIsUri)
    {
        return ThrowIsNotNull(Exceptions.UriFormat, url, uhIsUri);
    }

    public static bool UseRlc()
    {
        return ThrowIsNotNull(Exceptions.UseRlc(FullNameOfExecutedCode()));
    }

    public static bool WasAlreadyInitialized()
    {
        return ThrowIsNotNull(Exceptions.WasAlreadyInitialized(FullNameOfExecutedCode()));
    }

    public static bool WasNotKeysHandler(string name, object keysHandler)
    {
        return ThrowIsNotNull(Exceptions.WasNotKeysHandler(FullNameOfExecutedCode(), name, keysHandler));
    }

    public static bool WrongExtension(string path, string requiredExt)
    {
        return ThrowIsNotNull(Exceptions.WrongExtension(FullNameOfExecutedCode(), path, requiredExt));
    }

    public static bool WrongNumberOfElements<T>(int requireElements, string nameCollection, IEnumerable<T> collection)
    {
        return ThrowIsNotNull(Exceptions.WrongNumberOfElements(FullNameOfExecutedCode(), requireElements, nameCollection, collection));
    }

    public static bool ZeroOrMoreThanOne(string nameOfVariable, List<string> list)
    {
        return ThrowIsNotNull(Exceptions.ZeroOrMoreThanOne(FullNameOfExecutedCode(), nameOfVariable, list));
    }

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
            Type t = type.GetType();
            typeFullName = t.FullName ?? "Type cannot be get via type.GetType()";
        }

        return string.Concat(typeFullName, ".", methodName);
    }

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
        string? exc = f(FullNameOfExecutedCode(), ex, message);
        return ThrowIsNotNull(exc);
    }

    public static bool ThrowIsNotNull<A>(Func<string, A, string?> f, A ex)
    {
        string? exc = f(FullNameOfExecutedCode(), ex);
        return ThrowIsNotNull(exc);
    }

    public static bool ThrowIsNotNull(Func<string, string?> f)
    {
        string? exc = f(FullNameOfExecutedCode());
        return ThrowIsNotNull(exc);
    }
}