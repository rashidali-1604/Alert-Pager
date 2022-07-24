using AlterPager.Service.DataSource.Pager;

namespace AlterPager.Service.Interfaces
{
    public interface IPagerProvidersFactory
    {
        PagerDataSource GetDataSourceProvider();
    }
}