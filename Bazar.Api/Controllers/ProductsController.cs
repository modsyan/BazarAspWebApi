using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazar.Api.Services.Interfaces;
using Bazar.Core.Models;
using Bazar.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(long id) => Ok(
            await _productsService.GetById(id)
        );

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(
            await _productsService.GetAll()
        );

        public IActionResult GetByName(string name) => Ok(
            _productsService.get
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
    }
}