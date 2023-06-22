using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }

    [Required, MaxLength(100)] public required string Name { get; set; }

    [Required] public required string ProductId { get; set; }

    [Required] public required Product Product { get; set; }
}