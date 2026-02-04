// variables names: ok
using SunamoExceptions.Tests;

namespace RunnerExceptions;

internal class Program
{
    static void Main()
    {
        //ThrowExTests t = new();
        ////t.IsNullOrWhitespaceTest();
        //t.HasNotIndexTest();

        ExceptionsExtensionsTests s = new ExceptionsExtensionsTests();
        s.GetAllMessagesTest();

        //Console.WriteLine("Finished");
        Console.ReadLine();
    }
}
