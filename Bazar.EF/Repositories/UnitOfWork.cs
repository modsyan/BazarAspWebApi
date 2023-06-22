using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Bazar.EF.Data;

namespace Bazar.EF.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IUserRepository Users { get; private set; }
    public IProductRepository Products { get; private set; }
    
    public UnitOfWork(ApplicationDbContext dbContext, IUserRepository users, IProductRepository products)
    {
        _dbContext = dbContext;
        Users = users;
        Products = products;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

    
    public int Complete()
    {
        return _dbContext.SaveChanges();
    }
}