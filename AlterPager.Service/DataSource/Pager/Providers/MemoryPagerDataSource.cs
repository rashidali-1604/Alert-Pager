using AlterPager.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlterPager.Service.DataSource.Pager.Providers
{
    public class MemoryPagerDataSource : PagerDataSource
    {
        public List<MonitoredService> MonitoredServices { get; set; } = new List<MonitoredService>();

        public MonitoredService GetMonitoredServiceById(int monitoredServiceId)
        {
            return MonitoredServices.FirstOrDefault(x => x.Id == monitoredServiceId);
        }

        public void AddMonitoredService(MonitoredService monitoredService)
        {
            MonitoredServices.Add(monitoredService);
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