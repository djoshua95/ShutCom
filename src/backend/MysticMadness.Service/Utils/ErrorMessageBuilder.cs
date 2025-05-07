namespace MysticMadness.Service.Utils;

public static class ErrorMessageBuilder
{
    public static string BuildFromMessageAndCode(string message, string code)
    {
        return string.Join(" ", [message, code]);
    }
}
