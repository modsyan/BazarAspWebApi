using AutoMapper;
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
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper, SignInManager<User> signInManager,
        UserManager<User> userManager)
    {
        _authService = authService;
        _mapper = mapper;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDto dto)
    {
        var loggedUser = await _authService.Login(dto.LoginIdentifier, dto.Password);
        var user = _mapper.Map<LoginUserResponseDto>(loggedUser);
        var token = await _authService.GenerateToken(loggedUser);
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
        var newUser = _mapper.Map<User>(dto);
        var userCreated = await _authService.Register(newUser, dto.Password);
        var user = _mapper.Map<RegisterUserResponseDto>(userCreated);
        var token = await _authService.GenerateToken(userCreated);

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