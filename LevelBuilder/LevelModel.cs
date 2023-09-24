using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen.LevelBuilder
{
    public class LevelModel
    {

        private bool isHaveTimeLimit = false;
        public bool IsHaveTimeLimit
        {
            get
            {
                return isHaveTimeLimit;
            }
            set 
            { 
                isHaveTimeLimit = value; 
            }
        }

        private int secLimit = -1;
        public int SecLimit
        {
            get
            {
                return secLimit;
            }
            set
            {
                secLimit = value;
            }
        }

        public readonly int AreaSizeX;
        public readonly int AreaSizeY;

        public readonly int UserStartPosX;
        public readonly int UserStartPosY;

        public readonly int FinishPosX;
        public readonly int FinishPosY;

        public readonly bool IsLastLevel;

        public List<KeyValuePair<int, int>> EnemiesPos = new List<KeyValuePair<int, int>>(10);
        public List<KeyValuePair<int, int>> LevelBorders = new List<KeyValuePair<int, int>>();

        public LevelModel(int areaSizeX, int areaSizeY, int userStartPosX, int userStartPosY,
                                        int finishPosX, int finishPosY, bool isLastLevel)
        {
            AreaSizeX = areaSizeX;
            AreaSizeY = areaSizeY;
            UserStartPosX = userStartPosX;
            UserStartPosY = userStartPosY;
            FinishPosX = finishPosX;
            FinishPosY = finishPosY;
            IsLastLevel = isLastLevel;
        }
    }
}
