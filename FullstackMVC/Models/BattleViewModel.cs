using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Models
{
    public class BattleViewModel
    {
        [Key]
        public int Id { get; set; }
        public string CharacterName { get; set; }
        public string ImageUser { get; set; }
        public string ImageMonster { get; set; }
        public int GoldenCoins { get; set; }
        public int DropIndex { get; set; }
        public string MonsterName { get; set; }
        public string Map { get; set; }
        public string MonsterType { get; set; }
        public int ExperiencePlayer { get; set; }
        public int ExperienceMonster { get; set; }
        public int PlayerLevel { get; set; }

        public int BattleLoggerId { get; set; }
        [ForeignKey("BattleLoggerId")]
        public List<BattleLogger> BattleLogger { get; set; }
        public List<FightStatus> FightStatus { get; set; }

    }

    public class BattleLogger
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public int FightId { get; set; }
     
    }

    public class FightStatus
    {
        [Key]
        public int Id { get; set; }
        public int PlayerHp { get; set; }
        public int MonsterHp { get; set; }
    }
   

}
