namespace Bazar.Api.Helpers;

public class Jwt
{
    public required string Key { get; set; }
    public required string DurationsInDays { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    
}