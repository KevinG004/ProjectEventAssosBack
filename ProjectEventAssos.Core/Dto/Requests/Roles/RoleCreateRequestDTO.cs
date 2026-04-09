using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Requests.Roles
{
    public class RoleCreateRequestDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères")]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(250, ErrorMessage = "La description ne peut pas dépasser 100 caractères")]
        public string? Description { get; set; }
    }
}
