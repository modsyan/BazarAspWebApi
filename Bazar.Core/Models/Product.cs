using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required string Id { get; set; }
    [MaxLength(60)] public required string Name { get; set; }
    public required double RegularPrice { get; set; }
    public double? DiscountPrice { get; set; }
    [MaxLength(255)] public required string ShortDescription { get; set; }
    public string? Description { get; set; }
    public ICollection<Category>? Categories { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public required string VendorId { get; set; }
    public required User Vendor { get; set; }
    public required int BuyNumber { get; set; }
    private bool Published { get; init; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}