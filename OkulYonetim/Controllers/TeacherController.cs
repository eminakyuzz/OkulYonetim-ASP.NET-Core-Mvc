using Microsoft.AspNetCore.Mvc;
using OkulYonetim.Data;
using OkulYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulYonetim.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Teacher> teacherList = _db.Teachers;
            return View(teacherList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Add(teacher);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public IActionResult Update(int? id)
        {
            if (id==null||id==0)
            {
                return NotFound();
            }
            var teacher = _db.Teachers.Find(id);
            if (teacher==null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _db.Teachers.Update(teacher);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Teacher teacher = await _db.Teachers.FindAsync(id);
            _db.Remove(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
