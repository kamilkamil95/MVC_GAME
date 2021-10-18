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
        private List<FightStatus> _fightStatus = new List<FightStatus>();

        public BattleSystem(ApplicationUserModel user, MonsterModel monster)
        {
            _user = user;
            _monster = monster;
        }

        public BattleViewModel Battle()
        {
            int Experience = _monster.Experience;
            int UserDmg = _user.Character.Strength;
            int MonsterHp = _monster.Hp;
            int UserHp = _user.Character.Health;
            int Gold = _monster.GoldenCoins;
             
            while (MonsterHp >= 0 || UserHp >= 0)
            {
                Random random = new Random();
                var MonsterDmg = random.Next(_monster.DmgMin, _monster.DmgMax);
                _battleloggerStorage.Add($"Monster dealt {MonsterDmg} Dmg.");
                UserHp = UserHp - MonsterDmg;
                _fightStatus.Add(new FightStatus() { PlayerHp = UserHp, MonsterHp = MonsterHp });
                _battleloggerStorage.Add($"User HP left: {UserHp}");
                if (UserHp <= 0)
                {
                    _battleloggerStorage.Add("Monster Won");
                    Experience = - _monster.Experience*Consts.DeathPenalty;
                    Gold = -_monster.GoldenCoins* Consts.DeathPenalty;
                    break;
                }
                if (MonsterHp >= 0)
                {
                    _battleloggerStorage.Add($"{_user.Character.CharacterName} dealt {UserDmg} Dmg.");
                    MonsterHp = MonsterHp - UserDmg;
                    _fightStatus.Add(new FightStatus() { PlayerHp = UserHp,MonsterHp = MonsterHp });
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
                GoldenCoins = Gold,
                ImageMonster = _monster.Image,
                Map = _monster.MapModel.Name,
                MonsterType = _monster.MonsterTypeModel.Name,
                ImageUser = $"{_user.Character.Job}.jpg",
                BattleLogger = _battleLoggerList,
                FightStatus = _fightStatus,
                ExperienceMonster = Experience,
            };  
        }
    }
}
