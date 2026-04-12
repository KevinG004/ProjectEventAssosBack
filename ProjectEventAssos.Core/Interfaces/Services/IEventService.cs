using ProjectEventAssos.Core.Dto.Requests.Event;
using ProjectEventAssos.Core.Dto.Responses.Event;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IEventService : IBaseService<Event, Guid>
    {
        Task<Event> CreateEventAsync(CreateEventRequestDTO dto, Guid userId);
        public Task UpdateEventAsync(Guid id, UpdateEventRequestDTO dto);
        public Task<PageEventResult> GetPageEventAsync(int pageId);
        public Task<EventDetailsResponseDTO> GetEventDetailsAsync(Guid id);
        public Task CancelEventAsync(Guid id);
        public Task StartEventAsync(Guid id);
        public Task CloseEventAsync(Guid id);
        public Task RegisterToEventAsync(Guid userId, Guid eventId);
        public Task UnregisterFromEventAsync(Guid userId, Guid eventId);
    }
}
