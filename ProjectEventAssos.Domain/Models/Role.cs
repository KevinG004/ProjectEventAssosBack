using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
