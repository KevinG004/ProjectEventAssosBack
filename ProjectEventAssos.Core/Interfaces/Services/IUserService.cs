using ProjectEventAssos.Core.Dto.Responses;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IUserService : IBaseService<User, Guid>
    {
        Task<UserResponseEmailDTO?> GetUserByEmail(string email);

        Task<User?> GetUserByUserName(string UserName);
    }
}
