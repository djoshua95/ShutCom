using MysticMadness.Service.AppConstants;

namespace MysticMadness.Service.Utils.Logging;

public struct GenericLoggingError
{
    public string Template { get; set; }
    public string Code { get; set; }
    public Exception Exception { get; set; }
    public string[] Params { get; set; }
}

public interface ICustomLoggingMessage
{
    GenericLoggingError GetError();
}

public static class CustomLoggingMessages
{
    public class ORDS0001 : ICustomLoggingMessage
    {
        public const string TEMPLATE = Constants.LoggingMessages.ERROR_FAILED_GET_ORDERS_FOR_USER;
        public const string CODE = nameof(ORDS0001);
        public required Exception Ex { get; set; }
        public required int UserId { get; set; }

        public GenericLoggingError GetError()
        {
            return new() { Template = TEMPLATE, Code = CODE, Exception = Ex, Params = [UserId.ToString(), CODE] };
        }
    }

    public class ORDS0002 : ICustomLoggingMessage
    {
        public const string TEMPLATE = Constants.LoggingMessages.ERROR_FAILED_GET_ORDERS_FOR_USER;
        public const string CODE = nameof(ORDS0002);
        public required Exception Ex { get; set; }
        public required int UserId { get; set; }

        public GenericLoggingError GetError()
        {
            return new() { Template = TEMPLATE, Code = CODE, Exception = Ex, Params = [UserId.ToString(), CODE] };
        }
    }
}