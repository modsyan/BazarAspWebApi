using Bazar.Core.Models;

namespace Bazar.Api.Services.Interfaces;

public interface IAuthService 
{
    public Task<User?> Register(User user, string password);
    public Task<string> Login(string email, string password);
}