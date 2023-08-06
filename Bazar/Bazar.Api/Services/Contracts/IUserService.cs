using Bazar.Core.Entities;

namespace Bazar.Api.Services.Contracts;

public interface IUserService
{
    Task<User> Get(Guid userId);
    Task<User> GetDetails(Guid userId);
    Task<IEnumerable<User>> Get();
}