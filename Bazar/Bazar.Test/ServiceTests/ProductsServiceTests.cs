using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Bazar.Test.ServiceTests;

public class ProductsServiceTests : BaseServiceTests<Product>
{
    [Fact]
    public void CreateProduct_ValidProduct_ReturnProduct()
    {
        // Arrange
        var newProduct = new Product()
        {
            Title = "This is product",
            Description = "Description of the product",
            

        };

        // Act

        // Assert

    }

    [Fact]
    public void CreateProduct_InvalidProduct_ThrowsException()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact]
    public void GetProduct_ValidId_ReturnsProduct()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact]
    public void GetProduct_InvalidId_ReturnsNull()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact]
    public void UpdateProduct_NonExistingId_ReturnNull()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact]
    public void UpdateProduct_ExistingIdWithInvalidBody_ThrowException()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact]
    public void UpdateProduct_ExistingIdWithValidBody_ThrowException()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact]
    public void RemoveProduct_ExistingId_ReturnProduct()
    {
        // Arrange
        // Act
        // Assert
    }

    [Fact]
    public void RemoveProduct_NonExistingId_ThrowsException()
    {
        // Arrange
        // Act
        // Assert
    }
}