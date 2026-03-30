using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail, string password);
    }
}
