using FullstackMVC.Data;
using FullstackMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Engine
{
    public class BattleSystem : IBattleSystem
    {
        private ApplicationUserModel _user;
        private MonsterModel _monster;
        private List<string> _battleloggerStorage = new List<string>();
        private List<BattleLogger> _battleLoggerList = new List<BattleLogger>();


        public BattleSystem(ApplicationUserModel user, MonsterModel monster)
        {
            _user = user;
            _monster = monster;
        }

        public BattleViewModel Battle()
        {          
            int UserDmg = _user.Character.Strength;
            int MonsterHp = _monster.Hp;
            int UserHp = _user.Character.Health;
            int gold = _monster.GoldenCoins;

            while (MonsterHp >= 0 || UserHp >= 0)
            {
                Random random = new Random();
                var MonsterDmg = random.Next(_monster.DmgMin, _monster.DmgMax);
                _battleloggerStorage.Add($"Monster dealt {MonsterDmg} Dmg.");
                UserHp = UserHp - MonsterDmg;
                _battleloggerStorage.Add($"User HP left: {UserHp}");
                if (UserHp < 0)
                {
                    _battleloggerStorage.Add("Monster Won");
                    gold =  0;
                    break;
                }
                if (MonsterHp > 0)
                {
                    _battleloggerStorage.Add($"{_user.Character.CharacterName} dealt {UserDmg} Dmg.");
                    MonsterHp = MonsterHp - UserDmg;
                    _battleloggerStorage.Add($"Monster HP left: {MonsterHp}");
                    if (MonsterHp < 0)
                    {
                        _battleloggerStorage.Add("User Won");
                        break;
                    }
                }
            }

            foreach (var item in _battleloggerStorage)
            {
                _battleLoggerList.Add(new BattleLogger()
                {
                    Message = item
                });
            }

            return new BattleViewModel()
            {
                CharacterName = _user.Character.CharacterName,
                MonsterName = _monster.Name,
                DropIndex = 3,
                GoldenCoins = gold,
                ImageMonster = "sasa",
                BattleLogger = _battleLoggerList
            };  
        }
    }
}
