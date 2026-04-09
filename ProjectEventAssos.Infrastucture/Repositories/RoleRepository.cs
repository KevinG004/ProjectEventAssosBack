using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Core.Dto.Requests.Roles;
using ProjectEventAssos.Core.Dto.Responses.Roles;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Domain.Models;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ProjectEventAssos.Infrastucture.Repositories
{
    public class RoleRepository(AssocEventContext _context) : IRoleRepository
    {
        public async Task Delete(int id)
        {
            var Role = await _context.Roles.FindAsync(id);
            if(Role != null)
            {
                _context.Remove(Role);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Role> GetById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync(); 
        }
        public async Task Post(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }
    }
}
