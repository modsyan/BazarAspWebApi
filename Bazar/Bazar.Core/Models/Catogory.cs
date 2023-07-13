using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required, MaxLength(100)] public required string Name { get; set; }

    [Required] public Guid ProductId { get; set; }

    [Required] public Product Product { get; set; }
}