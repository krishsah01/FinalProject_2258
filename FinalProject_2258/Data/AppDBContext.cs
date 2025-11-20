using Microsoft.EntityFrameworkCore;
using FinalProject_2258.Models;

namespace FinalProject_2258.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}