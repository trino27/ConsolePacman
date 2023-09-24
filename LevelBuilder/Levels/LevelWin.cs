using CyberHW_Pacmen.LevelBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen.LevelBuilder.Levels
{
    class LevelWin : LevelModel
    {
        public LevelWin()
            : base(18, 12, 1, 10, 16, 10, true)
        {
            var builder = new LevelBuilder(this);

            builder.BuildBounds();

            LevelBorders.Add(new KeyValuePair<int, int>(3, 6));
            LevelBorders.Add(new KeyValuePair<int, int>(5, 6));
            LevelBorders.Add(new KeyValuePair<int, int>(9, 2));
            LevelBorders.Add(new KeyValuePair<int, int>(13, 3));
            LevelBorders.Add(new KeyValuePair<int, int>(14, 4));
            LevelBorders.Add(new KeyValuePair<int, int>(15, 10));

            builder.BuildHorizontallyLine(9, 15, 16);

            builder.BuildVerticalLine(2, 2, 5)
                   .BuildVerticalLine(4, 3, 5)
                   .BuildVerticalLine(6, 2, 5)
                   .BuildVerticalLine(9, 4, 6)
                   .BuildVerticalLine(12, 2, 6)
                   .BuildVerticalLine(15, 2, 6);
        }
    }
}
