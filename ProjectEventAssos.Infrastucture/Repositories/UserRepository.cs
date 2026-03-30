using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Domain.Models;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.Repositories
{
    public class UserRepository(AssocEventContext context) : BaseRepository<User, Guid>(context), IUserRepository
    {
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _entities.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User?> GetUserByUserName(string UserName)
        {
            return await _entities.FirstOrDefaultAsync(e => e.UserName == UserName);
        }
    }
}
