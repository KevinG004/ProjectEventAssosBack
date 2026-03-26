using ProjectEventAssos.Core.Dto.Requests;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    internal interface IAuthService
    {
        Task<User> Register(RegisterRequestDTO credentials);
        Task<LoginResponseDTO> Login(LoginRequestDTO credentials);
    }
}
