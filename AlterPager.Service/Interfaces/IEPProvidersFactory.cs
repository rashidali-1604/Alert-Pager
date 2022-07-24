using AlterPager.Service.DataSource.EscalationPolicy;

namespace AlterPager.Service.Interfaces
{
    public interface IEPProvidersFactory
    {
        EscalationPolicyDataSource GetDataSourceProvider();
    }
}