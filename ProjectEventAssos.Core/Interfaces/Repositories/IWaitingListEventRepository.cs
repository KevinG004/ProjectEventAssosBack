using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Repositories
{
    public interface IWaitingListEventRepository
    {
        public Task<bool> IsUserInWaitingListAsync(Guid userId, Guid eventId);

        public Task<int> GetWaitingListCountAsync(Guid eventId);

        public Task AddWaitingListAsync(WaitingListEvent waitingListEvent);

        public Task RemoveWaitingListAsync(Guid userId ,Guid eventId);

        public Task<WaitingListEvent?> FirstInWaitingList(Guid eventId);

        public Task<List<WaitingListEvent>> GetWaitingListAsync(Guid eventId);

    }
}
