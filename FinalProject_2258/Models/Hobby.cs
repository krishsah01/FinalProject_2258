using System.ComponentModel.DataAnnotations;

namespace FinalProject_2258.Data
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }

        public decimal EstimatedCost { get; set; }
    }
}
