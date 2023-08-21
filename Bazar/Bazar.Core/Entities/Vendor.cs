using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Vendor : User
{
    public ICollection<Product>? Products { get; set; }
}

public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.HasMany(vendor => vendor.Products).WithOne(products => products.Vendor).HasForeignKey("VendorId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}