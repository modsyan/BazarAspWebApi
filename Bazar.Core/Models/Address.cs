namespace Bazar.Core.Models;

public class Address
{
    public required string Id { get; set; }
    
    public required string UserId { get; set; }
    public required User User { get; set; }
    
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string StreetAddress { get; set; }
    public string? ZipCode { get; set; }
}