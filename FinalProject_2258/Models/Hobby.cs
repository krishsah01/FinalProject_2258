namespace FinalProject_2258.Models
{
    public class Hobby
    {
        public int HobbyId { get; set; }        // Primary Key

        public string HobbyName { get; set; }   // "Playing Basketball"
        public string Type { get; set; }        // "Physical", "Art", "Music"
        public string Description { get; set; } // Extra detail

        public int StudentId { get; set; }      // Reference (not foreign key required)
        public int HoursPerWeek { get; set; }   // Extra column to reach 5+
    }
}
