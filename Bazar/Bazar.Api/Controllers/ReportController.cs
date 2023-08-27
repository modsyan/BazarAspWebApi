using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

public class ReportController : BaseController<ReportController, IReportService>
{
    [HttpPost]
    public Task<IActionResult> Add([FromBody] CreateComplaintRequestDto dto)
    {
        throw new NotImplementedException();
    }

    //ADMIN ONLY 
    [HttpGet]
    [Authorize(Roles = "ADMIN")]
    public Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{complaintId}")]
    [Authorize(Roles = "ADMIN")]
    public Task<IActionResult> Get(string complaintId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{complaintId}")]
    [Authorize(Roles = "ADMIN")]
    public Task<IActionResult> Remove(string complaintId)
    {
        throw new NotImplementedException();
    }
}