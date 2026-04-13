using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectEventAssos.Core.Dto.Requests.Event;
using ProjectEventAssos.Core.Dto.Responses.Event;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Domain.Models;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

namespace ProjectEventAssosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController(
        IEventService _eventService
        ) : Controller
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<PageEventResult>> AfficherListeEvent([FromQuery] int page)
        {
            try
            {
                var result = await _eventService.GetPageEventAsync(page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<EventDetailsResponseDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                var EventId = await _eventService.GetEventDetailsAsync(id);
                return Ok(EventId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<CreateEventRequestDTO>> CreateEvent([FromBody] CreateEventRequestDTO createEventRequestDTO)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
                var EvenCreated = await _eventService.CreateEventAsync(createEventRequestDTO, userId);
                return Ok(EvenCreated);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<UpdateEventRequestDTO>> UpdateEventAsync(Guid id, UpdateEventRequestDTO updateEventDto)
        {
            try
            {
                await _eventService.UpdateEventAsync(id, updateEventDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteEventUpdate(Guid id) 
        {
            try
            {
                await _eventService.DeleteAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPatch("{id}/cancel")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CancelEventAsync (Guid id)
        {
            try
            {
                await _eventService.CancelEventAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("{id}/start")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> StartEventAsync(Guid id)
        {
            try
            {
                await _eventService.StartEventAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("{id}/close")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> CLoseEventAsync(Guid id)
        {
            try
            {
                await _eventService.CloseEventAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("{id}/register")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterToEvent(Guid id)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
                await _eventService.RegisterToEventAsync(userId, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}/unregister")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> UnregisterEvent(Guid id) {
            try
            {
                var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
                await _eventService.UnregisterFromEventAsync(userId, id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
