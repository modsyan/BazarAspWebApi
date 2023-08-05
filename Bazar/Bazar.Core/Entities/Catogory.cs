using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;

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