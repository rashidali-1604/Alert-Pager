using AlterPager.Service.Interfaces;
using AlterPager.Service.Models;
using System;

namespace AlterPager.Service.Services
{
    public class SmsService : ISmsService
    {
        public void SendSMS(SmsTarget sms)
        {
            Console.WriteLine($"the email to {sms.PhoneNumber} was sent");
        }
    }
}