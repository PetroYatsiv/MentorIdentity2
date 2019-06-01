using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MentorIdentity2.DAL.Models
{
    public class SubTopic
    {
        public SubTopic()
        {
            Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubTopicDescription { get; set; }

        [Required]
        public Topic Topic { get; set; }
        [Required]
        public int TopicId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        [Required]
        public int IdentityUserId { get; set; }
    }
}
