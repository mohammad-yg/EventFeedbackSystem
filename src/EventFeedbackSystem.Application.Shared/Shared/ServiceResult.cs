using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventFeedbackSystem.Application.Shared.Shared;

public record ServiceResult
{
    public ServiceResult(bool isSuccess, string? errorKey = null, string? message = null)
    {
        IsSuccess = isSuccess;
        ErrorKey = errorKey;
        Message = message;
    }

    public bool IsSuccess { get; set; }
    public string? ErrorKey { get; set; }
    public string? Message { get; set; }
}

public record ServiceResult<TData> : ServiceResult
{
    public ServiceResult(bool isSuccess, TData? data, string? errorKey = null, string? message = null)
        : base(isSuccess, errorKey, message)
    {
        Data = data;
    }
    public TData? Data { get; set; }
}