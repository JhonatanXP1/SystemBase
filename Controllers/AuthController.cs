namespace SystemBase.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
    public AuthController()
    {
        
    }

    [HttpPost]
    public IActionResult Login()
    {
        
        return Ok();
    }
}