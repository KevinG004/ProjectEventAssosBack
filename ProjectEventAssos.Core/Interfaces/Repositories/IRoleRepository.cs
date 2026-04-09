using ProjectEventAssos.Core.Dto.Requests.Roles;
using ProjectEventAssos.Core.Dto.Responses.Roles;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<Role>> GetRolesAsync();
        
        public Task Post(Role role);

        public Task<Role> GetById(int id);

        public Task Delete(int id);
    }
}
