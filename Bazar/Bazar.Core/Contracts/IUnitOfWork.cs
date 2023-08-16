using Bazar.Core.Contracts;
using Bazar.Core.Entities;
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
    public IBaseRepository<Faq> Faqs { get; }
    public IBaseRepository<Post> Posts { get; }
    public IBaseRepository<Block> Blocks { get; }

    public int Complete();
    public Task<int> CompleteAsync();
}