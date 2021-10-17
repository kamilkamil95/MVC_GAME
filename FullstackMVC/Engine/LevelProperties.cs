using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackMVC.Engine
{
    public static class LevelProperties
    {

        public static int CalculateLevel(int experience)
        {

            if (experience > LevelSetter.Lv_1_From && experience < LevelSetter.Lv_1_To)
            {
                return 1;
            }

            else if (experience > LevelSetter.Lv_2_From && experience < LevelSetter.Lv_2_To)
            {
                return 2;
            }
            else if (experience > LevelSetter.Lv_3_From && experience < LevelSetter.Lv_3_To)
            {
                return 3;
            }
            else if (experience > LevelSetter.Lv_4_From && experience < LevelSetter.Lv_4_To)
            {
                return 4;
            }
            else if (experience > LevelSetter.Lv_5_From && experience < LevelSetter.Lv_5_To)
            {
                return 5;
            }
            else if (experience > LevelSetter.Lv_6_From && experience < LevelSetter.Lv_6_To)
            {
                return 6;
            }
            else if (experience > LevelSetter.Lv_7_From && experience < LevelSetter.Lv_7_To)
            {
                return 7;
            }
            else if (experience > LevelSetter.Lv_8_From && experience < LevelSetter.Lv_8_To)
            {
                return 8;
            }

            else if (experience > LevelSetter.Lv_9_From && experience < LevelSetter.Lv_9_To)
            {
                return 9;
            }

            else
            {
                return 00;
            }
        }





        public static int CalculateExpNeededToLevelUp(int experience)
        {

            if (experience > LevelSetter.Lv_1_From && experience < LevelSetter.Lv_1_To)
            {
                return LevelSetter.Lv_1_To;
            }

            else if (experience > LevelSetter.Lv_2_From && experience < LevelSetter.Lv_2_To)
            {
                return LevelSetter.Lv_2_To;
            }
            else if (experience > LevelSetter.Lv_3_From && experience < LevelSetter.Lv_3_To)
            {
               return LevelSetter.Lv_3_To;
            }
            else if (experience > LevelSetter.Lv_4_From && experience < LevelSetter.Lv_4_To)
            {
                return LevelSetter.Lv_4_To;
            }
            else if (experience > LevelSetter.Lv_5_From && experience < LevelSetter.Lv_5_To)
            {
                return LevelSetter.Lv_5_To;
            }
            else if (experience > LevelSetter.Lv_6_From && experience < LevelSetter.Lv_6_To)
            {
                return LevelSetter.Lv_6_To;
            }
            else if (experience > LevelSetter.Lv_7_From && experience < LevelSetter.Lv_7_To)
            {
                return LevelSetter.Lv_7_To;
            }
            else if (experience > LevelSetter.Lv_8_From && experience < LevelSetter.Lv_8_To)
            {
                return LevelSetter.Lv_8_To;
            }

            else if (experience > LevelSetter.Lv_9_From && experience < LevelSetter.Lv_9_To)
            {
                return LevelSetter.Lv_9_To;
            }

            else if (experience > LevelSetter.Lv_10_From && experience < LevelSetter.Lv_10_To)
            {
                return LevelSetter.Lv_10_To;
            }

            else
            {
                return 00;
            }
        }




    }
}
