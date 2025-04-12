using Microsoft.Extensions.Logging;

namespace MysticMadness.Service.Utils.Logging;

public static class LoggingExtension
{
    public static void CustomLogError(this ILogger logger, ICustomLoggingMessage message)
    {
        var error = message.GetError();
        logger.LogError(error.Exception, error.Template, error.Params);
    }
}