using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<Event> Events { get; set; } = []; 
    }
}
