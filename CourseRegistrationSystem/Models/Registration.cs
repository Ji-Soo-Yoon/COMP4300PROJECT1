using System.ComponentModel.DataAnnotations;

namespace CourseRegistrationSystem.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
