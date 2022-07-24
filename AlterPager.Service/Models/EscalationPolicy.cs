using System.Collections.Generic;
using System.Linq;

namespace AlterPager.Service.Models
{
    public class EscalationPolicy
    {
        public int MonitoredServiceId { get; set; }

        public List<PolicyLevel> PolicyLevels { get; set; }

        public PolicyLevel getNextNonSentPolicyLevel()
        {
            return PolicyLevels.FirstOrDefault(x => !x.IsSent);
        }

        public void restorePolicyLevelStatus()
        {
            PolicyLevels.ForEach(x =>
            {
                x.IsSent = false;
            });
        }
    }
}