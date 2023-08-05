using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Configurations.Entities;
public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .Property(c=>c.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}