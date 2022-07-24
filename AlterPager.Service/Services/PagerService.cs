using AlterPager.Service.DataSource.Pager;
using AlterPager.Service.Interfaces;
using AlterPager.Service.Models;
using static AlterPager.Service.Models.Constants;

namespace AlterPager.Service.Services
{
    public class PagerService : IPagerService
    {
        private PagerDataSource pagerDataSource;
        private readonly IEscalationServicePolicy _escalationServicePolicy;
        private readonly IPagerProvidersFactory _pagerProvidersFactory;
        private readonly IMailService _mailService;
        private readonly ISmsService _smsService;
        private readonly ITimerService _timerService;

        public PagerService(IEscalationServicePolicy escalationServicePolicy, IPagerProvidersFactory pagerProvidersFactory, IMailService mailService, ISmsService smsService, ITimerService timerService)
        {
            _escalationServicePolicy = escalationServicePolicy;
            _pagerProvidersFactory = pagerProvidersFactory;
            pagerDataSource = _pagerProvidersFactory.GetDataSourceProvider();
            _mailService = mailService;
            _smsService = smsService;
            _timerService = timerService;
        }

        public void HandleAcknowledged(int serviceId)
        {
            UpdateServiceHealthyStatus(serviceId, true);
        }

        public void HandleAcknowledgedTimeout(EscalationPolicy escalationPolicy, int monitoredService)
        {
            NotifyNextAvailableTargets(escalationPolicy);
        }

        public void NotifyNextAvailableTargets(EscalationPolicy escalationPolicy)
        {
            var policyLevel = escalationPolicy.getNextNonSentPolicyLevel();
            if (policyLevel != null && !policyLevel.IsSent && policyLevel.Targets.Count > 0)
            {
                SendNotifications(policyLevel);
            }
        }

        public bool ProcessAlert(Alert alert)
        {
            bool alertProcessed = false;
            var monitoredService = pagerDataSource.GetMonitoredServiceById(alert.MonitoredServiceId);
            if (monitoredService != null && monitoredService.HealthyStatus)
            {
                monitoredService = UpdateServiceHealthyStatus(alert.MonitoredServiceId, false);
                var escalationPolicy = _escalationServicePolicy.GetPolicyByServiceId(monitoredService.Id);
                NotifyNextAvailableTargets(escalationPolicy);
                _timerService.SetAcknowledgedTimeout(monitoredService.Id, escalationPolicy, defaultTimeOut);
                alertProcessed = true;
            }
            return alertProcessed;
        }

        public void SendNotifications(PolicyLevel policyLevel)
        {
            policyLevel.Targets.ForEach(x =>
            {
                if (x.Type == Targets.EMAIL.ToString())
                {
                    _mailService.SendEmail((EmailTarget)x);
                }
                else
                {
                    _smsService.SendSMS((SmsTarget)x);
                }
            });

            policyLevel.sendToTargets();
        }

        public MonitoredService UpdateServiceHealthyStatus(int serviceId, bool status)
        {
            if (status)
            {
                var escalationPolicy = _escalationServicePolicy.GetPolicyByServiceId(serviceId);
                escalationPolicy.restorePolicyLevelStatus();
            }

            return pagerDataSource.UpdateServiceHealthyStatus(serviceId, status);
        }
    }
}