using System.ComponentModel;
using System.Globalization;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Services;

public class BlockService : BaseService<BlockService>, IBlockService
{
    public BlockService(IUnitOfWork unitOfWork, ILogger<BlockService> logger) : base(unitOfWork, logger)
    {
    }

    public async Task<IEnumerable<Block>> GetBlocked(Guid userId)
    {
       return await UnitOfWork.Blocks.FindAllAsync(block => block.BlockerUserId == userId,
            new List<string> { "BlockedUser" });
    }

    public async Task<IEnumerable<Block>> GetBlockedBy(Guid userId)
    {
        return await UnitOfWork.Blocks.FindAllAsync(block => block.BlockedUserId == userId,
            new List<string> { "BlockerUser" });
    }

    public async Task<bool> RemoveList(Guid userId)
    {
        var user = await UnitOfWork.Users.GetAsync(userId, new List<string> { "blacklist" });
        if (user is null) return false;
        await UnitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> BlockUserAsync(Guid userId, Guid targetUserId)
    {
        if (userId == targetUserId) return false;

        var curUser = await UnitOfWork.Users.GetAsync(userId);
        var targetUser = await UnitOfWork.Users.GetAsync(targetUserId);

        if (curUser is null || targetUser is null) return false;

        var block = new Block
        {
            BlockerUserId = userId,
            BlockedUserId = targetUserId,
        };

        var isBlocked = await UnitOfWork.Blocks.FindFirstAsync(b =>
            (b != null && b.BlockerUserId == userId && b.BlockedUserId == targetUserId)) is not null;

        if (isBlocked) return false;

        await UnitOfWork.Blocks.CreateAsync(block);
        await UnitOfWork.CompleteAsync();

        return true;
    }

    public async Task<bool> UnblockUserAsync(Guid userId, Guid targetUserId)
    {
        if (userId == targetUserId) return false;

        var curUser = await UnitOfWork.Users.GetAsync(userId);
        var targetUser = await UnitOfWork.Users.GetAsync(targetUserId);

        if (curUser is null || targetUser is null) return false;

        var blockEntity = await UnitOfWork.Blocks.FindFirstAsync(b =>
            (b != null && b.BlockerUserId == userId && b.BlockedUserId == targetUserId));

        if (blockEntity == null) return false;

        UnitOfWork.Blocks.Delete(blockEntity);
        await UnitOfWork.CompleteAsync();
        return true;
    }
}