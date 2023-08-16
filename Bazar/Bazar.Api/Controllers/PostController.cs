using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPostService _postService;

    public PostController(IMapper mapper, IPostService postService)
    {
        _mapper = mapper;
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(
        await _postService.GetAll()
    );

    [HttpGet("/{postId:guid}")]
    public async Task<IActionResult> Get([FromQuery] Guid postId) => Ok(
        await _postService.FindById(postId)
    );

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEditPostRequestDto dto)
    {
        // needed to store with file mangement dto.UploadedImages;
        var post = _mapper.Map<Post>(dto);
        var createdPost = _postService.Crate(post);
        var postResponse = _mapper.Map<CreateEditPostResponseDto>(post);

        // var user = _userService.
        
        return Ok(postResponse);
    }

    [HttpPut("/{postId:guid}")]
    public async Task<IActionResult> Update(Guid postId, [FromBody] CreateEditPostResponseDto dto)
    {
        var post = _mapper.Map<Post>(dto);
        var updatedPost = _postService.Update(postId, post);
        var postResponse = _mapper.Map<CreateEditPostResponseDto>(updatedPost);

        return Ok(postResponse);
    }

    [HttpDelete("{postId:guid}")]
    public async Task<IActionResult> Delete(Guid postId)
    {
        _postService.Remove(postId);
        return Ok("Post Deleted Successfully");
    }
}