﻿using System.Threading.Tasks;

namespace RandalApps.IdentityServer.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
