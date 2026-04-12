using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Domain.Models;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.Repositories
{
    public class ParticipeEventRepository(AssocEventContext _context) : IParticipeEventRepository
    {
        public async Task AddParticipantsAsync(ParticipateEvent participateEvent)
        {
            await _context.ParticipateEvents.AddAsync(participateEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountParticipantsAsync(Guid eventId)
        {
            return await _context.ParticipateEvents.CountAsync(p => p.EventId == eventId);       
        }

        public async Task<List<ParticipateEvent>> GetParticipantsAsync(Guid eventId)
        {
            return await _context.ParticipateEvents
                .Include(p => p.User)
                .Where(p => p.EventId == eventId)
                .ToListAsync();
        }

        public async Task<bool> IsUserRegisterAsync(Guid userId, Guid eventId)
        {
            //var userRegistered = await _context.ParticipateEvents.AnyAsync(p => p.UserId == userId && p.EventId == eventId);
            //if(userRegistered == true)
            //{
            //    return true;
            //}
            //return false;
            return await _context.ParticipateEvents.AnyAsync(p => p.UserId == userId && p.EventId == eventId);
        }

        public async Task RemoveParticipantsAsync(Guid userId, Guid eventId)
        {
            var DeleteParticipants = await _context.ParticipateEvents.FirstOrDefaultAsync(p => p.UserId == userId && p.EventId == eventId);
            if (DeleteParticipants != null) 
            {
                _context.ParticipateEvents.Remove(DeleteParticipants);
                await _context.SaveChangesAsync();
            }
        }
    }
}
