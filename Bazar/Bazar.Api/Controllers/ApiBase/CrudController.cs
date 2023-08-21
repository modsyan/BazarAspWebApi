using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Mvc;
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
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var entities = await Service.GetAll(UserId);

        return Ok(new
        {
            status = true,
            entities = entities.Select(a => Mapper.Map<TDtoResponse>(a))
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(new
        {
            status = true,
            entity = Mapper.Map<TDtoResponse>(Service.Get(id))
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TCreateUpdateRequestDto dto)
    {
        var entity = Mapper.Map<TEntity>(dto);

        //TODO: Adding USERID or User Here if it anything (from services) 
        //TODO: Mapping profile of each Entity with Dto and Move User Manipulation to Service layer
        var createdEntity = await Service.Add(UserId,entity);

        var entityResponse = Mapper.Map<TDtoResponse>(createdEntity);

        return Ok(new
        {
            success = true,
            entityResponse
        });
    }

    [HttpPatch("{entityId:guid}")]
    public async Task<IActionResult> Edit([FromRoute] Guid entityId, [FromBody] TCreateUpdateRequestDto dto)
    {
        var entity = Mapper.Map<TEntity>(dto);

        var updatedEntity = await Service.Edit(entityId, entity);

        var entityResponse = Mapper.Map<TDtoResponse>(updatedEntity);

        return Ok(new
        {
            success = true,
            entityResponse
        });
    }

    [HttpDelete("{entityId:guid}")]
    public async Task<IActionResult> Delete(Guid entityId)
    {
        var isDeleted = Service.Delete(entityId);
        return !isDeleted
            ? NotFound($"{typeof(TEntity)} with this {entityId} not Found.")
            : Ok(new
            {
                status = true,
                message = $"{typeof(TEntity)} deleted successfully"
            });
    }
}