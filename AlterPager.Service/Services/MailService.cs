using AlterPager.Service.Interfaces;
using AlterPager.Service.Models;
using System;

namespace AlterPager.Service.Services
{
    public class MailService : IMailService
    {
        public void SendEmail(EmailTarget email)
        {
            Console.WriteLine($"the email to {email.Email} was sent");
        }
    }
}