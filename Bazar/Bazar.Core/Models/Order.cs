using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }


    [Required] public Guid UserId { get; set; }
    [Required] public User User { get; set; } = null!;

    public List<OrderItem> OrderItems { get; set; }

    [Required] public Address Address { get; set; }
    [Required] public Guid AddressId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}