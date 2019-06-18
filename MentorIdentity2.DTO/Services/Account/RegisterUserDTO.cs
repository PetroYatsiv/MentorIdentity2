using System;
using System.Collections.Generic;
using System.Text;

namespace MentorIdentity2.DTO.Services.Account
{
    public class RegisterUserDTO
    {
        public DateTime BirthdayDate { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string Email { get; set; }
    }
}
