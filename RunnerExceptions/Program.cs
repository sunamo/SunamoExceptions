using SunamoExceptions.Tests;

namespace RunnerExceptions;

internal class Program
{
    static void Main()
    {
        ////t.IsNullOrWhitespaceTest();

        ExceptionsExtensionsTests s = new();
        s.GetAllMessagesTest();

        Console.ReadLine();
    }
}
