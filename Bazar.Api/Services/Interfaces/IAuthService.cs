using Bazar.Core.Models;

namespace Bazar.Api.Services.Interfaces;

public interface IUserService 
{
    public Task<User?> Register(User user, string password);
    public Task<User?> Login(string email, string password);
}