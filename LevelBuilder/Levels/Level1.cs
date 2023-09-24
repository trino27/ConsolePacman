using CyberHW_Pacmen.LevelBuilder;
using System.Collections.Generic;

namespace CyberHW_Pacmen.LevelBuilder.Levels
{
    class Level1 : LevelModel
    {
        public Level1()
            : base(16, 16, 3, 12, 14, 1, false) // Розмір карти, стартові координати гравця та координати фінішу 
        {
            var builder = new LevelBuilder(this);

            builder.BuildBounds();

            builder.BuildHorizontallyLine(2, 2, 3)
                   .BuildHorizontallyLine(5, 7, 10)
                   .BuildHorizontallyLine(5, 13,14)
                   .BuildHorizontallyLine(7, 3, 6)
                   .BuildHorizontallyLine(7, 11, 13)
                   .BuildHorizontallyLine(9, 2, 4)
                   .BuildHorizontallyLine(9, 8, 11)
                   .BuildHorizontallyLine(11, 2, 4)
                   .BuildHorizontallyLine(11, 10, 13)
                   .BuildHorizontallyLine(13, 10, 13);

            builder.BuildVerticalLine(1, 4, 7)
                   .BuildVerticalLine(2, 12, 13)
                   .BuildVerticalLine(3, 3, 5)
                   .BuildVerticalLine(4, 12, 14)
                   .BuildVerticalLine(5, 2, 5)
                   .BuildVerticalLine(6, 9, 13)
                   .BuildVerticalLine(7, 2, 4)
                   .BuildVerticalLine(8, 11, 14)
                   .BuildVerticalLine(9, 1, 3)
                   .BuildVerticalLine(11, 2, 6);

            builder.BuildTimeLimitSec(45);

            builder.BuildEnemy(new KeyValuePair<int, int>(8, 7))
                   .BuildEnemy(new KeyValuePair<int, int>(9, 7))
                   .BuildEnemy(new KeyValuePair<int, int>(1, 1))
                   .BuildEnemy(new KeyValuePair<int, int>(14, 14))
                   .BuildEnemy(new KeyValuePair<int, int>(12, 1));
        }
    }
}
