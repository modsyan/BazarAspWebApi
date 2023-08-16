using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Faq : BaseModel
{
    [Required] public string Question { get; set; } = null!;
    [Required] public string Answer { get; set; } = null!;
}

public class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
    public void Configure(EntityTypeBuilder<Faq> builder)
    {
        builder
            .Property(faq => faq.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
    }
}