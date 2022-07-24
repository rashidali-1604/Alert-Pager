using AlterPager.Service.Models;

namespace AlterPager.Service.Interfaces
{
    public interface IPagerService
    {
        MonitoredService UpdateServiceHealthyStatus(int serviceId, bool status);

        void SendNotifications(PolicyLevel policyLevel);

        bool ProcessAlert(Alert alert);

        void HandleAcknowledgedTimeout(EscalationPolicy escalationPolicy, int monitoredService);

        void HandleAcknowledged(int serviceId);

        void NotifyNextAvailableTargets(EscalationPolicy escalationPolicy);
    }
}