using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FaqController: ControllerBase
{
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }
    
    // Admin 
    public Task<IActionResult> Add(CreateFaqRequestDto dto)
    {
        throw new NotImplementedException();
                
    }
    
    public Task<IActionResult> Remove(string faqId)
    {
        throw new NotImplementedException();
    }
}