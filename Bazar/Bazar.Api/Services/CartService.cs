using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;

namespace Bazar.Api.Services;

public class CartService : BaseService<CartService>, ICartService
{
    public CartService(IUnitOfWork unitOfWork, ILogger<CartService> logger) : base(unitOfWork, logger)
    {
    }

    public async Task<Cart> AddItem(CartItem item)
    {
        throw new NotImplementedException();
    }

    public async Task<Cart> AddItem()
    {
        throw new NotImplementedException();
    }

    public async Task<Cart> RemoveItem()
    {
        throw new NotImplementedException();
    }

    public async Task<Cart> Get()
    {
        throw new NotImplementedException();
    }

    public void Empty()
    {
        throw new NotImplementedException();
    }
}