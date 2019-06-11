using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MentorIdentity2.DAL.Models
{
    public class Section
    {
        public Section() => Topics = new HashSet<Topic>();
        [Key]
        public int Id { get; set; }
        [Required]
        public string SectionDescription { get; set; }

        public ICollection<Topic> Topics { get; set; }
      
        [Required]
        public bool IsActive { get; set; }

        public User User { get; set; }
    }
}
