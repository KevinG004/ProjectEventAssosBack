using ProjectEventAssos.Domain.Enum;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Requests.Event
{
    public class CreateEventRequestDTO
    {
        public byte[]? CoverImage { get; set; }
        public int CategorieId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Place { get; set; } = string.Empty;
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public bool WaitList { get; set; }
        public DateTime DateLimiteInscription { get; set; }
    }
}
