using AlterPager.Service.Models;

namespace AlterPager.Service.Interfaces
{
    public interface IEscalationServicePolicy
    {
        EscalationPolicy GetPolicyByServiceId(int monitoredServiceId);
    }
}