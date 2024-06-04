using Microsoft.AspNetCore.Mvc;


using System.Collections.Generic;
using bai19.Models;

namespace bai19.Controllers
{
    public class StudentsController : Controller
    {
     
        private static List<Student> students = new List<Student>();

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                students.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    
}
}
