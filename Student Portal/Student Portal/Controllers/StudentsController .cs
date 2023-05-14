using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_Portal.Data;
using Student_Portal.Models;
using Student_Portal.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DataContext _context;

        public StudentsController(DataContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        public IActionResult Create()
        {
            var courses= _context.Courses.Select(x =>new SelectListItem(){
                Text = x.Title,
                Value = x.Id.ToString()
            }).ToList();
            CreateStudentViewModel vm = new CreateStudentViewModel();
            vm.Courses = courses;
            return View(vm);
        }
        public IActionResult Details(int id)
        {
            var student = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            return View(student);
        }
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Where(s => s.Id == id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(CreateStudentViewModel vm)
        {
            var student = new Student
            {
                Name=vm.Name,
                Enrolled=vm.Enrolled
            };
            var selectedCourses = vm.Courses.Where(x => x.Selected).Select(y => y.Value).ToList();
            foreach(var item in selectedCourses)
            {
                student.Enrollemt.Add(new StudentCourse()
                {
                    CourseId = int.Parse(item)
                });
            }
            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            _context.Students.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Student model)
        {
            _context.Students.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
