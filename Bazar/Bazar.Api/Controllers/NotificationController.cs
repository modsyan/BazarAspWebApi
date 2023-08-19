using AutoMapper;
using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
public class NotificationController : BaseController<NotificationController, INotificationService>
{
    //Pagination
    [HttpGet("{page:int}")]
    public Task<IActionResult> Get(int page = 0)
    {
        throw new NotImplementedException();
    }
}