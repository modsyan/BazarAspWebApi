using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;

namespace Bazar.Api.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await _unitOfWork.Products.GetAsync(id);
    }

    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await _unitOfWork.Products.GetAsync();
    }

    public async Task<Product?> FindByName(string title)
    {
        return await _unitOfWork.Products.FindFirstAsync(e => e.Title == title);
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

    public void Delete(Guid id)
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