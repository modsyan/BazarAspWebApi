using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [MaxLength(60)] public string Title { get; set; }

    [Required] public double RegularPrice { get; set; }

    public double? DiscountPrice { get; set; }

    [MaxLength(255)] public string ShortDescription { get; set; }

    public string? Description { get; set; }

    public ICollection<ProductImage>? Images { get; set; }

    public ICollection<Category>? Categories { get; set; }

    public ICollection<Review>? Reviews { get; set; }

    [Required] public Guid VendorId { get; set; }
    [Required] public User Vendor { get; set; }

    public int BuyNumber { get; set; } = 0;

    private bool Published { get; init; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}