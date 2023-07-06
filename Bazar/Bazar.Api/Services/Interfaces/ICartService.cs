using Bazar.Core.Models;

namespace Bazar.Api.Services.Interfaces;

public interface ICartService
{
    public Task<Cart> AddItem();
    public Task<Cart> RemoveItem();
    public Task<Cart> Get();
    public void Empty();
}