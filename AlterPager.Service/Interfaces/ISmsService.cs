using AlterPager.Service.Models;

namespace AlterPager.Service.Interfaces
{
    public interface ISmsService
    {
        void SendSMS(SmsTarget sms);
    }
}