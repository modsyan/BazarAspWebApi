using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;

namespace Bazar.Core.Entities;

public class CartItem : BaseModel
{
    [Required] public Cart Cart { get; set; } = null!;
    [Required] public Product Product { get; set; } = null!;
}