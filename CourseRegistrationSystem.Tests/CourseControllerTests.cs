using CourseRegistrationSystem.Controllers;
using CourseRegistrationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CourseRegistrationSystem.Tests
{
    public class CourseControllerTests
    {
        [Fact]
        public void Create_ValidCourse_RedirectsToIndex()
        {
            // Arrange
            var context = TestHelper.GetDbContext();
            var controller = new CourseController(context);

            var course = new Course
            {
                CourseName = "Math 101",
                Description = "Basic Math",
                Credits = 3
            };

            // Act
            var result = controller.Create(course) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Single(context.Courses);
        }
    }
}
