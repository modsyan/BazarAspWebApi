using Bazar.Core.Models;

namespace Bazar.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; }
    public IProductRepository Products { get; }
    public IBaseRepository<Cart> Carts { get; }
    public IBaseRepository<Order> Orders { get; }
    public IBaseRepository<Review> Reviews { get; }
    public IBaseRepository<Category> Categories { get; }
    public IBaseRepository<Address> Addresses { get; }
    public IBaseRepository<Cart> Cart { get; }

    public int Complete();
}