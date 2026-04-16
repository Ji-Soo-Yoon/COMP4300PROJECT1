using CourseRegistrationSystem.Data;
using CourseRegistrationSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistrationSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while creating the student.");
            }

            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Students.Update(student);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the student.");
            }

            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null)
                {
                    return NotFound();
                }

                _context.Students.Remove(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while deleting the student.");
                return View();
            }
        }
    }
}
