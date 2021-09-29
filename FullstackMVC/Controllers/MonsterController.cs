using FullstackMVC.Data;
using FullstackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Controllers
{
    public class MonsterController : Controller
    {

        private readonly ApplicationDbContext _db;

        public MonsterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {


            IEnumerable<MonsterModel> MonsterList = _db.MonsterModel;

            foreach (var item in MonsterList)
            {
                item.MonsterTypeModel = _db.MonsterType.FirstOrDefault(u => u.Id == item.Id);
            }

            return View(MonsterList);
        }

        //GET - UPSERT
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            MonsterVM monsterVM = new MonsterVM()
            {
                Monster = new MonsterModel(),
                MonsterTypeSelectList = _db.MonsterType.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };


            if(id == null)
            {
                //this is for create
                return View(monsterVM);
            }

            else
            {
                monsterVM.Monster = _db.MonsterModel.Find(id);
                if (monsterVM.Monster == null)
                {
                    return NotFound();
                }
            }

            return View(monsterVM);
        }

        //post upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MonsterModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.MonsterModel.Add(obj);
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
