using ProjectEventAssos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class Event
    {
        public byte[]? CoverImage { get; set; }
        public Guid Id { get; set; }
        public int CategorieId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Place {  get; set; } = string.Empty;
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public StatusEvent Status { get; set; } = StatusEvent.EnAttente;
        public bool WaitList { get; set; }
        public DateTime DateLimiteInscription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime MajDate { get; set; }
        public required Categorie Categorie { get; set; }
        public ICollection<ParticipateEvent> Participants { get; set; } = [];
        public ICollection<WaitingListEvent> ListWait { get; set; } = [];
    }
}
