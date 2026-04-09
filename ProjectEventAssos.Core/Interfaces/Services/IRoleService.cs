using ProjectEventAssos.Core.Dto.Requests.Roles;
using ProjectEventAssos.Core.Dto.Responses.Roles;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IRoleService
    {
        public Task<IEnumerable<RoleResponseDTO>> GetRolesAsync();

        public Task Post(RoleCreateRequestDTO roleCreateRequestDTO);

        public Task<RoleResponseDTO> GetById(int id);

        public Task Delete(int id);
    }
}
