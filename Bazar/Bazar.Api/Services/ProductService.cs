using Bazar.Api.Services.Contracts;
using Bazar.Api.Services.Contracts.Base;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;

namespace Bazar.Api.Services;

public class ProductService : BaseService, IProductService
{
    public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await UnitOfWork.Products.GetAsync(id);
    }

    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await UnitOfWork.Products.GetAsync();
    }

    public async Task<Product?> FindByName(string title)
    {
        return await UnitOfWork.Products.FindFirstAsync(e => e.Title == title);
    }

    public async Task<IEnumerable<Product?>> FindAllByName(string title)
    {
        return await UnitOfWork.Products.FindAllAsync(e => e.Title == title);
    }

    public Product Create(Product product)
    {
        return UnitOfWork.Products.Create(product);
    }

    public Product Update(Product product)
    {
        return UnitOfWork.Products.Update(product)!;
    }

    public void Delete(Guid id)
    {
        UnitOfWork.Products.Delete(id);
    }

    public void DeleteByPrice(double price)
    {
        UnitOfWork.Products.Delete(p => p.RegularPrice == price);
    }

    public void Delete(Product product)
    {
        UnitOfWork.Products.Delete(product);
    }

    public void DeleteRange(Product product)
    {
        UnitOfWork.Products.Delete(product);
    }
}