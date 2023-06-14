using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazar.Core.Models;

public class Product
{
    // [Column("ProductId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

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
    
    public ICollection<Catogory> Catogories { get; set; }
    public ICollection<Review> Reviews { get; set; }
    

    //UserAdd
    
    private bool Published { get; init; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}