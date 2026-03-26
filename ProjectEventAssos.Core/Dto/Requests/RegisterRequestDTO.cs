using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectEventAssos.Core.Dto.Requests
{
    internal class RegisterRequestDTO
    {
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?=&])[A-Za-z\d@$!%*?=&]{8,}$",
        ErrorMessage = "Le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial")]
        public string Password { get; set; } = null!;


        [StringLength(100, ErrorMessage = "La longueur maximum doit être comprise entre 2 et 100 caractères", MinimumLength = 2)]
        public string UserName { get; set; } = null!;

    }
}
