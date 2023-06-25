using Bazar.Api.Services.Interfaces;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;

namespace Bazar.Api.Services;

public class ProductsService : IProductsService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product?> GetById(string id)
    {
        return await _unitOfWork.Products.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await _unitOfWork.Products.GetAllAsync();
    }

    public async Task<Product?> FindByName(string title)
    {
        return await _unitOfWork.Products.FindAsync(e => e != null && e.Title == title);
    }

    public async Task<IEnumerable<Product?>> FindAllByName(string title)
    {
        return await _unitOfWork.Products.FindAllAsync(e => e.Title == title);
    }

    public Product Create(Product product)
    {
        return _unitOfWork.Products.Create(product);
    }

    public Product Update(Product product)
    {
        return _unitOfWork.Products.Update(product)!;
    }

    public void Delete(string id)
    {
        _unitOfWork.Products.Delete(id);
    }

    public void DeleteByPrice(double price)
    {
        _unitOfWork.Products.Delete(p => p.RegularPrice == price);
    }

    public void Delete(Product product)
    {
        _unitOfWork.Products.Delete(product);
    }

    public void DeleteRange(Product product)
    {
        _unitOfWork.Products.Delete(product);
    }
}