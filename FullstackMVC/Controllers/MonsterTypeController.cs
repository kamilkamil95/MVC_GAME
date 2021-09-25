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
            IEnumerable<MonsterType> monsterTypesList = _db.MonsterType;

            return View(monsterTypesList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }
}
