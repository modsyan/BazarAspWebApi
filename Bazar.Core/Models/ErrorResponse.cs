using System.Text.Json;

namespace Bazar.Core.Models;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public string? Details { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}