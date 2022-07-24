using AlterPager.Service.DataSource.Pager;
using AlterPager.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlertPager.Tests.Mocks
{
    public class MockPagerDataSource : PagerDataSource
    {
        public List<MonitoredService> MonitoredServices { get; set; } = new List<MonitoredService>();

        public MockPagerDataSource()
        {
            for (int i = 0; i < 10; i++)
            {
                MonitoredServices[i] = new MonitoredService();
            }
        }

        public MonitoredService GetMonitoredServiceById(int monitoredServiceId)
        {
            return MonitoredServices.FirstOrDefault(x => x.Id == monitoredServiceId);
        }

        public void updateServiceHealthyStatus(int monitoredServiceId, bool status)
        {
            MonitoredServices = MonitoredServices.Select(x =>
            {
                if (x.Id == monitoredServiceId)
                {
                    x.HealthyStatus = status;
                }

                return x;
            })?.ToList();
        }
    }
}