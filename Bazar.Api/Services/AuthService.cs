using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Bazar.Api.Helpers;
using Bazar.Api.Services.Interfaces;
using Bazar.Core.DTOs;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly Jwt _jwt;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManger;

    public AuthService(IUnitOfWork unitOfWork, UserManager<User> userManager, IOptions<Jwt> jwt,
        IConfiguration configuration, UserManager<User> userManger)
    {
        _configuration = configuration;
        _userManger = userManger;
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> Register(User user, string password)
    {
        // if (user.Email != null && await _userManager.FindByEmailAsync(user.Email) is not null)
        //     return new 

        user.Password = HashingPassword.Hash(password);
        var createdUser = await _unitOfWork.Users.CreateAsync(user);

        return createdUser;
    }

    public async Task<object> Login(string email, string password)
    {
        var user = await _unitOfWork.Users.FindAsync(e => e != null && e.Email == email);
        if (user == null || !HashingPassword.Verify(password, user.Password)) return null;
        return new object()
        {
            
            
        };
    }

    private async Task<string> GenerateToken(User user)
    {
        var userClaims = await _userManger.GetClaimsAsync(user);
        var userRoles = await _userManger.GetRolesAsync(user);
        var roleClaims = userRoles.Select(role => new Claim("roles", role)).ToList();

        var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.PrimarySid, user.Id),
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