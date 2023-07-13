using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Api.Services.Interfaces;
using Bazar.Core.DTOs;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    
    public AuthController(IAuthService authService, IMapper mapper)
    {
        _authService = authService;
        _mapper = mapper;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequestDto dto)
    {
        
        var user = await _authService.Login(dto.Email, dto.Password);
        
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
        if (userCreated == null) return BadRequest("Invalid Email or Password");
        var userToSend = _mapper.Map<RegisterUserResponseDto>(user);
        return Created("", userToSend);
    }

    [HttpPost("ResetPassword/{email}")]
    public async Task<IActionResult> ResetPassword(string email)
    {
        throw new NotImplementedException();
    }
}