using Bazar.Api.Services.Contracts;
using Bazar.Api.Services.Contracts.Base;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bazar.Api.Services;

public class UserService : BaseService, IUserService
{
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
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