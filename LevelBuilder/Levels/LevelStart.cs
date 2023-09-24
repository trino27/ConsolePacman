using CyberHW_Pacmen.LevelBuilder;
using System.Collections.Generic;

namespace CyberHW_Pacmen.LevelBuilder.Levels
{
    class LevelStart : LevelModel
    {
        public LevelStart()
            : base(18, 19, 3, 15, 14, 15, false)
        {
            var builder = new LevelBuilder(this);

            builder.BuildBounds();

            builder.BuildHorizontallyLine(2, 2, 5)
                   .BuildHorizontallyLine(2, 8, 9)
                   .BuildHorizontallyLine(2, 13, 15)
                   .BuildHorizontallyLine(3, 12, 13)
                   .BuildHorizontallyLine(4, 3, 4)
                   .BuildHorizontallyLine(4, 8, 9)
                   .BuildHorizontallyLine(5, 12, 13)
                   .BuildHorizontallyLine(6, 13, 15)
                   .BuildHorizontallyLine(8, 8, 9)
                   .BuildHorizontallyLine(10, 8, 9)
                   .BuildHorizontallyLine(16, 2, 15)
                   .BuildHorizontallyLine(14, 2, 15);

            builder.BuildVerticalLine(2, 2, 6)
                   .BuildVerticalLine(5, 3, 4)
                   .BuildVerticalLine(7, 3, 6)
                   .BuildVerticalLine(2, 8, 12)
                   .BuildVerticalLine(3, 9, 10)
                   .BuildVerticalLine(4, 9, 10)
                   .BuildVerticalLine(5, 8, 12)
                   .BuildVerticalLine(7, 9, 12)
                   .BuildVerticalLine(10, 9, 12)
                   .BuildVerticalLine(12, 8, 12)
                   .BuildVerticalLine(15, 8, 12)
                   .BuildVerticalLine(10, 3, 6);

            LevelBorders.Add(new KeyValuePair<int, int>(12, 4));
            LevelBorders.Add(new KeyValuePair<int, int>(2, 15));
            LevelBorders.Add(new KeyValuePair<int, int>(15, 15));
            LevelBorders.Add(new KeyValuePair<int, int>(13, 9));
            LevelBorders.Add(new KeyValuePair<int, int>(14, 10));
        }
    }
}
