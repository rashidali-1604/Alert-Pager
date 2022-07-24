using System.ComponentModel.DataAnnotations;

namespace AlterPager.Service.Models
{
    public class SmsTarget : Target
    {
        [Phone]
        public string PhoneNumber { get; set; }

        public SmsTarget(string phoneNumber) : base(Constants.Targets.SMS.ToString())
        {
            PhoneNumber = phoneNumber;
        }
    }
}