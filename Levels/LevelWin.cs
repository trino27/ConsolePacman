using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class LevelWin : LevelCreator
    {
        public LevelWin()
            : base(17, 11, 1, 10, 16, 10, true)
        {
            BoundsBuilder();

            AddVerticalLine(2, 2, 6);
            AddVerticalLine(4, 3, 6);
            AddVerticalLine(6, 2, 6);
            AddVerticalLine(9, 4, 6);
            AddVerticalLine(12, 2, 6);
            AddVerticalLine(15, 2, 6);

            borders.Add(new KeyValuePair<int, int>(3, 6));
            borders.Add(new KeyValuePair<int, int>(5, 6));
            borders.Add(new KeyValuePair<int, int>(9, 2));
            borders.Add(new KeyValuePair<int, int>(13, 3));
            borders.Add(new KeyValuePair<int, int>(14, 4));
            borders.Add(new KeyValuePair<int, int>(16, 10));

            AddHorizontallyLine(9, 15, 16);
        }
    }
}
