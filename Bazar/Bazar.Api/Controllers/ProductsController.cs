using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Api.Services.Interfaces;
using Bazar.Core.DTOs;
using Bazar.Core.Models;
using Bazar.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous] 
    public class ProductsController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(
            await _productService.GetAll()
        );
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) => Ok(
            await _productService.GetById(id)
        );
        

        [HttpGet("Search{query}")]
        public IActionResult GetByName([FromBody] string name) => Ok(
            _productService.FindByName(name)
        );


        [HttpGet("FindFirstByNameAsync")]
        public async Task<IActionResult> FindFirstByNameAsync(string name) => Ok(
        );

        [HttpGet("FindAllByName")]
        public IActionResult FindAllByName(string name) => Ok(
        );


        [HttpGet("FindAllByNameAsync")]
        public async Task<IActionResult> FindAllByNameAsync(string name) => Ok(
        );

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestDto product)
        {
            // var userId = User?.Claims.FirstOrDefault();
            return Ok("Hello");
        }
    }
}