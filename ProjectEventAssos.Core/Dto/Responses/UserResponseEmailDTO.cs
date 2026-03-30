using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Responses
{
    public class UserResponseEmailDTO
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public char? Gender { get; set; }
        public Role Role { get; set; } = null!;
    }
}
