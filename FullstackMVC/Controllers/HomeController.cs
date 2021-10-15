using FullstackMVC.Data;
using FullstackMVC.Engine;
using FullstackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            

        }

        public IActionResult Index()
        {
          

            HomeVM homeVM = new HomeVM()
            {
                Monsters = _db.MonsterModel.Include(x => x.MapModel).Include(y => y.MonsterTypeModel),
                MonsterTypes = _db.MonsterType,
                Map = _db.MapModel
                
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Attack(int? id)
        {    
          var currentUser = _db.ApplicationUserModel.FirstOrDefault(x => x.UserName == User.Identity.Name);
          currentUser.Character = _db.CharacterModel.FirstOrDefault(x => x.Id == currentUser.CharacterId);
          var monster = _db.MonsterModel.FirstOrDefault(x => x.Id == id);
          monster.MapModel = _db.MapModel.FirstOrDefault(x => x.Id == monster.MapModelId);
          monster.MonsterTypeModel = _db.MonsterType.FirstOrDefault(x => x.Id == monster.MonsterModelId);

          BattleSystem battle = new BattleSystem(currentUser, monster);
          BattleViewModel BattleViewModel = battle.Battle();

            currentUser.Character.GoldenCoins =  currentUser.Character.GoldenCoins + BattleViewModel.GoldenCoins;
            currentUser.Character.Experience = currentUser.Character.Experience + BattleViewModel.ExperienceMonster;
          //  int currentExperience = LevelUpdater.CalculateLevel(currentUser.Character.Experience);
          //  currentUser.Character.Level = currentExperience;

            _db.Update(
                currentUser.Character                
                );

            _db.SaveChanges();

            return View(BattleViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
