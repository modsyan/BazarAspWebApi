using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bazar.Api.Helpers;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Entities;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtOptions _jwt;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManger;

    public AuthService(IUnitOfWork unitOfWork, UserManager<User> userManager, IOptions<JwtOptions> jwt,
        IConfiguration configuration, UserManager<User> userManger)
    {
        _configuration = configuration;
        _userManger = userManger;
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<User> Register(User user, string password)
    {
        // if (user.Email != null && await _userManager.FindByEmailAsync(user.Email) is not null)
        //     return new 
        // TODO: USE MANGER TO ONLY USE UNIQUELY EMAIL AND USERNAME
        user.PasswordHash = HashingPassword.Hash(password);
        var createdUser = await _unitOfWork.Users.CreateAsync(user);
        await _unitOfWork.CompleteAsync();

        if (createdUser == null)
            throw new ArgumentException("Cannot Register new account, please try again.");
        return createdUser;
    }

    public async Task<User> Login(string loginIdentifier, string password)
    {
        if (string.IsNullOrWhiteSpace(loginIdentifier) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("missing LoginIdentifier of Password");
        }
        
        var user = await _unitOfWork.Users.FindSingleAsync(user =>
            user != null && (user.Email == loginIdentifier || user.UserName == loginIdentifier));

        if (user == null ||
            string.IsNullOrWhiteSpace(user.PasswordHash) ||
            !HashingPassword.Verify(password, user.PasswordHash))
        {
            throw new ArgumentException("Invalid Credentials, wrong username or password.");
        }

        return user;
    }

    public async Task<string> GenerateToken(User user)
    {
        var userClaims = await _userManger.GetClaimsAsync(user);
        var userRoles = await _userManger.GetRolesAsync(user);
        var roleClaims = userRoles.Select(role => new Claim("roles", role)).ToList();

        var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
            }
            .Union(userClaims)
            .Union(roleClaims);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwt.DurationsInDays),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
}