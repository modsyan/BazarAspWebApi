using System.ComponentModel.DataAnnotations;
using Bazar.Core.Entities.Base;
using Bazar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bazar.Core.Entities;

public class Product : BaseModel
{
    // protected Product(string title, double regularPrice, double? discountPrice, string shortDescription,
    //     string? description, int buyNumber, User crafter)
    // {
    //     Title = title;
    //     RegularPrice = regularPrice;
    //     DiscountPrice = discountPrice;
    //     ShortDescription = shortDescription;
    //     Description = description;
    //     BuyNumber = buyNumber;
    //     Crafter = crafter;
    //     Published = true;
    // }

    [MaxLength] public string Title { get; set; }
    [Required] public double RegularPrice { get; set; }
    public double? DiscountPrice { get; set; }
    [MaxLength(255)] public string ShortDescription { get; set; }
    public string? Description { get; set; }
    public int BuyNumber { get; set; } = 0;
    private bool Published { get; init; }

    // relationships 

    public Vendor Vendor { get; set; } = null!;
    public ICollection<Post>? Posts { get; set; }
    public ICollection<ProductImage> Images { get; set; } = null!;
    public ICollection<Category> Categories { get; set; } = null!;
    public ICollection<Tag> Tags { get; set; } = null!;
    public ICollection<Review> Reviews { get; set; } = null!;

    [Required] public User Crafter { get; set; }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(p => p.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.HasOne(product => product.Vendor)
            .WithMany(vendor => vendor.Products)
            .HasForeignKey("VendorId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}