using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FinalProject_2258.Models;



namespace FinalProject_2258.Data
{
    public class AppDBContext : DBContext
    {
        public AppDBContext(DBContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<Pets> Pets { get; set; } // Ethans

        public DbSet<Course> Course { get; set; }
    }
}