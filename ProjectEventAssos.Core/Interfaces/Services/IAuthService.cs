using ProjectEventAssos.Core.Dto.Requests.User;
using ProjectEventAssos.Core.Dto.Responses.User;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User> Register(RegisterRequestDTO credentials);
        Task<LoginResponseDTO> Login(LoginRequestDTO credentials);
    }
}
