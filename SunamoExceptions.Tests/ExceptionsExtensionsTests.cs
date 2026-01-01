// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoExceptions.Tests;

/// <summary>
/// Tests for ExceptionsExtensions class methods.
/// </summary>
public class ExceptionsExtensionsTests
{
    /// <summary>
    /// Tests the GetAllMessages extension method with nested exceptions.
    /// </summary>
    [Fact]
    public void GetAllMessagesTest()
    {
        var exception = new Exception("Main exception", new Exception("Inner exception 1", new Exception("Inner exception 2")));

        var text = exception.GetAllMessages();

        Assert.NotNull(text);
        Assert.Contains("Main exception", text);
        Assert.Contains("Inner exception 1", text);
        Assert.Contains("Inner exception 2", text);
    }
}
