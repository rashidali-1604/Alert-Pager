using System.Collections.Generic;
using System.Linq;

namespace AlterPager.Service.DataSource.EscalationPolicy.Providers
{
    public class MemoryEscalationPolicyDataSource : EscalationPolicyDataSource
    {
        public List<Models.EscalationPolicy> EscalationPolicies { get; set; } = new List<Models.EscalationPolicy>();

        public Models.EscalationPolicy GetEscalationPolicyByServiceId(int monitoredServiceId)

        {
            return EscalationPolicies.FirstOrDefault(x => x.MonitoredServiceId == monitoredServiceId);
        }

        public void AddEscalationPolicy(Models.EscalationPolicy escalationPolicy)
        {
            EscalationPolicies.Add(escalationPolicy);
        }
    }
}