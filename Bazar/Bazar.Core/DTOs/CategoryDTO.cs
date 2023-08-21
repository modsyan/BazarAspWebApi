namespace Bazar.Core.DTOs;

public class CreateEditCategoryRequestDto
{
}

public class CategoryResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string Color { get; set; } = null!;
    public bool IsPrimary { get; set; } 
}

public class CategoryDetailResponseDto : CategoryResponseDto
{
    public List<ProductResponseDto> Products { get; set; }  
}