using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace ProjectEventAssos.Domain.Models
{
    public class User
    {
        public Guid Id {  get; set; }
        public bool PasswordChanged { get; set; } = false;
        public int RoleId { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public char? Gender { get; set; }
        public Role Role { get; set; } = null!;
    }
}
