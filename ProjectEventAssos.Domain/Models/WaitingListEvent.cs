using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class WaitingListEvent
    {
        public int Position { get; set; }
        public required User User { get; set; }
        public Guid UserId { get; set; }
        public required Event Event { get; set; }
        public Guid EventId { get; set; }
        public DateTime InscriptionDate { get; set; }
    }
}
