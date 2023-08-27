using System.Text.Json.Serialization;

namespace Bazar.Core.Models;

public class ApiResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public ApiResult(bool success, string? message)
    {
        Success = success;
        Message = message;
    }

    public ApiResult() : this(true, null)
    {
    }

    public ApiResult(string? message) : this(true, message)
    {
    }
}

public class ApiResult<TDto> : ApiResult
{
    public TDto Data { get; set; }

    private ApiResult(bool success, string? message, TDto data) : base(success, message)
    {
        Data = data;
    }
    public ApiResult(string? message, TDto data) : this(true, message, data)
    {
    }

    public ApiResult(TDto data) : this(true, null, data)
    {
    }
}