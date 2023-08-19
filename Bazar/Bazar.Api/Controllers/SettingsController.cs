using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[Route("api/users/me/[controller]")]
public class SettingsController : BaseController<SettingsController, ISettingsService>
{
    [HttpGet]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task<IActionResult> Update()
    {
        throw new NotImplementedException();
    }

    [HttpPost("reset")]
    public Task<IActionResult> Reset()
    {
        throw new NotImplementedException();
    }
}