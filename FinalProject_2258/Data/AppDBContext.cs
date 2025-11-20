using System.Collections.Generic;

namespace FinalProject_2258.Data
{
    public class AppDBContext : DBContext
    {
        public AppDBContext(DBContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<BreakfastFood> BreakfastFoods { get; set; }
        public DbSet<FavoriteGame> FavoriteGames { get; set; }
    }