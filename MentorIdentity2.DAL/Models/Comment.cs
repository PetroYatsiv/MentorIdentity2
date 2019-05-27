using System;
using System.Collections.Generic;
using System.Text;

namespace MentorIdentity2.DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        public SubTopic SubTopic { get; set; }

        //since Comment has a FK to SubTopic, add SubTopicId property
    }
}
