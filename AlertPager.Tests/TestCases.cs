using AlertPager.Tests.Mocks;
using AlterPager.Service.Interfaces;
using AlterPager.Service.Models;
using AlterPager.Service.Services;
using Moq;
using NUnit.Framework;

namespace AlertPager.Tests
{
    public class TestCases
    {
        // private PagerDataSourceService _pagerService;
        private IPagerProvidersFactory _pagerProvidersFactory;

        [SetUp]
        public void Init()
        {
            var mockService = new Mock<IPagerProvidersFactory>();
            mockService
                .Setup(m => m.GetDataSourceProvider())
                .Returns(new MockPagerDataSource());

            // _pagerService = _pagerProvidersFactory.GetDataSourceProvider();
        }

        [Test]
        public void Test_1()
        {
            var monitoredServiceId = 1;
            var incomingAlert = new Alert
            {
                MonitoredServiceId = monitoredServiceId,
                Message = "any-1"
            };
        }
    }
}