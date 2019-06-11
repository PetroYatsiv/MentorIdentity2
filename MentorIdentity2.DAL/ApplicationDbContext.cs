using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MentorIdentity2.DAL.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Section> Sections { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Section>().HasOne(x => x.User).WithMany(s => s.Sections);
            builder.Entity<Topic>().HasOne(x => x.User).WithMany(s => s.Topics);
            builder.Entity<SubTopic>().HasOne(x => x.User).WithMany(s => s.SubTopics);
            builder.Entity<Comment>().HasOne(x => x.User).WithMany(s => s.Comments);
        }
    }
}
