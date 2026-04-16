using CourseRegistrationSystem.Data;
using CourseRegistrationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View(new Registration { Student = default!, Course = default! });
        }


        [HttpPost]
        public IActionResult Register(Registration registration)
        {
            try
            {
                bool exists = _context.Registrations
                    .Any(r => r.StudentId == registration.StudentId && r.CourseId == registration.CourseId);

                if (exists)
                {
                    ModelState.AddModelError("", "You are already registered for this course.");
                }

                if (ModelState.IsValid)
                {
                    _context.Registrations.Add(registration);
                    _context.SaveChanges();
                    return RedirectToAction("MyCourses", new { studentId = registration.StudentId });
                }
            }
            catch
            {
                ModelState.AddModelError("", "An unexpected error occurred during registration.");
            }

            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View(registration);
        }


        public IActionResult MyCourses(int studentId)
        {
            var registrations = _context.Registrations
                .Include(r => r.Course)
                .Where(r => r.StudentId == studentId)
                .ToList();

            ViewBag.StudentId = studentId;
            return View(registrations);
        }

        public IActionResult Edit(int id)
        {
            var reg = _context.Registrations.Find(id);
            if (reg == null)
            {
                return NotFound();
            }

            ViewBag.Courses = _context.Courses.ToList();
            return View(reg);
        }

        [HttpPost]
        public IActionResult Edit(Registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Registrations.Update(registration);
                    _context.SaveChanges();
                    return RedirectToAction("MyCourses", new { studentId = registration.StudentId });
                }
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the registration.");
            }

            ViewBag.Courses = _context.Courses.ToList();
            return View(registration);
        }

        public IActionResult Cancel(int id)
        {
            var reg = _context.Registrations.Find(id);
            if (reg == null)
            {
                return NotFound();
            }

            return View(reg);
        }

        [HttpPost, ActionName("Cancel")]
        public IActionResult CancelConfirmed(int id)
        {
            try
            {
                var reg = _context.Registrations.Find(id);
                if (reg == null)
                {
                    return NotFound();
                }

                int studentId = reg.StudentId;

                _context.Registrations.Remove(reg);
                _context.SaveChanges();

                return RedirectToAction("MyCourses", new { studentId = studentId });
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while canceling the registration.");
                return View();
            }
        }
    }
}
