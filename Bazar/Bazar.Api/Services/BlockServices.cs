using System.ComponentModel;
using System.Globalization;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Services;

public class BlockServices : IBlockService
{
    private readonly IUnitOfWork _unitOfWork;

    public BlockServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Block>> GetBlocked(Guid userId)
    {
        // var user = await _unitOfWork.Users.GetAsync(userId, new List<string> { "BlockedUsers" }) ??
        //            throw new ArgumentException("User not found");
        // var blockedUsers = new List<User>();
        // foreach (var block in user.BlockedUsers)
        //     blockedUsers.Add(await _unitOfWork.Users
        //         .FindSingleAsync(u => u.Id == block.BlockedUserId));

        var blocks = await _unitOfWork.Blocks.FindAllAsync(block => block.BlockerUserId == userId,
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


        return await _unitOfWork.Blocks.FindAllAsync(block => block.BlockedUserId == userId,
            new List<string> { "BlockerUser" });
    }


    public async Task<bool> RemoveList(Guid userId)
    {
        var user = await _unitOfWork.Users.GetAsync(userId, new List<string> { "blacklist" });
        if (user is null) return false;
        // user.Blacklist = null;
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> BlockUserAsync(Guid userId, Guid targetUserId)
    {
        if (userId == targetUserId) return false; // you cannot block yourself

        var curUser = await _unitOfWork.Users.GetAsync(userId);
        var targetUser = await _unitOfWork.Users.GetAsync(targetUserId);

        if (curUser is null || targetUser is null) return false;

        var block = new Block
        {
            BlockerUserId = userId,
            BlockedUserId = targetUserId,
            // BlockerUser = curUser,
            // BlockedUser = targetUser,
        };

        var isBlocked = (await _unitOfWork.Blocks.FindFirstAsync(b =>
            b != null && b.BlockerUserId == userId && b.BlockedUserId == targetUserId)) is not null;


        if (isBlocked) return false;

        await _unitOfWork.Blocks.CreateAsync(block);
        await _unitOfWork.CompleteAsync();
        return true;

        // currentUser.Blacklist ??= new List<User>();
        // if (currentUser.Blacklist.Any(user => user.Id == targetUserId)) return null;

        // return currentUser.Blacklist;
    }

    public async Task<bool> UnblockUserAsync(Guid userId, Guid targetUserId)
    {
        var currentUser = await _unitOfWork.Users.GetAsync(userId, new List<string> { "blacklist" });
        if (currentUser is null) throw new ArgumentException("user not found to unblock another user");

        // if (currentUser.Blacklist is null ||
        // currentUser.Blacklist.Any(user => user.Id == targetUserId)) return null;

        var targetUser = await _unitOfWork.Users.GetAsync(targetUserId);
        if (targetUser is null) return false;

        // currentUser.Blacklist.Remove(targetUser);
        await _unitOfWork.CompleteAsync();

        // return currentUser.Blacklist;
        return true;
    }
}