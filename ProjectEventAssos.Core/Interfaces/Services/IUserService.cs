using ProjectEventAssos.Core.Dto.Requests.User;
using ProjectEventAssos.Core.Dto.Responses.User;
using ProjectEventAssos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IUserService : IBaseService<User, Guid>
    {
        Task<FirstLoginRequestDto> FirstLogin(Guid id, FirstLoginRequestDto firstLoginRequestDto);
        Task<UserResponseEmailDTO?> GetUserByEmail(string email);

        Task<UserResponseUserNameDTO?> GetUserByUserName(string UserName);
    }
}
