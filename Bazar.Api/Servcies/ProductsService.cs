using Bazar.Api.Services.Interfaces;
using Bazar.Core.Models;
using Bazar.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Service;

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
    
    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> FindByName(string name)
    {
        return await _productRepository.FindByNameAsync(m => m.Name == name);
    }

    public async Task<IEnumerable<Product>> FindAllByName(string name)
    {

        return await _productRepository.FindAllByNameAsync(m => m.Name == name);
    }

    public async Task<Product> Update(Product product)
    {
        return await _productRepository.UpdateAsync(product);
    }
    
    public async Task<Product> Delete(long id)
    {
        return await _productRepository.DeleteByIdAsync(id);
    }
    
    public async Task<Product> Delete(Product product)
    {
        return await _productRepository.DeleteAsync(product);
    }
    
    public async Task<Product> DeleteRange(Product product)
    {
        return await _productRepository.DeleteAsync(product);
    }
    
    
}