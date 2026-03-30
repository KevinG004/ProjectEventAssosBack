using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProjectEventAssos.SecurityTools.Services
{
    public class UserService(IUserRepository _userRespository) : IUserService
    {
        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingUser = await _userRespository.ExistsAsync(id);
            if (!existingUser) throw new KeyNotFoundException("Id not found");
            await _userRespository.DeleteAsync(id);
        }

        public Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRespository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRespository.GetByIdAsync(id);
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Guid id, User user)
        {
            await _userRespository.UpdateAsync(id, user);
        }
    }
}
