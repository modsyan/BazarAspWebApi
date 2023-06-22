using Bazar.Api.Helpers;
using Bazar.Api.Services.Interfaces;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bazar.Api.Services;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _userRepository;

    public UserService(IBaseRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> Register(User user, string password)
    {
        
        Task<User> createdUser;
        user.Password = HashingPassword.Hash(password);
        
        try
        {
            createdUser = _userRepository.CreateAsync(user);
        } catch(Exception e)
        {
            throw;
        }
        
        return await createdUser;
    }

    public async Task<User?> Login(string email, string password)
    {
        var user = await _userRepository.FindAsync(e => e != null && e.Email == email);
        if (user == null || !HashingPassword.Verify(password, user.Password)) return null;
        return user;
    }
}