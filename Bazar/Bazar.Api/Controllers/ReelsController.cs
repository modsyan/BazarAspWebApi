using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReelsController : ControllerBase 
{
    private readonly IMapper _mapper;

    public ReelsController(IMapper mapper)
    {
        _mapper = mapper;
    }
}