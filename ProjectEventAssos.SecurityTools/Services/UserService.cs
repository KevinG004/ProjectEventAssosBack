using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.SecurityTools.Services
{
    public class UserRepository(AssocEventContext context) : BaseRepository<User, Guid>(context), IUserRepository
    {
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _entities.FirstOrDefaultAsync(e => e.Email == email);
        }

    }
}
