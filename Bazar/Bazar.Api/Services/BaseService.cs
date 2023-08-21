using Bazar.Core.Interfaces;

namespace Bazar.Api.Services;

public class BaseService<TService>
    where TService : class
{
    protected IUnitOfWork UnitOfWork { get; private set; }
    protected ILogger<TService> Logger { get; private set; }

    protected BaseService(IUnitOfWork unitOfWork, ILogger<TService> logger)
    {
        UnitOfWork = unitOfWork;
        Logger = logger;
    }
}