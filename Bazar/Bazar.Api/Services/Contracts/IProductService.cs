using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Services.Contracts;

public interface IProductService : ICrudService<Product>
{
    //TODO:ADDING PAGINATION AND SEARCH OF FILTRATION
    public Task<IEnumerable<Product>> DeleteRange(List<Guid> productIds);
}