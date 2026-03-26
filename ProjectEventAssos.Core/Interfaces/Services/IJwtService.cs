using ProjectEventAssos.Core.Dto.Responses;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IJwtService
    {
        Task<LoginResponseDTO> GenerateToken(User user);
    }
}
