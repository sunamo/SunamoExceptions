namespace SunamoExceptions;

/// <summary>
/// Represents the exceptions extensions type.
/// </summary>
public static class ExceptionsExtensions
{
    /// <summary>
    /// Get all messages.
    /// </summary>
    /// <param name="ex">The ex.</param>
    /// <returns>The get all messages result.</returns>
    public static string GetAllMessages(this Exception ex)
    {
        if (ex == null)
        {
            return "";
        }

        string message = ex.Message;

        if (ex.InnerException != null)
        {
            message += Environment.NewLine + "Inner Exception: " + ex.InnerException.GetAllMessages();
        }

        return message;
    }
}
