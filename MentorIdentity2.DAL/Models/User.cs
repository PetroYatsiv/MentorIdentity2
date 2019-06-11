using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentorIdentity2.DAL.Models
{
    public class User : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime BirthdayDate { get; set; }

        public ICollection<Section> Sections { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<SubTopic> SubTopics { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
