using AlterPager.Service.Interfaces;
using AlterPager.Service.Models;
using System;

namespace AlterPager.Service.Services
{
    public class TimerService : ITimerService
    {
        public void SetAcknowledgedTimeout(int serviceId, EscalationPolicy escalationServicePolicy, int timeout)
        {
            Console.WriteLine($"the timeout for service id <{ serviceId}> is sat in { timeout} minutes");
        }
    }
}