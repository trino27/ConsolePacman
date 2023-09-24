using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen.LevelBuilder
{
    public interface ILevelBuilder
    {
        public LevelBuilder BuildTimeLimitSec(UInt32 sec);
        public LevelBuilder BuildVerticalLine(int x, int startY, int endY);
        public LevelBuilder BuildHorizontallyLine(int y, int startX, int endX);
        public LevelBuilder BuildBounds();
        public LevelBuilder BuildEnemy(KeyValuePair<int, int> enemyPos);

        public LevelModel GetLevelModel();
    }
}
