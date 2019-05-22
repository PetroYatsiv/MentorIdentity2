using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MentorIdentity2.DAL.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<SubTopic> SubTopic { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
