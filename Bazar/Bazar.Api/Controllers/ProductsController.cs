using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Bazar.Core.Models;
using Bazar.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers
{
    // [Authorize(AuthenticationSchemes = "Bearer")]
    [AllowAnonymous]
    public class ProductsController
        : CrudController<ProductsController, IProductService, Product,
            CreateEditProductRequestDto, ProductResponseDto>
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = Mapper.Map<ProductResponseDto>(Service.GetAll(UserId));
            return Ok(new { sucess = true, products });
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var post = await Service.Get(productId);

            return post is null
                ? NotFound("Product with this id not found")
                : Ok(new
                {
                    sucess = true, product =
                        Mapper.Map<ProductDetailResponseDto>(post)
                });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEditProductRequestDto product)
        {
            // var userId = User?.Claims.FirstOrDefault();
            return Ok("Hello");
        }
    }
}