using Bazar.Core.Models;

namespace Bazar.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IProductRepository Products { get; }

    int Complete();
}