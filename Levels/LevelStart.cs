using System.Collections.Generic;

namespace CyberHW_Pacmen
{
    class LevelStart : LevelCreator
    {
        public LevelStart()
            : base(17, 18, 3, 15, 14, 15, false)
        {
            BoundsBuilder();

            AddHorizontallyLine(2, 2, 5);
            AddHorizontallyLine(2, 8, 9);
            AddHorizontallyLine(2, 13, 15);
            AddHorizontallyLine(3, 12, 13);
            AddHorizontallyLine(4, 3, 4);
            AddHorizontallyLine(4, 8, 9);
            AddHorizontallyLine(5, 12, 13);
            AddHorizontallyLine(6, 13, 15);
            AddHorizontallyLine(8, 8, 9);
            AddHorizontallyLine(10, 8, 9);
            AddHorizontallyLine(16, 2, 15);
            AddHorizontallyLine(14, 2, 15);

            borders.Add(new KeyValuePair<int, int>(12, 4));
            borders.Add(new KeyValuePair<int, int>(2, 15));
            borders.Add(new KeyValuePair<int, int>(15, 15));
            borders.Add(new KeyValuePair<int, int>(13, 9));
            borders.Add(new KeyValuePair<int, int>(14, 10));

            AddVerticalLine(2, 2, 6);
            AddVerticalLine(5, 3, 4);
            AddVerticalLine(7, 3, 6);
            AddVerticalLine(2, 8, 12);
            AddVerticalLine(3, 9, 10);
            AddVerticalLine(4, 9, 10);
            AddVerticalLine(5, 8, 12);
            AddVerticalLine(7, 9, 12);
            AddVerticalLine(10, 9, 12);
            AddVerticalLine(12, 8, 12);
            AddVerticalLine(15, 8, 12);
            AddVerticalLine(10, 3, 6);

        }
    }
}
