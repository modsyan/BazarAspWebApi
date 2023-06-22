using Bazar.Core.Models;

namespace Bazar.Api.Services.Interfaces;

public interface IAuthService 
{
    public Task<User?> Register(User user, string password);
    public Task<object> Login(string email, string password);
}