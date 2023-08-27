using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Core.Configurations;

public static class GuidConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        foreach
        (
            var entity in modelBuilder.Model.GetEntityTypes()
                .Where(e => e.ClrType.GetProperties()
                    .Any(p => p.CustomAttributes
                        .Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute))
                    )
                )
        )
        {
            foreach
            (
                var property in entity.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(Guid) && p.CustomAttributes
                        .Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute)
                        )
                    )
            )
            {
                modelBuilder.Entity(entity.ClrType)
                    .Property(property.Name)
                    .HasDefaultValueSql("newsequentialid()");
            }
        }
    }
}