using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class OrderItem : BaseModel
{
    [Required, Range(1, 100)] public int Quantity { get; set; }
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}