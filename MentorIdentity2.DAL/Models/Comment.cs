using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace MentorIdentity2.DAL.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CommentDescription { get; set; }

        [Required]
        public DateTime CommentDate { get; set; }

        [Required]
        public SubTopic SubTopic { get; set; }

        [Required]
        public int SubTopicId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public User User { get; set; }
    }
}
