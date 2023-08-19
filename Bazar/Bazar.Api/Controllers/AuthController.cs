using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController<AuthController, IAuthService>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController(SignInManager<User> signInManager,
        UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDto dto)
    {
        var loggedUser = await Service.Login(dto.LoginIdentifier, dto.Password);
        var user = Mapper.Map<LoginUserResponseDto>(loggedUser);
        var token = await Service.GenerateToken(loggedUser);
        return Ok(new
            {
                Success = true,
                user,
                token
            }
        );
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto dto)
    {
        var newUser = Mapper.Map<User>(dto);
        var userCreated = await Service.Register(newUser, dto.Password);
        var user = Mapper.Map<RegisterUserResponseDto>(userCreated);
        var token = await Service.GenerateToken(userCreated);

        return CreatedAtAction(
            "GetById",
            new { controller = "User", id = user.Id },
            new
            {
                success = true,
                user,
                token
            }
        );
    }

    [HttpPost("ResetPassword/{email}")]
    public async Task<IActionResult> ResetPassword(string email)
    {
        throw new NotImplementedException();
    }
}