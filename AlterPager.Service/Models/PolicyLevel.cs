using System.Collections.Generic;

namespace AlterPager.Service.Models
{
    public class PolicyLevel
    {
        public List<Target> Targets { get; set; }

        public bool IsSent { get; set; }

        public void sendToTargets()
        {
            IsSent = true;
        }
    }
}