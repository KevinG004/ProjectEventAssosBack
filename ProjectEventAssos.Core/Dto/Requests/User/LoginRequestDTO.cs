using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectEventAssos.Core.Dto.Requests.User
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "L'email ou username est requise.")]
        public string Identifiant { get; set; } = null!;

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        public string Password { get; set; } = null!;
    }
}
