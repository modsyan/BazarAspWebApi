using Bazar.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Services.Interfaces;

public interface IProductService
{
    public Task<Product?> GetById(string id);
    public Task<IEnumerable<Product?>> GetAll();
    public Task<Product?> FindByName(string title); //-> todo: Find By What?
    public Task<IEnumerable<Product?>> FindAllByName(string title);
    public Product Create(Product product);
    
    public Product Update(Product product);
    public void Delete(string id);
    public void Delete(Product product);
}