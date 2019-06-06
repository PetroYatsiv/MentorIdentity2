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
            builder.Entity<User>().Property(x => x.RegistrationDate).HasColumnType("datetime");
            builder.Entity<User>().Property(x => x.BirthdayDate).HasColumnType("datetime");

            builder.Entity<Section>().HasKey(x => x.Id);
            builder.Entity<Section>().Property(x => x.IdentityUserId).IsRequired();
        }
    }
}
