using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Engine
{
    public static class LevelUpdater
    {

        public static int CalculateLevel(int experience)
        {

            int level;
            level = experience > LevelSetter.Lv_1_From && experience < LevelSetter.Lv_1_To ? 1 : 1;
            level = experience > LevelSetter.Lv_10_From && experience < LevelSetter.Lv_10_To ? 10 : 10;


            return level;

        }


    }
}
