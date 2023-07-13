using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class ProductImage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid  ProductId { get; set; }
    public Product Product { get; set; }
    public string Url { get; set; }
}