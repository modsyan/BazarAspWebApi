namespace Bazar.Core.Models;

public class ExternalAuthOptions
{
    public const string ExternalAuth = "ExternalAuth";

    public string GoogleClientKey { get; set; } = string.Empty;
    public string GoogleClientSecret { get; set; } = string.Empty;
    public string FacebookAppId { get; set; } = string.Empty;
    public string FacebookAppSecret { get; set; } = string.Empty;
    public string TwitterClientId { get; set; } = string.Empty;
    public string TwitterClientSecret { get; set; } = string.Empty;
}