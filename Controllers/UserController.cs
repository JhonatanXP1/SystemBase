using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SystemBase.Authorization;
using SystemBase.Services.IServices;

namespace SystemBase.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class UserController(
    IUserService userService,
    IRequestContext requestContext
) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly IRequestContext _requestContext = requestContext;

    [HttpGet("password")]
    public async Task<IActionResult> Password()
    {
        if (!_requestContext.HasUser)
            return Unauthorized();
        return Ok();
    }

    [HttpGet]
    [RequirePermission("users.read.*", "users.read.subordinate", "users.read.self")]
    public async Task<IActionResult> Users(bool? isActive, bool? isDeleted, int? page, int? pageSize)
    {
        if (string.IsNullOrWhiteSpace(_requestContext.ActiveScope))
            return BadRequest("X-Active-Scope requerido");
        
        var users = await _userService.GetAllUsers(isActive, isDeleted, page, pageSize);
        return Ok(users.data);
    }
}