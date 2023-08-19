using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : BaseController<PostController, IPostService>
{
    [HttpGet]
    public async Task<IActionResult> Get() => Ok(
        await Service.GetAll()
    );

    [HttpGet("/{postId:guid}")]
    public async Task<IActionResult> Get([FromQuery] Guid postId) => Ok(
        await Service.FindById(postId)
    );

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEditPostRequestDto dto)
    {
        // needed to store with file mangement dto.UploadedImages;
        var post = Mapper.Map<Post>(dto);
        var createdPost = Service.Crate(post);
        var postResponse = Mapper.Map<CreateEditPostResponseDto>(post);

        // var user = _userService.
        
        return Ok(postResponse);
    }

    [HttpPut("/{postId:guid}")]
    public async Task<IActionResult> Update(Guid postId, [FromBody] CreateEditPostResponseDto dto)
    {
        var post = Mapper.Map<Post>(dto);
        var updatedPost = Service.Update(postId, post);
        var postResponse = Mapper.Map<CreateEditPostResponseDto>(updatedPost);

        return Ok(postResponse);
    }

    [HttpDelete("{postId:guid}")]
    public async Task<IActionResult> Delete(Guid postId)
    {
        Service.Remove(postId);
        return Ok("Post Deleted Successfully");
    }
}