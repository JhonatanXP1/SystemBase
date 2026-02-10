namespace SystemBase.Services;

public class ResponseService<T>
{
    public bool Success { get; set; }
    public string Error { get; set; }
    public T Data { get; set; }
}
public static class ResponseService
{
    public static ResponseService<T> Success<T>(T data)
    {
        return new ResponseService<T>
        {
            Success = true,
            Data = data
        };
    }
    public static ResponseService<T> Error<T>(string error)
    {
        return new ResponseService<T>
        {
            Success = false,
            Error = error
        };
    }
}