using CyberHW_Pacmen.LevelBuilder;
using System.Collections.Generic;

namespace CyberHW_Pacmen.LevelBuilder.Levels
{
    class Level2 : LevelModel
    {
        public Level2()
            : base(16, 16, 1, 1, 14, 14, false) // Розмір карти та стартові координати гравця
        {
            var builder = new LevelBuilder(this);

            builder.BuildBounds();

            builder.BuildHorizontallyLine(2, 1, 3)
                   .BuildHorizontallyLine(2, 10, 12)
                   .BuildHorizontallyLine(4, 3, 5)
                   .BuildHorizontallyLine(5, 12, 14)
                   .BuildHorizontallyLine(6, 5, 6)
                   .BuildHorizontallyLine(7, 1, 3)
                   .BuildHorizontallyLine(7, 8, 14)
                   .BuildHorizontallyLine(9, 12, 14)
                   .BuildHorizontallyLine(11, 11, 13)
                   .BuildHorizontallyLine(13, 6, 10);

            builder.BuildVerticalLine(2, 4, 5)
                   .BuildVerticalLine(2,9,11)
                   .BuildVerticalLine(2, 13, 14)
                   .BuildVerticalLine(4, 6, 7)
                   .BuildVerticalLine(4, 9, 13)
                   .BuildVerticalLine(5, 1, 2)
                   .BuildVerticalLine(6, 8, 11)
                   .BuildVerticalLine(7, 2, 4)
                   .BuildVerticalLine(8, 2, 5)
                   .BuildVerticalLine(8, 9, 11)
                   .BuildVerticalLine(10, 4, 5)
                   .BuildVerticalLine(10, 9, 12)
                   .BuildVerticalLine(13, 1, 3)
                   .BuildVerticalLine(13, 13, 14);

            builder.BuildEnemy(new KeyValuePair<int, int>(1, 14))
                   .BuildEnemy(new KeyValuePair<int, int>(7, 7))
                   .BuildEnemy(new KeyValuePair<int, int>(14, 1))
                   .BuildEnemy(new KeyValuePair<int, int>(12, 12))
                   .BuildEnemy(new KeyValuePair<int, int>(14, 7))
                   .BuildEnemy(new KeyValuePair<int, int>(12, 10));

            builder.BuildTimeLimitSec(100);
        }
    }
}
