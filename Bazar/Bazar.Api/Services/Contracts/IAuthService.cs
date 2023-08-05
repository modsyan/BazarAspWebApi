using Bazar.Core.Entities;
using Bazar.Core.Models;

namespace Bazar.Api.Services.Contracts;

public interface IAuthService
{
    public Task<User> Register(User user, string password);
    public Task<User> Login(string email, string password);
    public Task<string> GenerateToken(User user);
}