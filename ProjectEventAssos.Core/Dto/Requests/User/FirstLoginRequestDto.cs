using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Requests.User
{
    public class FirstLoginRequestDto
    {
        [Required(ErrorMessage = "userName obligatoire")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "L'username doit faire au moins 3 caractères")]
        public string? UserName { get; set; } = null!;
        [Required(ErrorMessage = "Password obligatoire")]
        [MinLength(12, ErrorMessage = "Le mot de passe doit au moins contenir 12 caractères.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).+$",
            ErrorMessage = "Le mot de passe doit contenir au moins une majuscule et un caractère spécial.")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Date d'anniv obligatoire")]
        public DateOnly? BirthDate { get; set; }
        [Required(ErrorMessage = "Genre obligatoire")]
        public char? Gender { get; set; } = null!;
        public bool PasswordChanged { get; set; }
    }
}
