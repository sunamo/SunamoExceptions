// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoExceptions.Tests;
public class ThrowExTests
{
    [Fact]
    public void IsNullOrWhitespaceTest()
    {
        string? a = "a";
        var builder = ThrowEx.IsNullOrWhitespace("a", a);

        a = null;
        var b2 = ThrowEx.IsNullOrWhitespace("a", a);
    }

    [Fact]
    public void HasNotIndexTest()
    {
        var list = Exceptions.HasNotIndex("", [1, 2, 3], "", 2);
        var l2 = Exceptions.HasNotIndex("", [1, 2, 3], "", 3);
    }
}
