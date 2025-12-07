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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, Name = "Krish Sah", Role = "Developer", Birthdate = new DateTime(2000, 1, 1), CollegeProgram = "IT", YearInProgram = "Senior" },
                new TeamMember { Id = 2, Name = "John Doe", Role = "Tester", Birthdate = new DateTime(2001, 5, 20), CollegeProgram = "CS", YearInProgram = "Junior" }
            );

            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Gaming", Description = "Playing video games", Category = "Indoor", EstimatedCost = 500 },
                new Hobby { Id = 2, Name = "Hiking", Description = "Walking in nature", Category = "Outdoor", EstimatedCost = 100 }
            );

            modelBuilder.Entity<Pet>().HasData(
                new Pet { PetId = 1, PetName = "Buddy", PetType = "Dog", PetAge = 3, Color = "Golden", StudentId = 1 },
                new Pet { PetId = 2, PetName = "Whiskers", PetType = "Cat", PetAge = 2, Color = "Black", StudentId = 2 }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseName = "Web Development", Credits = 3, Semester = "Fall 2024", Instructor = "Prof. Smith", StudentId = 1 },
                new Course { CourseId = 2, CourseName = "Database Design", Credits = 4, Semester = "Spring 2025", Instructor = "Prof. Jones", StudentId = 2 }
            );
        }
    }
}

