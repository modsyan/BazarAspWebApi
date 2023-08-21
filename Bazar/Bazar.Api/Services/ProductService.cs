using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;

namespace Bazar.Api.Services;

public class ProductService : BaseService<ProductService>, IProductService
{
    public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger) : base(unitOfWork, logger)
    {
    }

    public async Task<IEnumerable<Product>> GetAll(Guid userId)
    {
        return await UnitOfWork.Products.GetAsync();
    }
    
    public async Task<Product?> Get(Guid id)
    {
        return await UnitOfWork.Products.GetAsync(id);
    }

    public async Task<Product> Add(Guid ownerUserId,Product product)
    {
       // product.vendorId = 
        var createdProduct = await UnitOfWork.Products.CreateAsync(product);
        await UnitOfWork.CompleteAsync();
        return createdProduct;
    }

    public async Task<Product> Edit(Guid productId,Product product)
    {
        var updatedProduct = UnitOfWork.Products.Update(product);
        await UnitOfWork.CompleteAsync();
        return updatedProduct;
    }

    public bool Delete(Guid productId)
    {
        return UnitOfWork.Products.Delete(productId);
    }

    public async Task<IEnumerable<Product>> DeleteRange(List<Guid> productIds)
    {
        // UnitOfWork.Products.Delete(product);
        throw new NotImplementedException();
    }
}