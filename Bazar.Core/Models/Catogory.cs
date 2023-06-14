using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Catogory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    
    public string ProductId { get; set; }
    public Product Product { get; set; }
}