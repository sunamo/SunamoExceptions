namespace SunamoExceptions;

/// <summary>
/// Extension methods for working with exceptions.
/// </summary>
public static class ExceptionsExtensions
{
    /// <summary>
    /// Gets all messages from an exception including all inner exceptions.
    /// </summary>
    /// <param name="ex">The exception to extract messages from.</param>
    /// <returns>A string containing all exception messages concatenated with inner exception messages.</returns>
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