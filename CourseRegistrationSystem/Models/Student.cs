using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public required string Email { get; set; }
    }
}
