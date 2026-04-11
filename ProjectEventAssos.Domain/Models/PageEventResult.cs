using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class PageEventResult
    {
        public int NbreEvenements { get; set; }

        public ICollection<Event> Events { get; set; } = [];
    }
}
