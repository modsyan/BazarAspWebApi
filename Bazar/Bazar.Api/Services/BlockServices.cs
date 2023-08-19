using System.ComponentModel;
using System.Globalization;
using Bazar.Api.Services.Contracts;
using Bazar.Api.Services.Contracts.Base;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Services;

public class BlockServices :  BaseService ,IBlockService
{

    public BlockServices(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<IEnumerable<Block>> GetBlocked(Guid userId)
    {
        // var user = await _unitOfWork.Users.GetAsync(userId, new List<string> { "BlockedUsers" }) ??
        //            throw new ArgumentException("User not found");
        // var blockedUsers = new List<User>();
        // foreach (var block in user.BlockedUsers)
        //     blockedUsers.Add(await _unitOfWork.Users
        //         .FindSingleAsync(u => u.Id == block.BlockedUserId));

        var blocks = await UnitOfWork.Blocks.FindAllAsync(block => block.BlockerUserId == userId,
            new List<string> { "BlockedUser" });

        return blocks;
    }

    public async Task<IEnumerable<Block>> GetBlockedBy(Guid userId)
    {
        // var user = await _unitOfWork.Users.GetAsync(userId, new List<string> { "BlockedByUsers" }) ??
        //            throw new ArgumentException("User not found");
        // var blockedUsers = new List<User>();
        // foreach (var block in user.BlockedUsers)
        //     blockedUsers.Add(await _unitOfWork.Users
        //         .FindSingleAsync(u => u.Id == block.BlockerUserId));
        // return blockedUsers;


        return await UnitOfWork.Blocks.FindAllAsync(block => block.BlockedUserId == userId,
            new List<string> { "BlockerUser" });
    }


    public async Task<bool> RemoveList(Guid userId)
    {
        var user = await UnitOfWork.Users.GetAsync(userId, new List<string> { "blacklist" });
        if (user is null) return false;
        // user.Blacklist = null;
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