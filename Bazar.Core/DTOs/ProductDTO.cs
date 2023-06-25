using Bazar.Core.Models;

namespace Bazar.Core.DTOs;

public class CreateProductRequestDto
{
    public string Name { get; set; }
    public double RegularPrice { get; set; }
}

public class CreateProductResponseDto
{
    public string Title { get; set; }

    public double RegularPrice { get; set; }

    public List<string> Images { get; set; }

    public double? DiscountPrice { get; set; }

    public string ShortDescription { get; set; }

    public string? Description { get; set; }

    public ICollection<Category>? Categories { get; set; }
}

public class UpdateProductRequestDto
{
}

public class UpdateProductResponseDto
{
}

public class GetProductRequest
{
}

public class GetProductResponse
{
}

public class GetAllProductRequest
{
}

public class GetAllProductResponse
{
}

public class DeleteProductRequestDto
{
}

public class DeleteProductResponseDto
{
}