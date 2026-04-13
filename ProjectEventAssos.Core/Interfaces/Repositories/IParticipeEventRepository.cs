using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Repositories
{
    public interface IParticipeEventRepository
    {
        public Task<bool> IsUserRegisterAsync(Guid userId, Guid eventId);

        public Task<int> CountParticipantsAsync(Guid eventId);

        public Task AddParticipantsAsync(ParticipateEvent participateEvent);

        public Task RemoveParticipantsAsync(Guid userId, Guid eventId);

        public Task<List<ParticipateEvent>> GetParticipantsAsync(Guid eventId);
    }
}
