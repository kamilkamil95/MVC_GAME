using FullstackMVC.Data;
using FullstackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Controllers
{
    public class MapController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MapController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MapModel> map = _db.MapModel;

            return View(map);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MapModel obj)
        {
            if(ModelState.IsValid)
            {
                _db.MapModel.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }





        //Get for edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.MapModel.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MapModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.MapModel.Update(obj);
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

            var obj = _db.MapModel.Find(id);

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
            var obj = _db.MapModel.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.MapModel.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
