using CourseRegistrationSystem.Data;
using CourseRegistrationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Courses.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Courses.Add(course);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while creating the course.");
            }

            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Courses.Update(course);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the course.");
            }

            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var course = _context.Courses.Find(id);
                if (course == null)
                {
                    ModelState.AddModelError("", "Course not found.");
                    return NotFound();
                }

                _context.Courses.Remove(course);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the course.");
                return View();
            }
        }
    }
}
