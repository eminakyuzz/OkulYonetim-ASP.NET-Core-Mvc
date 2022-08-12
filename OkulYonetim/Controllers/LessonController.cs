using Microsoft.AspNetCore.Mvc;
using OkulYonetim.Data;
using OkulYonetim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkulYonetim.Controllers
{
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LessonController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Lesson> lessons = _db.Lessons;

            return View(lessons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _db.Lessons.Add(lesson);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lesson);
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var lesson = _db.Lessons.Find(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }


        //POST-Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Lesson  lesson)
        {
            if (ModelState.IsValid)
            {
                _db.Lessons.Update(lesson);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lesson);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Lesson lesson = await _db.Lessons.FindAsync(id);
            _db.Remove(lesson);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
