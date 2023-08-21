using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Address : BaseModel
{
    [Required] public User? User { get; set; } = null!;
    [Required] public string Country { get; set; }
    [Required] public string City { get; set; }
    [Required] public string StreetAddress { get; set; }
    [Required] public string ZipCode { get; set; }
    [Required] public double Longitude { get; set; }
    [Required] public double Latitude { get; set; }
}

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(a => a.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}