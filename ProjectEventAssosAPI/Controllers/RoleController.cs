using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEventAssos.Core.Dto.Requests.Roles;
using ProjectEventAssos.Core.Dto.Responses;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Domain.Models;
using System.Data;

namespace ProjectEventAssosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController(IRoleService _roleService) : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Role>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleService.GetRolesAsync();
            if (roles == null)
            {
                return NotFound();
            }
            return Ok(roles);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Role>> GetById(int id) 
        {
            var role = await _roleService.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] RoleCreateRequestDTO roleCreateRequestDTO)
        {
            if (roleCreateRequestDTO == null)
            {
                return BadRequest();
            }
                 await _roleService.Post(roleCreateRequestDTO);
                return Ok(roleCreateRequestDTO);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Role), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _roleService.GetById(id);
            if(role == null)
            {
                return BadRequest();
            }
            await _roleService.Delete(id);
            return Ok();
        }
    }
}
