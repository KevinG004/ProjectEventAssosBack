using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class ParticipateEvent
    {
        public required User User { get; set; }
        public Guid UserId { get; set; }
        public required Event Event { get; set; }
        public Guid EventId { get; set; }
    }
}
