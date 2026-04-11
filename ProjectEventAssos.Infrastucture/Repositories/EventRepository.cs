using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Domain.Models;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.Repositories
{
    public class EventRepository(AssocEventContext context) : BaseRepository<Event, Guid>(context), IEventRepository
    {
        private const int PageSize = 10;
        public async Task<PageEventResult> GetPageEventResult(int page)
        {
            var EventsPagination = _entities.Where(e => e.Status != Domain.Enum.StatusEvent.Terminer && e.Status != Domain.Enum.StatusEvent.Annuler)
                .OrderByDescending(e => e.MajDate);
            var NbresEvenements = await EventsPagination.CountAsync();

            var Pagination = await EventsPagination.Skip((page - 1) * PageSize).Take(PageSize).ToListAsync();

            return new PageEventResult
            {
                Events = Pagination,
                NbreEvenements = NbresEvenements
            };
        }
        public override async Task<Event?> GetByIdAsync(Guid Id)
        {
            return await _entities.Include(e => e.Participants)
                .Include(e => e.WaitList)
                .FirstOrDefaultAsync(e => e.Id == Id);
        }
    }
}
