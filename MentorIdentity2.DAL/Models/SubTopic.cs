using System;
using System.Collections.Generic;
using System.Text;

namespace MentorIdentity2.DAL.Models
{
    public class SubTopic
    {
        public SubTopic()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Topic Topic { get; set; }
    }
}
