using System;
using System.Collections.Generic;
using System.Text;

namespace MentorIdentity2.DAL.Models
{
    public class Topic
    {
        public Topic()
        {
            SubTopics = new HashSet<SubTopic>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public int SectionId { get; set; }

        public ICollection<SubTopic> SubTopics { get; set; }

        public Section Section { get; set; }
    }
}
