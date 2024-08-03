using System;

public static class LogAnalysis
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string originalMessage, string delimiter)
    {
        return originalMessage.Substring(originalMessage.IndexOf(delimiter) + delimiter.Length);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(
        this string originalMessage,
        string openBracket,
        string closedBracket
    )
    {
        int startingIndex = originalMessage.IndexOf(openBracket) + openBracket.Length;

        return originalMessage[
            startingIndex..originalMessage.IndexOf(closedBracket)
        ];
    }

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string originalMessage)
    {
        return originalMessage.SubstringAfter(": ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string originalMessage)
    {
        return originalMessage.SubstringBetween("[", "]");
    }
}
