using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Models;
using Bazar.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers
{
    // [Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]
    public class ProductsController : BaseController<ProductsController, IProductService>
    {

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(
            await Service.GetAll()
        );

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) => Ok(
            await Service.GetById(id)
        );


        [HttpGet("Search{query}")]
        public IActionResult GetByName([FromBody] string name, string query) => Ok(
            Service.FindByName(name)
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