namespace Bazar.Api.Models;

public class Address
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
    
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
}