using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;

namespace Bazar.Core.Entities;

public class Order : BaseModel
{
    [Required] public User User { get; set; } = null!;
    public List<OrderItem> OrderItems { get; set; }
    [Required] public Address Address { get; set; } = null!;
}