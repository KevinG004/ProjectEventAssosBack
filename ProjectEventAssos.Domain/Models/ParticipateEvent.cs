using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class ParticipateEvent
    {
        public User? User { get; set; }
        public Guid UserId { get; set; }
        public Event? Event { get; set; }
        public Guid EventId { get; set; }
    }
}
