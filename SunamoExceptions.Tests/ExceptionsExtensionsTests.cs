namespace SunamoExceptions.Tests;
public class ExceptionsExtensionsTests
{
    [Fact]
    public void GetAllMessagesTest()
    {
        var exc = new Exception("Hlavní výjimka", new Exception("Vnitřní výjimka 1", new Exception("Vnitřní výjimka 2")));

        var s = exc.GetAllMessages();
    }
}
