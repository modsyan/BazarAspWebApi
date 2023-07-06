using Bazar.Api.Services.Interfaces;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;

namespace Bazar.Api.Services;

public class CartService: ICartService
{
    private readonly IUnitOfWork _unitOfWork;

    public CartService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Cart> AddItem(CartItem item)
    {
        var cart = new Cart
        {
            Id = null,
            UserId = null,
            User = null
        };
        cart.Items.Add(item);
        
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