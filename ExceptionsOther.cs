namespace SunamoExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Exceptions
{
    private static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? "" : before + ": ";
    }

    public static string TextOfExceptions(Exception ex, bool alsoInner = true)
    {
        if (ex == null) return "";
        StringBuilder sb = new();
        sb.Append("Exception:");
        sb.AppendLine(ex.Message);
        if (alsoInner)
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                sb.AppendLine(ex.Message);
            }
        var r = sb.ToString();
        return r;
    }
}