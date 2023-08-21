using Bazar.Core.Entities;
using Bazar.Core.Models;

namespace Bazar.Core.DTOs;

public class CreateEditProductRequestDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public Guid ProductId { get; set; }
    public ICollection<PostImage> Images { get; set; } = null!;
}

public class ProductResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string ShortDescription { get; set; } = null!;
    public double RegularPrice { get; set; }
    public double? DiscountPrice { get; set; }
    public byte[] PrimaryImage { get; set; } = null!;

    //TODO:TOTAL PRICE AFTER DISCOUNT
    //TODO:CREATE MINIMALDTO AND DETAILDTO IN ALL DTOS 
}

public class ProductDetailResponseDto : ProductResponseDto
{
    public UserResponseDto User { get; set; } = null!;
    public List<byte[]> SubImages { get; set; } = null!;
    public string? Description { get; set; }
    public List<Category>? Categories { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}