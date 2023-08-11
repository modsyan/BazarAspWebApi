using Bazar.Core.Entities;

namespace Bazar.Api.Services.Contracts;

public interface IBlacklistService
{
    Task<IEnumerable<User>?> GetList(Guid userId);
    Task<bool> RemoveList(Guid userId);
    Task<User?> Include(Guid userId, Guid targetUserId);
    Task<User?> Exclude(Guid userId, Guid targetUserId);
}