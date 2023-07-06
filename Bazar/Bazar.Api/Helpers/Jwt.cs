namespace Bazar.Api.Helpers;

public class Jwt
{
    public required string Key { get; set; }
    public required double DurationsInDays { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
}