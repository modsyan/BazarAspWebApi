namespace Bazar.Core.DTOs;

public class AddressDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}