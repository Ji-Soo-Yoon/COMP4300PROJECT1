using System;
using CourseRegistrationSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Tests
{
    public static class TestHelper
    {
        public static ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
