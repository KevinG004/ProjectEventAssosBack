using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Repositories
{
    public interface IEventRepository : IBaseRepository<Event,Guid> 
    {
        public Task<PageEventResult> GetPageEventResult(int page);
    }
}
