using AlterPager.Service.DataSource.EscalationPolicy.Providers;
using AlterPager.Service.Interfaces;
using System;

namespace AlterPager.Service.DataSource.EscalationPolicy
{
    public class EPProvidersFactory : IEPProvidersFactory
    {
        public EscalationPolicyDataSource GetDataSourceProvider()
        {
            var soure = "MEMORY"; // Read From Config;

            return soure switch
            {
                "MEMORY" => new MemoryEscalationPolicyDataSource(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}