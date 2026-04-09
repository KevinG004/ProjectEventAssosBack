using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Responses.Roles
{
    public class RoleResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
