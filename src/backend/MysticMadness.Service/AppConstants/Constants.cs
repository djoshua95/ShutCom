namespace MysticMadness.Service.AppConstants;

public static class Constants
{
    /// <summary>
    /// These constants are for custom logging messages when an exception is captured.
    /// </summary>
    public static class LoggingMessages
    {
        public const string ERROR_FAILED_GET_ORDERS_FOR_USER = "Failed to retrieve orders for user {UserId}. Error code: {ErrorCode}";
        public const string ERROR_FAILED_GET_PAGED_ORDERS_FOR_USER = "Failed to retrieve orders for user {UserId}. Error code: {ErrorCode}";
        public const string ERROR_INVALID_PAGE_SIZE = "Page size must be greater than or equal to 1.";
        public const string ERROR_INVALID_PAGE_NUMBER = "Page number must be greater than or equal to 1.";
    }

    /// <summary>
    /// These constants are for retrieving messages to the client.
    /// </summary>
    public static class ErrorMessages
    {
        public const string ERROR_GET_ITEMS_FAILED = "The operation failed, no items could be fetched.";
    }

    public static class ErrorCodes
    {
        public const string ORDS0001 = "Error code: ORDS0001";
        public const string ORDS0002 = "Error code: ORDS0002";
    }
}