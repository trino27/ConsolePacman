using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen.LevelBuilder
{
    public class LevelBuilder : ILevelBuilder
    {
        private LevelModel level;
        public LevelModel GetLevelModel()
        {
            return level;
        }



        public LevelBuilder(LevelModel level)
        {
            this.level = level;
        }

        public LevelBuilder(int areaSizeX, int areaSizeY, int userStartPosX, int userStartPosY,
                                        int finishPosX, int finishPosY, bool isLastLevel)
        {
            if (!IsInputCorrect(areaSizeX, areaSizeY, userStartPosX, userStartPosY, finishPosX, finishPosY))
            {
                throw new Exception("Bad value!");
            }
            level = new LevelModel(areaSizeX, areaSizeY, userStartPosX, userStartPosY,
                                        finishPosX, finishPosY, isLastLevel);
        }
        

        private bool IsInputCorrect(int areaSizeX, int areaSizeY, int userStartPosX, int userStartPosY,
                                        int finishPosX, int finishPosY)
        {
            if ((areaSizeX <= 0 || areaSizeY <= 0)
                || (userStartPosX <= 0 || userStartPosX >= areaSizeX)
                || (userStartPosY <= 0 || userStartPosY >= areaSizeY)
                || (finishPosX <= 0 || finishPosX >= areaSizeX)
                || (finishPosY <= 0 || finishPosY >= areaSizeY))
            {
                return false;
            }
            return true;
        }

        public LevelBuilder BuildBounds()
        {
            for (int x = 0; x < level.AreaSizeX; x++)
            {
                for (int y = 0; y < level.AreaSizeY; y++)
                {
                    if (x == 0 || y == 0 || x == level.AreaSizeX - 1 || y == level.AreaSizeY - 1)
                    {
                        level.LevelBorders.Add(new KeyValuePair<int, int>(x, y));
                    }
                }
            }
            return this;
        }

        public LevelBuilder BuildHorizontallyLine(int y, int startX, int endX)
        {
            if (y <= 0 || startX <= 0 || endX <= 0 || y >= level.AreaSizeY
                || startX >= level.AreaSizeX || endX >= level.AreaSizeX || startX > endX)
            {
                throw new Exception("Bad value");
            }
            for (int x = startX; x <= endX; x++)
            {
                level.LevelBorders.Add(new KeyValuePair<int, int>(x, y));
            }
            return this;
        }
        public LevelBuilder BuildVerticalLine(int x, int startY, int endY)
        {
            if (x <= 0 || startY <= 0 || endY <= 0 || x >= level.AreaSizeX
                || startY >= level.AreaSizeY || endY >= level.AreaSizeY || startY > endY)
            {
                throw new Exception("Bad value");
            }
            for (int y = startY; y <= endY; y++)
            {
                level.LevelBorders.Add(new KeyValuePair<int, int>(x, y));
            }
            return this;
        }

        public LevelBuilder BuildTimeLimitSec(uint sec)
        {
            level.SecLimit = (int)sec;
            level.IsHaveTimeLimit = true;
            return this;
        }
        public LevelBuilder BuildEnemy(KeyValuePair<int, int> enemyPos)
        {
            level.EnemiesPos.Add(enemyPos);
            return this;
        }
    }
}
