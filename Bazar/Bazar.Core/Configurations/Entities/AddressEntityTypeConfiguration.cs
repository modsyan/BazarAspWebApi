using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;

public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        
        builder
            .Property(a=>a.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}
