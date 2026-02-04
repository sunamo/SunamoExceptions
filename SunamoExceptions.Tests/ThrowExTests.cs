// variables names: ok
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoExceptions.Tests;

/// <summary>
/// Tests for ThrowEx class methods.
/// </summary>
public class ThrowExTests
{
    /// <summary>
    /// Tests the IsNullOrWhitespace method with both non-null and null values.
    /// </summary>
    [Fact]
    public void IsNullOrWhitespaceTest()
    {
        string? text = "a";
        var result = ThrowEx.IsNullOrWhitespace("a", text);

        text = null;
        var secondResult = ThrowEx.IsNullOrWhitespace("a", text!);
    }

    /// <summary>
    /// Tests the Exceptions.HasNotIndex method with valid and invalid indexes.
    /// </summary>
    [Fact]
    public void HasNotIndexTest()
    {
        var result = Exceptions.HasNotIndex("", [1, 2, 3], "", 2);
        var secondResult = Exceptions.HasNotIndex("", [1, 2, 3], "", 3);
    }
}
