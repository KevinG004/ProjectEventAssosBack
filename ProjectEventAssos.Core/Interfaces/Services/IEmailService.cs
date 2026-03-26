using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Core.Interfaces.Services
{
    internal interface IEmailService
    {
        Task SendWelcomeEmailAsync(string toEmail, string userName);
    }
}
