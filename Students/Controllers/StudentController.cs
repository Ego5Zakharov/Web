using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Models;
using System.Text.Json;

namespace Students.Controllers
{
    public class StudentController : Controller
    {
        public AppDbContext db { get; set; }

        public StudentController(AppDbContext db)
        {
            this.db = db;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message });
        }
        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message });
        }

       
        public IActionResult GetStudent(int id)
        {
            List<Student> students = new List<Student>();
            students = db.Students.ToList();
            return Ok(students);
        }

    }
}
