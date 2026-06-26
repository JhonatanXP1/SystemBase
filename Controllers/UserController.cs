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

        var matched = _requestContext.MatchedPermissions;

        var scope = matched.Any(p => p.EndsWith(".*")) ? "all"
            : matched.Any(p => p.EndsWith(".subordinate")) ? "subordinate"
            : "self";

        Console.WriteLine(
            $"el scope is:{scope} y  X-Active-Scope: {_requestContext.ActiveScope} y matched: {JsonSerializer.Serialize(matched)}");
        var users = await _userService.GetAllUsers(scope, isActive, isDeleted, page, pageSize);
        return Ok(users.data);
    }
}