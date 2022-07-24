using AlterPager.Service.Models;

namespace AlterPager.Service.Interfaces
{
    public interface IMailService
    {
        void SendEmail(EmailTarget email);
    }
}