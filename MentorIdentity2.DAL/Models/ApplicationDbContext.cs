using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MentorIdentity2.DAL.Models
{
    //ApplicationDbContext should not be at the same folder with Models. Move it to root.
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; } //IdentityDbContext has its own table for Users. It is called AspNetUsers, please remove this.
        public DbSet<Section> Section { get; set; } // DbSet property name should be in plural, e.g. Sections. Change it for all.
        public DbSet<Topic> Topic { get; set; }
        public DbSet<SubTopic> SubTopic { get; set; }
        public DbSet<Comment> Comment { get; set; } 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
