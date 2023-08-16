using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Category : BaseModel
{
    public Category(string name)
    {
        Name = name;
    }

    [Required, MaxLength(100)] public string Name { get; set; }

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
