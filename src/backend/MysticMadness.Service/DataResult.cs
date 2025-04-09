namespace MysticMadness.Service;

public class DataResult<TResult>
{
    public bool Success { get; set; }
    public TResult? Data { get; set; } = default;
    public string Message { get; set; } = string.Empty;
}