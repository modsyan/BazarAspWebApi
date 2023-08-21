using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Category : BaseModel
{

    [Required] public string Name { get; set; } = null!;
    [Required] public byte[] ICon { get; set; } = null!;
    [Required] public string Color { get; set; } = null!;

    public ICollection<Product> Products { get; set; }
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .Property(c=>c.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}
