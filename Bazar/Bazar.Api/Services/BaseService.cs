using Bazar.Core.Interfaces;

namespace Bazar.Api.Services.Contracts.Base;

public class BaseService
{
    protected readonly IUnitOfWork UnitOfWork;

    protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}