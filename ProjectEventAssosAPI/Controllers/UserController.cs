using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEventAssos.Core.Dto.Requests.User;
using ProjectEventAssos.Core.Dto.Responses.User;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Domain.Models;

namespace ProjectEventAssosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserService _userService) : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User?>> GetByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User?>> GetbyId(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("username/{username}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User?>> GetByUserName(string userName) 
        {
            var user = await _userService.GetUserByUserName(userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userService.DeleteAsync(id);
            return Ok();
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FirstLogin(Guid id, [FromBody] FirstLoginRequestDto firstLoginRequestDto) 
        {
            var UserFirsLogin = await _userService.GetByIdAsync(id);
            if (UserFirsLogin == null) 
            {
                return NotFound();
            }
            await _userService.FirstLogin(id, firstLoginRequestDto);
            return Ok();
        }
    }
}
