using Microsoft.AspNetCore.Mvc;
using Student_Portal.Data;
using Student_Portal.Models;
using System.Linq;

namespace Student_Portal.Controllers
{
    public class CoursesController : Controller
    {
        private readonly DataContext _context;

        public CoursesController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var course = _context.Courses.Where(s => s.Id == id).FirstOrDefault();
            return View(course);
        }
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Where(s => s.Id == id).FirstOrDefault();
            return View(course);
        }
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Where(s => s.Id == id).FirstOrDefault();
            return View(course);
        }
        [HttpPost]
        public IActionResult Create(Course model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Course model)
        {
            _context.Courses.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Course model)
        {
            _context.Courses.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
