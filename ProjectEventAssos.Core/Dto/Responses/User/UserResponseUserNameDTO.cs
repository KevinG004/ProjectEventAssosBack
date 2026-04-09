using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Responses.User
{
    public class UserResponseUserNameDTO
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public DateOnly? BirthDate { get; set; }
        public char? Gender { get; set; }
        public Role Role { get; set; } = null!;
    }
}
