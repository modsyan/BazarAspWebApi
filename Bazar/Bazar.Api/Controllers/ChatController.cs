using AutoMapper;
using Bazar.Api.Controllers.ApiBase;
using Bazar.Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazar.Api.Controllers;

[Authorize]
public class ChatController : BaseController<ChatController, IChatService>
{
}