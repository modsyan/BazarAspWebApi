using Bazar.Api.Services.Contracts;
using Bazar.Core.DTOs;
using Bazar.Core.Models;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;

namespace Bazar.Api.Controllers.ApiBase;

[ApiController]
public class
    CrudController<TController, TService, TEntity, TCreateUpdateRequestDto,
        TDtoResponse> : BaseController<TController, TService>
    where TController : BaseController<TController, TService>
    where TService : ICrudService<TEntity>
    where TCreateUpdateRequestDto : class
    where TDtoResponse : class
{
    public string EntityName => typeof(TEntity).Name;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await Service.GetAll(UserId);
        var entitiesResponse = entities.Select(a => Mapper.Map<TDtoResponse>(a));

        // var response = new JObject
        // {
        //     ["success"] = true,
        //     [typeof(TEntity).Name] = JToken.FromObject(entitiesResponse)
        // }.ToJson();
        // return Content(response, "application/json");
        return Ok(new ApiResult<IEnumerable<TDtoResponse>>(entitiesResponse));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var entityResponse = Mapper.Map<TDtoResponse>(await Service.Get(id));
        return Ok(new ApiResult<TDtoResponse>(entityResponse));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TCreateUpdateRequestDto dto)
    {
        var entity = Mapper.Map<TEntity>(dto);

        //TODO: Adding USERID or User Here if it anything (from services) 
        //TODO: Mapping profile of each Entity with Dto and Move User Manipulation to Service layer
        var createdEntity = await Service.Add(UserId, entity);

        var entityResponse = Mapper.Map<TDtoResponse>(createdEntity);

        return Ok(new ApiResult<TDtoResponse>(
            $"{EntityName} created successfully", entityResponse));
    }

    [HttpPatch("{entityId:guid}")]
    public async Task<IActionResult> Edit([FromRoute] Guid entityId, [FromBody] TCreateUpdateRequestDto dto)
    {
        var entity = Mapper.Map<TEntity>(dto);
        var updatedEntity = await Service.Edit(entityId, entity);
        var entityResponse = Mapper.Map<TDtoResponse>(updatedEntity);
        return Ok(new ApiResult<TDtoResponse>(entityResponse));
    }

    [HttpDelete("{entityId:guid}")]
    public IActionResult Delete(Guid entityId)
    {
        Service.Delete(entityId);
        return Ok(new ApiResult(
            message: $"{EntityName} Deleted Successfully"));
    }
}

[ApiController]
public class CrudController<TController, TService, TEntity, TDto>
    : CrudController<TController, TService, TEntity, TDto, TDto>
    where TController : BaseController<TController, TService>
    where TService : ICrudService<TEntity>
    where TDto : class
{
}

[ApiController]
public class CrudController<TController, TService, TEntity>
    : CrudController<TController, TService, TEntity, TEntity>
    where TController : BaseController<TController, TService>
    where TService : ICrudService<TEntity>
    where TEntity : class
{
}