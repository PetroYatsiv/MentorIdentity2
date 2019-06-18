using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorIdentity2.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Date of Birthday")]
        public DateTime BirthdayDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
