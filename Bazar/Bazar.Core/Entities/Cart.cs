using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class Cart : BaseModel
{
    [Required] public User User { get; set; } = null!;
    public List<CartItem> Items { get; set; } = new();
}