using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Domain.Models;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.Repositories
{
    public class WaitingListRepository(AssocEventContext _context) : IWaitingListEventRepository
    {
        public async Task AddWaitingListAsync(WaitingListEvent waitingListEvent)
        {
            waitingListEvent.InscriptionDate = DateTime.Now;
            await _context.WaitingListEvents.AddAsync(waitingListEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<WaitingListEvent?> FirstInWaitingList(Guid eventId)
        {
            return await _context.WaitingListEvents.OrderBy(w => w.InscriptionDate).FirstOrDefaultAsync(w => w.EventId == eventId);

        }

        public async Task<List<WaitingListEvent>> GetWaitingListAsync(Guid eventId)
        {
            return await _context.WaitingListEvents
                .Include(w => w.User)
                .Where(w => w.EventId == eventId)
                .OrderBy(w => w.InscriptionDate)
                .ToListAsync();
        }

        public async Task<int> GetWaitingListCountAsync(Guid eventId)
        {
            return await _context.WaitingListEvents.CountAsync(w => w.EventId == eventId);
        }

        public async Task<bool> IsUserInWaitingListAsync(Guid userId, Guid eventId)
        {
            return await _context.WaitingListEvents.AnyAsync(w => w.UserId == userId && w.EventId == eventId);
        }

        public async Task RemoveWaitingListAsync(Guid userId, Guid eventId)
        {
            var Deleteuser = await _context.WaitingListEvents.FirstOrDefaultAsync(w => w.UserId ==  userId && w.EventId == eventId);
            if(Deleteuser != null)
            {
                _context.WaitingListEvents.Remove(Deleteuser);
                await _context.SaveChangesAsync();
            }
        }
    }
}
