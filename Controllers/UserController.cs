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
    IUserService userService
) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("password")]
    public async Task<IActionResult> Password()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (id == null)
            return Unauthorized();
        return Ok();
    }

    [HttpGet]
    [RequirePermission("users.read.*", "users.read.subordinate", "users.read.self")]
    public async Task<IActionResult> Users(bool? isActive, bool? isDeleted, int? page, int? pageSize)
    {
        if (!Request.Headers.TryGetValue("X-Active-Scope", out var activeScope)
            || string.IsNullOrWhiteSpace(activeScope))
            return BadRequest("X-Active-Scope requerido");

        var matched = HttpContext.Items["MatchedPermissions"] as List<string> ?? [];

        var scope = matched.Any(p => p.EndsWith(".*")) ? "all"
            : matched.Any(p => p.EndsWith(".subordinate")) ? "subordinate"
            : "self";

        Console.WriteLine(
            $"el scope is:{scope} y  X-Active-Scope: {activeScope} y matched: {JsonSerializer.Serialize(matched)}");
        var users = await _userService.GetAllUsers(scope, isActive, isDeleted, page, pageSize);
        return Ok(users.data); //users.data);
    }
}