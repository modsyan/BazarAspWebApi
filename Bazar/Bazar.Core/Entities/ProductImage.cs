using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class ProductImage : BaseModel
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public string Url { get; set; }
}

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder
            .Property(p => p.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}
