using AlterPager.Service.Interfaces;
using AlterPager.Service.Models;

namespace AlterPager.Service.Services
{
    public class EscalationServicePolicy : IEscalationServicePolicy
    {
        private readonly IEPProvidersFactory _ePProvidersFactory;

        public EscalationServicePolicy(IEPProvidersFactory ePProvidersFactory)
        {
            _ePProvidersFactory = ePProvidersFactory;
        }

        public EscalationPolicy GetPolicyByServiceId(int monitoredServiceId)
        {
            var dataSourceProvider = _ePProvidersFactory.GetDataSourceProvider();

            return dataSourceProvider.GetEscalationPolicyByServiceId(monitoredServiceId);
        }
    }
}