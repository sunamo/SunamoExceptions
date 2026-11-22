namespace SunamoExceptions;

public partial class ThrowEx
{

    /// <summary>
    /// Is not allowed.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <returns>The is not allowed result.</returns>
    public static bool IsNotAllowed(string what)
    {
        return ThrowIsNotNull(Exceptions.IsNotAllowed(FullNameOfExecutedCode(), what));
    }

    /// <summary>
    /// Is not null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable.</param>
    /// <returns>The is not null result.</returns>
    public static bool IsNotNull(string variableName, object variable)
    {
        return ThrowIsNotNull(Exceptions.IsNotNull(FullNameOfExecutedCode(), variableName, variable));
    }

    /// <summary>
    /// Is not positive number.
    /// </summary>
    /// <param name="nameOfVariable">The name of variable.</param>
    /// <param name="n">The n.</param>
    /// <returns>The is not positive number result.</returns>
    public static bool IsNotPositiveNumber(string nameOfVariable, int? n)
    {
        return ThrowIsNotNull(Exceptions.IsNotPositiveNumber(FullNameOfExecutedCode(), nameOfVariable, n));
    }

    /// <summary>
    /// Is not windows path format.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <param name="raiseIsNotWindowsPathFormat">The raise is not windows path format.</param>
    /// <param name="SunamoFileSystem_IsWindowsPathFormat">The sunamo file system is windows path format.</param>
    /// <returns>The is not windows path format result.</returns>
    public static bool IsNotWindowsPathFormat(string argName, string argValue, bool raiseIsNotWindowsPathFormat, Func<string, bool> SunamoFileSystem_IsWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsNotWindowsPathFormat(FullNameOfExecutedCode(), argName, argValue, raiseIsNotWindowsPathFormat, SunamoFileSystem_IsWindowsPathFormat));
    }

    /// <summary>
    /// Is null.
    /// </summary>
    /// <param name="variableName">The variable name.</param>
    /// <param name="variable">The variable.</param>
    /// <returns>The is null result.</returns>
    public static bool IsNull(string variableName, object? variable = null)
    {
        return ThrowIsNotNull(Exceptions.IsNull(FullNameOfExecutedCode(), variableName, variable));
    }

    /// <summary>
    /// Is null or empty.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <returns>The is null or empty result.</returns>
    public static bool IsNullOrEmpty(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, true));
    }

    /// <summary>
    /// Is null or whitespace.
    /// </summary>
    /// <param name="argName">The arg name.</param>
    /// <param name="argValue">The arg value.</param>
    /// <returns>The is null or whitespace result.</returns>
    public static bool IsNullOrWhitespace(string argName, string argValue)
    {
        return ThrowIsNotNull(Exceptions.IsNullOrWhitespace(FullNameOfExecutedCode(), argName, argValue, false));
    }

    /// <summary>
    /// Is the same.
    /// </summary>
    /// <param name="fst">The fst.</param>
    /// <param name="sec">The sec.</param>
    /// <returns>The is the same result.</returns>
    public static bool IsTheSame(string fst, string sec)
    {
        return ThrowIsNotNull(Exceptions.IsTheSame(FullNameOfExecutedCode(), fst, sec));
    }

    /// <summary>
    /// Is whitespace or null.
    /// </summary>
    /// <param name="variable">The variable.</param>
    /// <param name="data">The data.</param>
    /// <returns>The is whitespace or null result.</returns>
    public static bool IsWhitespaceOrNull(string variable, object data)
    {
        return ThrowIsNotNull(Exceptions.IsWhitespaceOrNull(FullNameOfExecutedCode(), variable, data));
    }

    /// <summary>
    /// Is windows path format.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="isWindowsPathFormat">The is windows path format.</param>
    /// <returns>The is windows path format result.</returns>
    public static bool IsWindowsPathFormat(string input, Func<string, bool> isWindowsPathFormat)
    {
        return ThrowIsNotNull(Exceptions.IsWindowsPathFormat(FullNameOfExecutedCode(), input, isWindowsPathFormat));
    }

    /// <summary>
    /// Key not found t u.
    /// </summary>
    /// <param name="en">The en.</param>
    /// <param name="dictName">The dict name.</param>
    /// <param name="key">The key.</param>
    /// <returns>The key not found t u result.</returns>
    public static bool KeyNotFound<T, U>(IDictionary<T, U> en, string dictName, T key)
    {
        return ThrowIsNotNull(Exceptions.KeyNotFound(FullNameOfExecutedCode(), en, dictName, key));
    }

    /// <summary>
    /// List null or empty t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="variableName">The variable name.</param>
    /// <param name="list">The list.</param>
    /// <returns>The list null or empty t result.</returns>
    public static bool ListNullOrEmpty<T>(string variableName, IEnumerable<T>? list)
    {
        return ThrowIsNotNull(Exceptions.ListNullOrEmpty(FullNameOfExecutedCode(), variableName, list));
    }

    /// <summary>
    /// Locked by bit locker.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="IsLockedByBitLocker">The is locked by bit locker.</param>
    /// <returns>The locked by bit locker result.</returns>
    public static bool LockedByBitLocker(string path, Func<char, bool> IsLockedByBitLocker)
    {
        return ThrowIsNotNull(Exceptions.LockedByBitLocker(FullNameOfExecutedCode(), path, IsLockedByBitLocker));
    }

    /// <summary>
    /// More than one element.
    /// </summary>
    /// <param name="listName">The list name.</param>
    /// <param name="count">The count.</param>
    /// <param name="moreInfo">The more info.</param>
    /// <returns>The more than one element result.</returns>
    public static bool MoreThanOneElement(string listName, int count, string moreInfo = "")
    {
        string fn = FullNameOfExecutedCode();
        string? exc = Exceptions.MoreThanOneElement(fn, listName, count, moreInfo);
        return ThrowIsNotNull(exc);
    }

    /// <summary>
    /// Name is not setted.
    /// </summary>
    /// <param name="nameControl">The name control.</param>
    /// <param name="nameFromProperty">The name from property.</param>
    /// <returns>The name is not setted result.</returns>
    public static bool NameIsNotSetted(string nameControl, string nameFromProperty)
    {
        return ThrowIsNotNull(Exceptions.NameIsNotSetted(FullNameOfExecutedCode(), nameControl, nameFromProperty));
    }

    /// <summary>
    /// No passed folders.
    /// </summary>
    /// <param name="folders">The folders.</param>
    /// <returns>The no passed folders result.</returns>
    public static bool NoPassedFolders(ICollection folders)
    {
        return ThrowIsNotNull(Exceptions.NoPassedFolders(FullNameOfExecutedCode(), folders));
    }

    /// <summary>
    /// Not contains.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="shouldContains">The should contains.</param>
    /// <returns>The not contains result.</returns>
    public static bool NotContains(string text, params string[] shouldContains)
    {
        return ThrowIsNotNull(Exceptions.NotContains(FullNameOfExecutedCode(), text, shouldContains));
    }
}