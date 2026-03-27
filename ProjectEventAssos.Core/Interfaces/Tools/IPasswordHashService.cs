using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Tools
{
    public interface IPasswordHashService
    {
        public string PasswordHash(string password);
        bool VerifyPassword(string password, string storedPassword);
    }
}
