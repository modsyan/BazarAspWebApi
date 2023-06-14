using Bazar.Api.Services.Interfaces;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;

namespace Bazar.Api.Servcies;

public class ProductsService : IProductsService
{
    private readonly IBaseRepository<Product> _productRepository;

    public ProductsService(IBaseRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetById(long id)
    {
        return await _productRepository.GetByIdAsync(1);
    }

    public async Task<IEnumerable<Product?>> GetAll()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product?> FindByName(string name)
    {
        return await _productRepository.FindAsync(e => e != null && e.Name == name);
    }

    public async Task<IEnumerable<Product?>> FindAllByName(string name)
    {
        return await _productRepository.FindAllAsync(e => e.Name == name);
    }

    public Product Update(Product product)
    {
        return _productRepository.Update(product)!;
    }

    public void Delete(long id)
    {
        _productRepository.Delete(id);
    }

    public void Delete(Product product)
    {
        _productRepository.Delete(product);
    }

    public void DeleteRange(Product product)
    {
        _productRepository.Delete(product);
    }
}