using Microsoft.AspNetCore.Mvc;
using ProjectEventAssos.Core.Dto.Requests;
using ProjectEventAssos.Core.Dto.Responses;
using ProjectEventAssos.Core.Interfaces.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectEventAssos.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService _authService) : ControllerBase
{

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDTO request)
    {
        try
        {
            var createdUser = await _authService.Register(request);

            return Ok(createdUser);
        }
        catch (Exception ex)
        {
            return Conflict(new { ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO request)
    {
        try
        {
            var loginResponse = await _authService.Login(request);
            return Ok(loginResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

}
