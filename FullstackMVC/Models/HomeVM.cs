using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Models
{
    public class HomeVM
    {


        public IEnumerable<MonsterModel> Monsters { get; set; }
        public IEnumerable<MonsterTypeModel> MonsterTypes { get; set; }
        public IEnumerable<MapModel> Map{ get; set; }
    }
}
