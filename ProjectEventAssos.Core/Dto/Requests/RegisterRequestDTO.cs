using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ProjectEventAssos.Domain.Models;

namespace ProjectEventAssos.Core.Dto.Requests
{
    public class RegisterRequestDTO
    {
        [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
        public string Email { get; set; } = null!;
        public int RoleId { get; set; }

    }
}
