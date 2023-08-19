using AutoMapper;
using AutoMapper.Internal.Mappers;
using Bazar.Api.Controllers.Base;
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

[Route("/api/[controller]")]
public class FaqController : BaseController<FaqController, IFaqService>
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // map form list to list --> TODO: FIX BUG HERE
        return Ok(Mapper.Map<GetFaqsResponseDto>(await Service.Get()));
    }

    [HttpGet("/{faqId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid faqId)
    {
        return Ok(Mapper.Map<GetFaqsResponseDto>(await Service.Get(faqId)));
    }

    // Admin 
    [Authorize(Policy = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEditFaqRequestDto dto)
    {
        var newFaq = Mapper.Map<Faq>(dto);
        var createdFaq = await Service.Add(newFaq);
        return Ok(Mapper.Map<CreateEditFaqResponseDto>(createdFaq));
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete("/{faqId:guid}")]
    public async Task<IActionResult> Remove([FromQuery] Guid faqId)
    {
        Service.Remove(faqId);
        return Ok("Removed Successfully");
    }
}