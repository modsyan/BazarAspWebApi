using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace Bazar.Core.Models;


public class ErrorModel : Exception
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Details { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
}