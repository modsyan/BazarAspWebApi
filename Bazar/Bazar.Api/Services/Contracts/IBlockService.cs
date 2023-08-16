using Bazar.Core.Entities;

namespace Bazar.Api.Services.Contracts;

public interface IBlockService
{
    public Task<IEnumerable<Block>> GetBlocked(Guid userId);
    public Task<IEnumerable<Block>> GetBlockedBy(Guid userId);
    Task<bool> RemoveList(Guid userId);
    Task<bool> BlockUserAsync(Guid userId, Guid targetUserId);
    Task<bool> UnblockUserAsync(Guid userId, Guid targetUserId);
}