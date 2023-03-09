using System.Collections.Generic;

namespace CyberHW_Pacmen
{
    class Level2 : LevelCreator
    {
        public Level2()
            : base(15, 15, 1, 1, 14, 14, false) // Розмір карти та стартові координати гравця
        {
            BoundsBuilder();
            AddTimeLimitSec(100);

            enemies_pos.Add(new KeyValuePair<int, int>(1, 14));
            enemies_pos.Add(new KeyValuePair<int, int>(7, 7));
            enemies_pos.Add(new KeyValuePair<int, int>(14, 1));
            enemies_pos.Add(new KeyValuePair<int, int>(14, 7));
            enemies_pos.Add(new KeyValuePair<int, int>(12, 12));
            enemies_pos.Add(new KeyValuePair<int, int>(12, 10));

            AddVerticalLine(2, 4, 5);
            AddVerticalLine(2,9,11);
            AddVerticalLine(2, 13, 14);
            AddVerticalLine(4, 6, 7);
            AddVerticalLine(4, 9, 13);
            AddVerticalLine(5, 1, 2);
            AddVerticalLine(6, 8, 11);
            AddVerticalLine(7, 2, 4);
            AddVerticalLine(8, 2, 5);
            AddVerticalLine(8, 9, 11);
            AddVerticalLine(10, 4, 5);
            AddVerticalLine(10, 9, 12);
            AddVerticalLine(13, 1, 3);
            AddVerticalLine(13, 13, 14);

            AddHorizontallyLine(2, 1, 3);
            AddHorizontallyLine(2, 10, 12);
            AddHorizontallyLine(4, 3, 5);
            AddHorizontallyLine(5, 12, 14);
            AddHorizontallyLine(6, 5, 6);
            AddHorizontallyLine(7, 1, 3);
            AddHorizontallyLine(7, 8, 14);
            AddHorizontallyLine(9, 12, 14);
            AddHorizontallyLine(11, 11, 13);
            AddHorizontallyLine(13, 6, 10);
        }
    }
}
