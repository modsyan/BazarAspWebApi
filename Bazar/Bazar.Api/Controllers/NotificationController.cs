using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;


[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class NotificationController: ControllerBase
{
    private readonly IMapper _mapper;

    public NotificationController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    //Pagination
    [HttpGet("{page:int}")]
    public Task<IActionResult> Get(int page = 0)
    {
        throw new NotImplementedException();
    }
}