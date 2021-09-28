using FullstackMVC.Data;
using FullstackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Controllers
{
    public class MonsterTypeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public MonsterTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MonsterTypeModel> monsterTypesList = _db.MonsterType;

            return View(monsterTypesList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MonsterTypeModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.MonsterType.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Get for edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.MonsterType.Find(id);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MonsterTypeModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.MonsterType.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        //Get for delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.MonsterType.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //post delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
                var obj = _db.MonsterType.Find(id);

           if(obj==null)
            {
                return NotFound();
            }
                _db.MonsterType.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");     
        }

    }
}
