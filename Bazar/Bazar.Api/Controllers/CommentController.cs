using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[Route("api/{resourceType}/{resourceId}/[controller]")]
public class CommentController : BaseController<CommentController, ICommentService>
{
    [HttpGet]
    public async Task<IActionResult> Get(string resourceType, string resourceId)
    {
        if (resourceType == "Posts")
            throw new NotImplementedException();
        else if (resourceType == "Comments")
            throw new NotImplementedException();
        else
            return BadRequest("Invalid resource type.");
    }


    [HttpGet("{commentId}")]
    public async Task<IActionResult> Get(string resourceType, string resourceId, string commentId)
    {
        if (resourceType == "Posts")
            throw new NotImplementedException();
        else if (resourceType == "Comments")
            throw new NotImplementedException();
        else
            return BadRequest("Invalid resource type.");
    }

    [HttpPost]
    public async Task<IActionResult> Create(string resourceType, string resourceId)
    {
        if (resourceType == "Posts")
            throw new NotImplementedException();
        else if (resourceType == "Comments")
            throw new NotImplementedException();
        else
            return BadRequest("Invalid resource type.");
    }

    [HttpPut("{commentId}")]
    public async Task<IActionResult> Update(string resourceType, string resourceId, string commentId,
        UpdateCommentRequestDto dto)
    {
        if (resourceType == "Posts")
            throw new NotImplementedException();
        else if (resourceType == "Comments")
            throw new NotImplementedException();
        else
            return BadRequest("Invalid resource type.");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string resourceType, string resourceId)
    {
        if (resourceType == "Posts")
            throw new NotImplementedException();
        else if (resourceType == "Comments")
            throw new NotImplementedException();
        else
            return BadRequest("Invalid resource type.");
    }
}