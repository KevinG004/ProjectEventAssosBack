using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Dto.Responses
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
        public bool PasswordChanged { get; set; }
    }
}
