using Bazar.Core.Models;

namespace Bazar.Core.DTOs;

public class CreateProductRequestDto
{
    public string Name { get; set; }
    public double RegularPrice { get; set; }
}

public class CreateProductResponseDto
{
    public string Name { get; set; }
    public double RegularPrice { get; set; }
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