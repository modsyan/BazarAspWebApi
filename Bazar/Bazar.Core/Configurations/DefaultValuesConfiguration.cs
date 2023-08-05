using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Bazar.Core.Configurations;

public static class DefaultValuesConfiguration
{
    public static void SetDefaultValuesTableName(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes()
                     .Where(x => x.ClrType.GetCustomAttribute(typeof(TableAttribute)) != null))
        {
            var entityClass = entity.ClrType;
            var tAttr = entityClass.GetCustomAttribute(typeof(TableAttribute)) as TableAttribute;

            modelBuilder.Entity(entityClass).ToTable(tAttr.Name);

            foreach (var property in entityClass.GetProperties().Where(p =>
                         (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(Guid)) &&
                         p.CustomAttributes.Any(a =>
                             a.AttributeType == typeof(DatabaseGeneratedAttribute) &&
                             !p.CustomAttributes.Any(c => c.AttributeType == typeof(DefaultValueAttribute)))))
            {
                var defaultValueSql = "GetDate()";
                if (property.PropertyType == typeof(Guid))
                {
                    defaultValueSql = "newsequentialid()";
                }

                modelBuilder.Entity(entityClass).Property(property.Name).HasDefaultValueSql(defaultValueSql);
            }

            foreach (var property in entityClass.GetProperties()
                         .Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(DefaultValueAttribute))))
            {
                var pAttr = property.GetCustomAttribute(typeof(DefaultValueAttribute)) as DefaultValueAttribute;

                modelBuilder.Entity(entityClass).Property(property.Name).HasDefaultValueSql(pAttr.Value.ToString());
            }
        }
    }
}