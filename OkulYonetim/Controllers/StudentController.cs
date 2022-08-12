using Microsoft.AspNetCore.Mvc;
using OkulYonetim.Data;
using OkulYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulYonetim.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> studentList = _db.Students;

            return View(studentList);
        }

        //HTTP-GET
        public IActionResult Create()
        {
            return View();
        }


        //HTTP-POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //GET-UPDATE
        public IActionResult Update(int? id)
        {
            if (id==null||id==0)
            {
                return NotFound();
            }
            var student = _db.Students.Find(id);
            if (student==null)
            {
                return NotFound();
            }
            return View(student);
        }


        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }


        //GET-Delete
        //public IActionResult  Delete(int? id)
        //{
        //    if (id==null|| id==0)
        //    {
        //        return NotFound();
        //    }
        //    var deletedStudent = _db.Students.Find(id);
        //    if (deletedStudent==null)
        //    {
        //        return NotFound();
        //    }
        //    return View(deletedStudent);
        //}

        public async Task<IActionResult> Delete(int? id)
        {
            Student student = await _db.Students.FindAsync(id);
            _db.Remove(student);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //POST-Delete
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePost(int? id)
        //{
        //    var deletedStudent = _db.Students.Find(id);
        //    if (deletedStudent==null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Students.Remove(deletedStudent);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
