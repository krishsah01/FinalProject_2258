using System.ComponentModel.DataAnnotations;

namespace FinalProject_2258.Data
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        [MaxLength(100)]
        public string CollegeProgram { get; set; } = string.Empty;

        [MaxLength(50)]
        public string YearInProgram { get; set; } = string.Empty;
        
        [MaxLength(100)]
        public string? Role { get; set; }
    }
}
