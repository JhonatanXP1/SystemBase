using Serilog;
namespace SystemBase.Services;

public class ResponseService<T>
{
    public bool success { get; set; }
    public string error { get; set; } = string.Empty;
    public T? data { get; set; }
}

public static class ResponseService
{
    public static ResponseService<T> Success<T>(T data)
    {
        return new ResponseService<T>
        {
            success = true,
            data = data
        };
    }

    public static ResponseService<T> Error<T>(string error)
    {
        return new ResponseService<T>
        {
            success = false,
            error = error
        };
    }
}