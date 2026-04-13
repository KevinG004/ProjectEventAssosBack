using ProjectEventAssos.Domain.Enum;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Responses.Event
{
    public class EventListResponseDTO
    {
        public byte[]? CoverImage { get; set; }
        public Guid Id { get; set; }
        public string CategorieName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Place { get; set; } = string.Empty;
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeFinish { get; set; }
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public StatusEvent Status { get; set; } = StatusEvent.EnAttente;
        public bool WaitList { get; set; }
        public DateTime DateLimiteInscription { get; set; }
        public int NbInscrits { get; set; }
    }
}
