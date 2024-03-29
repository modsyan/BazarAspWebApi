using Bazar.Core.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;

namespace Bazar.EF.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IUserRepository Users { get; private set; }
    public IProductRepository Products { get; private set; }
    public IBaseRepository<Cart> Carts { get; private set; }
    public IBaseRepository<Order> Orders { get; private set; }
    public IBaseRepository<Review> Reviews { get; private set; }
    public IBaseRepository<Category> Categories { get; private set; }
    public IBaseRepository<Address> Addresses { get; private set; }
    public IBaseRepository<Faq> Faqs { get; private set; }
    public IBaseRepository<Post> Posts { get; private set; }
    public IBaseRepository<Block> Blocks { get; private set; }

    public UnitOfWork(ApplicationDbContext dbContext, IUserRepository users, IProductRepository products,
        IBaseRepository<Cart> carts, IBaseRepository<Order> orders,
        IBaseRepository<Review> reviews, IBaseRepository<Category> categories, IBaseRepository<Address> addresses,
        IBaseRepository<Faq> faqs, IBaseRepository<Post> posts, IBaseRepository<Block> blocks)
    {
        _dbContext = dbContext;
        Users = users;
        Products = products;
        Carts = carts;
        Orders = orders;
        Reviews = reviews;
        Categories = categories;
        Addresses = addresses;
        Faqs = faqs;
        Posts = posts;
        Blocks = blocks;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    public int Complete()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}