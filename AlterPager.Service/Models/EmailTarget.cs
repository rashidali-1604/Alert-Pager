using System.ComponentModel.DataAnnotations;
using static AlterPager.Service.Models.Constants;

namespace AlterPager.Service.Models
{
    public class EmailTarget : Target
    {
        [EmailAddress]
        public string Email { get; set; }

        public EmailTarget(string email) : base(Targets.EMAIL.ToString())
        {
            Email = email;
        }
    }
}