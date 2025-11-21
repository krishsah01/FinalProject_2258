namespace FinalProject_2258.Models
{
    public class TeamMember
    {
        public int TeamMemberId { get; set; }   // Primary Key

        public string FullName { get; set; }    // Required
        public DateTime BirthDate { get; set; } // Required
        public string Program { get; set; }     // Example: "Information Technology"
        public string Year { get; set; }
    }
}
    
