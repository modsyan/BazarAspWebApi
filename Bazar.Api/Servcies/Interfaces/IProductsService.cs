using Bazar.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Services.Interfaces;

public interface IProductsService
{
    public Task<Product?> GetById(long id);
    public Task<IEnumerable<Product>> GetAll();
    public Task<Product> FindByName(string name); //-> todo: Find By What?
    public Task<IEnumerable<Product>> FindAllByName(string name);
    public Task<Product> Update(Product product);
    public Task<Product> Delete(long id);
    public Task<Product> Delete(Product product);
}