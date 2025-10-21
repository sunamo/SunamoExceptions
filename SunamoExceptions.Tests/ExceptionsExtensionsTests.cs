// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoExceptions.Tests;
public class ExceptionsExtensionsTests
{
    [Fact]
    public void GetAllMessagesTest()
    {
        var exc = new Exception("Hlavní výjimka", new Exception("Vnitřní výjimka 1", new Exception("Vnitřní výjimka 2")));

        var text = exc.GetAllMessages();
    }
}
