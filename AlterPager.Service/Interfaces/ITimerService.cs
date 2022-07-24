using AlterPager.Service.Models;

namespace AlterPager.Service.Interfaces
{
    public interface ITimerService
    {
        void SetAcknowledgedTimeout(int serviceId, EscalationPolicy escalationPolicy, int timeout);
    }
}