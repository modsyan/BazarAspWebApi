using System.Text.Json.Serialization;

namespace Bazar.Core.Models;

public class ApiResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }

    public ApiResult(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}