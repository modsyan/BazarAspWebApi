using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;

namespace Bazar.Api.Services;

public class BlacklistServices : IBlacklistService
{
    private readonly IUnitOfWork _unitOfWork;

    public BlacklistServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>?> GetList(Guid userId)
    {
        var user = await _unitOfWork.Users.GetAsync(userId, new List<string> { "user" });
        return user?.Blacklist;
    }

    public async Task<bool> RemoveList(Guid userId)
    {
        var user = await _unitOfWork.Users.GetAsync(userId, new List<string> { "user" });
        if (user is null) return false;
        user.Blacklist = null;
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<User?> Include(Guid userId, Guid targetUserId)
    {
        var user = await _unitOfWork.Users.GetAsync(userId);
        var targetUser = await _unitOfWork.Users.GetAsync(targetUserId);
        if (targetUser != null) user?.Blacklist?.Add(targetUser);
        await _unitOfWork.CompleteAsync();
        return targetUser;
    }

    public async Task<User?> Exclude(Guid userId, Guid targetUserId)
    {
        var user = await _unitOfWork.Users.GetAsync(userId, new List<string> { "user" });
        var targetUser = await _unitOfWork.Users.GetAsync(targetUserId);
        if (targetUser != null) user?.Blacklist?.Remove(targetUser);
        await _unitOfWork.CompleteAsync();
        return targetUser;
    }
}