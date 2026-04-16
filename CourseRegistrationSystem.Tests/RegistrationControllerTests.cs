using CourseRegistrationSystem.Controllers;
using CourseRegistrationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CourseRegistrationSystem.Tests
{
    public class RegistrationControllerTests
    {
        [Fact]
        public void Register_ValidRegistration_RedirectsToMyCourses()
        {
            // Arrange
            var context = TestHelper.GetDbContext();

            // Seed student + course
            var student = new Student { FirstName = "A", LastName = "B", Email = "a@b.com" };
            var course = new Course { CourseName = "Math", Description = "Basic", Credits = 3 };

            context.Students.Add(student);
            context.Courses.Add(course);
            context.SaveChanges();

            var controller = new RegistrationController(context);

            var reg = new Registration
            {
                StudentId = student.Id,
                CourseId = course.Id
            };

            // Act
            var result = controller.Register(reg) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("MyCourses", result.ActionName);
            Assert.Single(context.Registrations);
        }
    }
}
