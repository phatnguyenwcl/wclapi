﻿using System.ComponentModel.DataAnnotations;

namespace WCLWebAPI.Server.ViewModels
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }
}
