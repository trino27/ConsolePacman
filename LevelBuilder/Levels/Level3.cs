using CyberHW_Pacmen.LevelBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen.LevelBuilder.Levels
{
    class Level3 : LevelModel
    {
        public Level3()
            : base(19, 19, 9, 9, 1, 1, false) // Розмір карти та стартові координати гравця
        {
            var builder = new LevelBuilder(this);

            builder.BuildBounds();

            builder.BuildTimeLimitSec(80);

            builder.BuildHorizontallyLine(1, 16, 17)
                   .BuildHorizontallyLine(2, 4, 6)
                   .BuildHorizontallyLine(4, 1, 3)
                   .BuildHorizontallyLine(4, 10, 13)
                   .BuildHorizontallyLine(6, 2, 4)
                   .BuildHorizontallyLine(6, 8, 12)
                   .BuildHorizontallyLine(8, 4, 6)
                   .BuildHorizontallyLine(9, 16, 17)
                   .BuildHorizontallyLine(10, 7, 10)
                   .BuildHorizontallyLine(12, 2, 2)
                   .BuildHorizontallyLine(12, 8, 10)
                   .BuildHorizontallyLine(13, 11, 12)
                   .BuildHorizontallyLine(14, 3, 5)
                   .BuildHorizontallyLine(14, 9, 11)
                   .BuildHorizontallyLine(14, 14, 15)
                   .BuildHorizontallyLine(16, 2, 4)
                   .BuildHorizontallyLine(16, 7, 9);

            builder.BuildVerticalLine(1, 14, 16)
                   .BuildVerticalLine(2, 1, 2)
                   .BuildVerticalLine(2, 8, 10)
                   .BuildVerticalLine(4, 10, 12)
                   .BuildVerticalLine(5, 4, 6)
                   .BuildVerticalLine(6, 10, 16)
                   .BuildVerticalLine(7, 2, 8)
                   .BuildVerticalLine(8, 8, 9)
                   .BuildVerticalLine(9, 2, 5)
                   .BuildVerticalLine(10, 8, 9)
                   .BuildVerticalLine(11, 1, 2)
                   .BuildVerticalLine(11, 16, 17)
                   .BuildVerticalLine(12, 7, 10)
                   .BuildVerticalLine(12, 12, 14)
                   .BuildVerticalLine(13, 1, 2)
                   .BuildVerticalLine(13, 16, 17)
                   .BuildVerticalLine(14, 1, 2)
                   .BuildVerticalLine(14, 4, 5)
                   .BuildVerticalLine(14, 7, 9)
                   .BuildVerticalLine(14, 11, 12)
                   .BuildVerticalLine(15, 15, 16)
                   .BuildVerticalLine(16, 3, 7)
                   .BuildVerticalLine(16, 11, 14)
                   .BuildVerticalLine(17, 16, 17);

            LevelBorders.Add(new KeyValuePair<int, int>(7, 14));
            LevelBorders.Add(new KeyValuePair<int, int>(13, 12));
            LevelBorders.Add(new KeyValuePair<int, int>(11, 12));

            builder.BuildEnemy(new KeyValuePair<int, int>(7, 1))
                   .BuildEnemy(new KeyValuePair<int, int>(15, 1))
                   .BuildEnemy(new KeyValuePair<int, int>(1, 9))
                   .BuildEnemy(new KeyValuePair<int, int>(6, 9))
                   .BuildEnemy(new KeyValuePair<int, int>(9, 13))
                   .BuildEnemy(new KeyValuePair<int, int>(12, 17))
                   .BuildEnemy(new KeyValuePair<int, int>(17, 10))
                   .BuildEnemy(new KeyValuePair<int, int>(1, 5))
                   .BuildEnemy(new KeyValuePair<int, int>(8, 5))
                   .BuildEnemy(new KeyValuePair<int, int>(3, 1));
        }

    }
}
