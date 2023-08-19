using Bazar.Api.Controllers.Base;
using Bazar.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Route("api/posts/[controller]")]
public class TagController : BaseController<TagController, ITagService>
{
}