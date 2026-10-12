using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _db;
        public StudentsController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index(string? search, string? course)
        {
            var query = _db.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(s => s.FullName.Contains(search) || s.Email.Contains(search));
            if (!string.IsNullOrWhiteSpace(course))
                query = query.Where(s => s.Course == course);

            ViewBag.Search = search;
            ViewBag.Course = course;
            ViewBag.Courses = await _db.Students.Select(s => s.Course).Distinct().OrderBy(c => c).ToListAsync();
            ViewBag.Total = await _db.Students.CountAsync();

            return View(await query.OrderBy(s => s.FullName).ToListAsync());
        }

        public IActionResult Create() => View(new Student());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (await _db.Students.AnyAsync(s => s.Email == student.Email))
                ModelState.AddModelError("Email", "A student with this email already exists.");

            if (!ModelState.IsValid) return View(student);

            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Student added successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id) return NotFound();

            if (await _db.Students.AnyAsync(s => s.Email == student.Email && s.Id != id))
                ModelState.AddModelError("Email", "A student with this email already exists.");

            if (!ModelState.IsValid) return View(student);

            _db.Update(student);
            await _db.SaveChangesAsync();
            TempData["Message"] = "Student updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Student deleted.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
