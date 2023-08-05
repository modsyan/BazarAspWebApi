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
        var user = await _authService.Login(dto.LoginIdentifier, dto.Password);
        if (user == null) return BadRequest("Wrong Credentials, Please Try Again");
        var userResponse = _mapper.Map<LoginUserResponseDto>(user);
        userResponse.Token = await _authService.GenerateToken(user);
        return Ok(new
            {
                Success = true,
                userResponse
            }
        );
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var userCreated = await _authService.Register(user, dto.Password);
        // if (userCreated == null) return BadRequest("Invalid Email or Password");
        var userToSend = _mapper.Map<RegisterUserResponseDto>(user);
        return Created("", userToSend);
    }

    [HttpPost("ResetPassword/{email}")]
    public async Task<IActionResult> ResetPassword(string email)
    {
        throw new NotImplementedException();
    }
}