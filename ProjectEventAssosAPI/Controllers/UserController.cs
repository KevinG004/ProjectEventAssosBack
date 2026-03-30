using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
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
        [HttpGet]
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
    }
}
