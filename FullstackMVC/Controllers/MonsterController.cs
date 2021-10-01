using FullstackMVC.Data;
using FullstackMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Controllers
{
    public class MonsterController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MonsterController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<MonsterModel> MonsterList = _db.MonsterModel;

            foreach (var item in MonsterList)
            {
                item.MonsterTypeModel = _db.MonsterType.FirstOrDefault(u => u.Id == item.MonsterTypeModel.Id);
                item.MapModel = _db.MapModel.FirstOrDefault(u => u.Id == item.MapModel.Id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MonsterVM monsterVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webPath = _webHostEnvironment.WebRootPath;

                if(monsterVM.Monster.Id == 0)
                {
                    string upload = webPath + Consts.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);
                    using(var fileStream = new FileStream(Path.Combine(upload,fileName+extension),FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    monsterVM.Monster.Image = fileName + extension;
                    _db.MonsterModel.Add(monsterVM.Monster);
                }

                else
                {
                    var dbObject = _db.MonsterModel.AsNoTracking().FirstOrDefault(x => x.Id == monsterVM.Monster.Id);

                    if(files.Count > 0)
                    {
                        string upload = webPath + Consts.ImagePath;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);
                        var oldImg = Path.Combine(upload, dbObject.Image);

                        if (System.IO.File.Exists(oldImg))
                        {
                            System.IO.File.Delete(oldImg);
                        }
                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }
                        monsterVM.Monster.Image = fileName + extension;
                    }

                    else
                    {
                        monsterVM.Monster.Image = dbObject.Image;
                    }
                    _db.MonsterModel.Update(monsterVM.Monster);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monsterVM);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.MonsterModel.Find(id);
            MonsterVM monsterVM = new MonsterVM()
            {
                Monster = new MonsterModel()
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    Hp = obj.Hp,
                    Message = obj.Message,
                    DmgMax = obj.DmgMax,
                    DmgMin = obj.DmgMin,
                    Image = obj.Image,
                    MonsterModelId = obj.MonsterModelId
                },
                MonsterTypeSelectList = _db.MonsterType.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };
            if (obj == null)
            {
                return NotFound();
            }
            return View(monsterVM);
        }

        //post delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost (int? id)
        {
            var files = HttpContext.Request.Form.Files;
            string webPath = _webHostEnvironment.WebRootPath;
            var dbObject = _db.MonsterModel.AsNoTracking().FirstOrDefault(x => x.Id == id);
            var obj = _db.MonsterModel.Find(id);
            string upload = webPath + Consts.ImagePath;
            string fileName = Guid.NewGuid().ToString();
            var oldImg = Path.Combine(upload, dbObject.Image);

            if (System.IO.File.Exists(oldImg))
            {
                System.IO.File.Delete(oldImg);
            }

            if (obj==null)
            {
                return NotFound();
            }
                _db.MonsterModel.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");     
        }

    }
}
