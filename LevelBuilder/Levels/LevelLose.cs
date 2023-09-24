using CyberHW_Pacmen.LevelBuilder;
using System.Collections.Generic;

namespace CyberHW_Pacmen.LevelBuilder.Levels
{
    class LevelLose : LevelModel
    {
        public LevelLose()
            : base(14, 14, 1, 1, 12, 1, true)
        {

            var builder = new LevelBuilder(this);

            builder.BuildBounds();

            builder.BuildHorizontallyLine(8, 5, 8);

            LevelBorders.Add(new KeyValuePair<int, int>(1, 2));
            LevelBorders.Add(new KeyValuePair<int, int>(12, 2));
            LevelBorders.Add(new KeyValuePair<int, int>(3, 10));
            LevelBorders.Add(new KeyValuePair<int, int>(4, 9));
            LevelBorders.Add(new KeyValuePair<int, int>(9, 9));
            LevelBorders.Add(new KeyValuePair<int, int>(10, 10));

            builder.BuildVerticalLine(2, 1, 2)
                   .BuildVerticalLine(11, 1, 2)
                   .BuildVerticalLine(4, 3, 6)
                   .BuildVerticalLine(9, 3, 6);
        }
    }
}
