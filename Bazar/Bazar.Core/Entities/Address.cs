using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Address : BaseModel
{
    [Required] public Guid UserId { get; set; }
    [Required] public User User { get; set; } = null!;
    [Required] public string Country { get; set; } = null!;
    [Required] public string City { get; set; } = null!;
    [Required] public string StreetAddress { get; set; } = null!;
    [Required] public string ZipCode { get; set; } = null!;
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