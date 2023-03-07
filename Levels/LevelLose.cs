using System.Collections.Generic;

namespace CyberHW_Pacmen
{
    class LevelLose : LevelCreator
    {
        public LevelLose()
            : base(13, 13, 1, 1, 12, 1, true)
        {
            BoundsBuilder();

            borders.Add(new KeyValuePair<int, int>(1, 2));
            borders.Add(new KeyValuePair<int, int>(12, 2));
            borders.Add(new KeyValuePair<int, int>(3, 10));
            borders.Add(new KeyValuePair<int, int>(4, 9));
            borders.Add(new KeyValuePair<int, int>(9, 9));
            borders.Add(new KeyValuePair<int, int>(10,10));

            AddHorizontallyLine(8, 5, 8);

            AddVerticalLine(2, 1, 2);
            AddVerticalLine(11, 1, 2);
            AddVerticalLine(4, 3, 6);
            AddVerticalLine(9, 3, 6);
        }
    }
}
