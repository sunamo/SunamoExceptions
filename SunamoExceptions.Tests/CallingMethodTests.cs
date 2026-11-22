namespace SunamoExceptions.Tests;

/// <summary>
/// Tests for Exceptions.CallingMethod.
/// </summary>
public class CallingMethodTests
{
    private static string CallerName()
    {
        return Exceptions.CallingMethod();
    }

    /// <summary>
    /// Tests that CallingMethod returns the name of the method that called it.
    /// </summary>
    [Fact]
    public void CallingMethod_ReturnsCallerName()
    {
        Assert.Equal(nameof(CallerName), CallerName());
    }
}
