namespace Bazar.Api.Models;

public class Product
{
    [Column("ProductId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Product name is required, please try again.")]
    [MaxLength(60, ErrorMessage = "Maximum Length for product name is 60 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product Price is required, please try again.")]
    public int RegularPrice { get; set; }
    
    public int? DiscountPrice { get; set; }
    
    [Required(ErrorMessage = "Product Description is required, please try again.")]
    [MaxLength(255, ErrorMessage = "Maximum Length for product name is 255 characters.")]
    public string ShortDescription { get; set; }
    
    [Required(ErrorMessage = "Product Description is required, please try again.")]
    [MaxLength(255, ErrorMessage = "Maximum Length for product name is 255 characters.")]
    public string Description { get; set; }

    private bool Published { get; init; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}