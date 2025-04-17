using System.ComponentModel;


namespace $safeprojectname$.Extensions;


public static class ExceptionExtensions
{
    public static ApiError ToApiError(this Exception exception)
    {
        return new ApiError()
        {
            Title = exception.Message,
            Detail = exception.ToString(),
            Source = exception.StackTrace ?? string.Empty
        };
    }
}