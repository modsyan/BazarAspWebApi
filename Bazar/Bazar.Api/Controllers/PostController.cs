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
    public async Task<IActionResult> Get()
    {
        var posts = await Service.GetAll(UserId);
        return Ok(new
        {
            sucess = true,
            posts = posts.Select(post => Mapper.Map<PostResponseDto>(post))
        });
    }

    [HttpGet("{postId:guid}")]
    public async Task<IActionResult> Get([FromQuery] Guid postId)
    {
        var post = await Service.Get(postId);

        return Ok(new
        {
            success = true,
            post = Mapper.Map<PostDetailResponseDto>(post)
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEditPostRequestDto dto)
    {
        var post = Mapper.Map<Post>(dto);
        var createdPost = await Service.Add(UserId, post);
        var postResponse = Mapper.Map<PostDetailResponseDto>(createdPost);

        return CreatedAtAction("Get", new
        {
            sucess = true,
            post = postResponse
        });
    }

    [HttpPatch("{postId:guid}")]
    public async Task<IActionResult> Update(Guid postId, [FromBody] CreateEditPostRequestDto dto)
    {
        var post = Mapper.Map<Post>(dto);
        var updatedPost = await Service.Edit(postId, post);
        var postResponse = Mapper.Map<PostDetailResponseDto>(updatedPost);

        return Ok(new
        {
            sucess = true,
            post = postResponse
        });
    }

    [HttpDelete("{postId:guid}")]
    public async Task<IActionResult> Delete(Guid postId)
    {
        var isDeleted = Service.Delete(postId);
        return isDeleted is false
            ? NotFound("Post with this Id not Found")
            : Ok(new { success = true, message = "Post Deleted Successfully" });
    }
}