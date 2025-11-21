namespace FinalProject_2258.Models
{
    public class Pet
    {
        public int PetId { get; set; }          // Primary Key

        public string PetName { get; set; }
        public string PetType { get; set; }     // e.g., "Dog", "Cat"

        public int StudentId { get; set; }      // Optional relationship
        public int PetAge { get; set; }

        public string Color { get; set; }       // Extra column
    }
}
