using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MentorIdentity2.DAL.Models
{
    public class Topic
    {
        public Topic()
        {
            SubTopics = new HashSet<SubTopic>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string TopicDescription { get; set; }

        [Required]
        public Section Section { get; set; }
        [Required]
        public int SectionId { get; set; }
                       
        public ICollection<SubTopic> SubTopics { get; set; }
       
        [Required]
        public bool IsActive { get; set; }

        public User User { get; set; }
    }
}
