using FullstackMVC.Data;
using FullstackMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Controllers
{
    public class CharacterController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CharacterController( ApplicationDbContext db)
        {        
            _db = db;
        }


        public IActionResult Index()
        {
            ApplicationUserModel applicationUserModel = new ApplicationUserModel();

            // IEnumerable<MonsterModel> MonsterList = _db.MonsterModel.Include(x => x.MonsterTypeModel).Include(x => x.MapModel);
            var accountHasCharacterValidation = _db.ApplicationUserModel.FirstOrDefault(x => x.UserName == User.Identity.Name);
            accountHasCharacterValidation.Character = _db.CharacterModel.FirstOrDefault(x => x.Id == accountHasCharacterValidation.CharacterId);

            if (accountHasCharacterValidation.CharacterId == null)
            {
                return View("Create");
            }
            else
            {
                return View(accountHasCharacterValidation);
            }

            
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CharacterModel obj)
        {
            var account = _db.ApplicationUserModel.FirstOrDefault(x => x.UserName == User.Identity.Name);
            obj.AccountNameOwner = User.Identity.Name;

            account.Character = new CharacterModel()
            {
                Id = obj.Id,
                CharacterName = obj.CharacterName,
                Health = obj.Health,
                Dmg = obj.Dmg,
                Job = obj.Job
            };

            _db.Update(account);

            _db.SaveChanges();

            return RedirectToAction("Index");
      
        }


    }
}
