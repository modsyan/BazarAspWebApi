using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazar.Core.Interfaces;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBaseRepository<User> _userRepository;
        public AuthController(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_userRepository.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _userRepository.GetByIdAsync(1));
        }
    }
}