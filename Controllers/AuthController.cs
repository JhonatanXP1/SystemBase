namespace SystemBase.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SystemBase.Models.DTO;

[Route("[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
    public AuthController()
    {
        
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(sessionStartedDTO))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Login([FromBody]logingDTO loging)
    {
        
        return Ok();
    }
}