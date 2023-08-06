using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bazar.Api.Services;

public class UserService : IUserService
{
    private IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User> Get(Guid userId)
    {
        return await _unitOfWork.Users.GetAsync(userId);
    }

    public async Task<User> GetDetails(Guid userId)
    {
        return await _unitOfWork.Users.FindSingleAsync(user => user.Id.Equals(userId));
    }

    public async Task<IEnumerable<User>> Get()
    {
        return await _unitOfWork.Users.GetAsync();
    }
}