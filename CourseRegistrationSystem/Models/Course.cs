using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public required string CourseName { get; set; }

        [Required]
        public required string Description { get; set; }

        [Range(1, 10, ErrorMessage = "Credits must be between 1 and 10.")]
        public int Credits { get; set; }
    }
}
