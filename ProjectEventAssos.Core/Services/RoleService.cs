using ProjectEventAssos.Core.Dto.Requests.Roles;
using ProjectEventAssos.Core.Dto.Responses.Roles;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Services
{
    public class RoleService(IRoleRepository _roleRepository) : IRoleService
    {
        public async Task Delete(int id)
        {
            var roleExisting = await _roleRepository.GetById(id);

            if (roleExisting == null)
            {
                throw new KeyNotFoundException($"Role with ID {id} not found");
            }

            await _roleRepository.Delete(id);
        }

        public async Task<RoleResponseDTO> GetById(int id)
        {
            var role = await _roleRepository.GetById(id);

            if (role == null)
            {
                return null;
            }
            return new RoleResponseDTO
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public async Task<IEnumerable<RoleResponseDTO>> GetRolesAsync()
        {
            var roles = await _roleRepository.GetRolesAsync();

            return roles.Select(r => new RoleResponseDTO
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
        }

        public async Task Post(RoleCreateRequestDTO roleCreateRequestDTO)
        {
            var newRole = new Role
            {
                Name = roleCreateRequestDTO.Name,
                Description = roleCreateRequestDTO.Description,
            };
            await _roleRepository.Post(newRole);
        }
    }
}
