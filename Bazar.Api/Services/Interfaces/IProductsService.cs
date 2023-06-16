using Bazar.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Services.Interfaces;

public interface IProductsService
{
    public Task<Product?> GetById(long id);
    public Task<IEnumerable<Product?>> GetAll();
    public Task<Product?> FindByName(string name); //-> todo: Find By What?
    public Task<IEnumerable<Product?>> FindAllByName(string name);
    public Product Update(Product product);
    public void Delete(long id);
    public void Delete(Product product);
}