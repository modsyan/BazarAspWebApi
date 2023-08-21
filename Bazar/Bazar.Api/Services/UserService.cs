using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ILogger = NuGet.Common.ILogger;

namespace Bazar.Api.Services;

public class UserService : BaseService<UserService>, IUserService
{
    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger) : base(unitOfWork, logger)
    {
    }

    public async Task<User?> Get(Guid userId)
    {
        return await UnitOfWork.Users.GetAsync(userId);
    }

    public async Task<User> GetDetails(Guid userId)
    {
        return await UnitOfWork.Users.FindSingleAsync(user => user.Id.Equals(userId));
    }

    public async Task<IEnumerable<User>> Get()
    {
        return await UnitOfWork.Users.GetAsync();
    }
}