using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Api.Helpers;
using Bazar.Api.Services;
using Bazar.Api.Services.Interfaces;
using Bazar.Core.DTOs;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Bazar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto dto)
        {
            var user = await _authService.Login(dto.Email, dto.Password);
            if (user == null) return BadRequest();
            var sendUser = _mapper.Map<LoginUserResponseDto>(user);
            // sendUser.Token = GenerateToken(user);
            return Ok(new
                {
                    Success = true,
                    Data = sendUser
                }
            );
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto dto)
        {
            var user = _mapper.Map<User>(dto);

            var userCreated = await _authService.Register(user, dto.Password);

            if (userCreated == null) return BadRequest("Invalid Email or Password");

            var userToSend = _mapper.Map<RegisterUserResponseDto>(user);
            return Created("", userToSend);
        }
    }
}