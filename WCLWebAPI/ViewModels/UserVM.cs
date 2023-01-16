using System.ComponentModel.DataAnnotations;

namespace WCLWebAPI.Server.ViewModels
{
    public class UserVM
    {
        public Guid Id { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime Dob { get; set; }

        public IList<string> Roles { get; set; }
    }
}
