using AutoMapper;
using AutoMapper.Internal.Mappers;
using Bazar.Api.Services.Contracts;
using Bazar.Core.Constants;
using Bazar.Core.DTOs;
using Bazar.Core.Entities;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using NuGet.Protocol;

namespace Bazar.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FaqController : ControllerBase
{
    private readonly IFaqService _faqService;
    private readonly Mapper _mapper;

    public FaqController(IFaqService faqService, Mapper mapper)
    {
        _faqService = faqService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // map form list to list --> TODO: FIX BUG HERE
        return Ok(_mapper.Map<GetFaqsResponseDto>(await _faqService.Get()));
    }

    [HttpGet("/{faqId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid faqId)
    {
        return Ok(_mapper.Map<GetFaqsResponseDto>(await _faqService.Get(faqId)));
    }

    // Admin 
    [Authorize(Policy = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEditFaqRequestDto dto)
    {
        var newFaq = _mapper.Map<Faq>(dto);
        var createdFaq = await _faqService.Add(newFaq);
        return Ok(_mapper.Map<CreateEditFaqResponseDto>(createdFaq));
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete("/{faqId:guid}")]
    public async Task<IActionResult> Remove([FromQuery] Guid faqId)
    {
        _faqService.Remove(faqId);
        return Ok("Removed Successfully");
    }
}