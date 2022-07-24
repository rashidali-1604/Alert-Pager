using AlterPager.Service.DataSource.Pager.Providers;
using AlterPager.Service.Interfaces;
using System;

namespace AlterPager.Service.DataSource.Pager
{
    public class PagerProvidersFactory : IPagerProvidersFactory
    {
        public PagerDataSource GetDataSourceProvider()
        {
            var soure = "MEMORY"; // Read From Config;

            return soure switch
            {
                "MEMORY" => new MemoryPagerDataSource(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}