using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class Level3 : LevelCreator
    {
        public Level3()
            : base(18, 18, 9, 9, 1, 1, false) // Розмір карти та стартові координати гравця
        {
            BoundsBuilder();
            AddTimeLimitSec(120);

            enemies_pos.Add(new KeyValuePair<int, int>(7, 1));
            enemies_pos.Add(new KeyValuePair<int, int>(15, 1));
            enemies_pos.Add(new KeyValuePair<int, int>(1, 9));
            enemies_pos.Add(new KeyValuePair<int, int>(6, 9));
            enemies_pos.Add(new KeyValuePair<int, int>(9, 13));
            enemies_pos.Add(new KeyValuePair<int, int>(12, 17));
            enemies_pos.Add(new KeyValuePair<int, int>(17, 10));

            AddHorizontallyLine(1, 16, 17);
            AddHorizontallyLine(2, 4, 6);
            AddHorizontallyLine(4, 1, 3);
            AddHorizontallyLine(4, 10, 13);
            AddHorizontallyLine(6, 2, 4);
            AddHorizontallyLine(6, 8, 12);
            AddHorizontallyLine(8, 4, 6);
            AddHorizontallyLine(9, 16, 17);
            AddHorizontallyLine(10, 7, 10);
            AddHorizontallyLine(12, 1, 2);
            AddHorizontallyLine(12, 8, 10);
            AddHorizontallyLine(13, 11, 12);
            AddHorizontallyLine(14, 3, 5);
            AddHorizontallyLine(14, 9, 11);
            AddHorizontallyLine(14, 14, 15);
            AddHorizontallyLine(16, 2, 4);
            AddHorizontallyLine(16, 7, 9);

            borders.Add(new KeyValuePair<int, int>(1, 8));
            borders.Add(new KeyValuePair<int, int>(7, 14));
            borders.Add(new KeyValuePair<int, int>(13, 12));
            borders.Add(new KeyValuePair<int, int>(11, 12));

            AddVerticalLine(1, 14, 16);
            AddVerticalLine(2, 1, 2);
            AddVerticalLine(2, 8, 10);
            AddVerticalLine(4, 10, 12);
            AddVerticalLine(5, 4, 6);
            AddVerticalLine(6, 10, 16);
            AddVerticalLine(7, 2, 8);
            AddVerticalLine(8, 8, 9);
            AddVerticalLine(9, 2, 5);
            AddVerticalLine(10, 8, 9);
            AddVerticalLine(11, 1, 2);
            AddVerticalLine(11, 16, 17);
            AddVerticalLine(12, 7, 9);
            AddVerticalLine(12, 11, 14);
            AddVerticalLine(13, 1, 2);
            AddVerticalLine(13, 16, 17);
            AddVerticalLine(14, 1, 2);
            AddVerticalLine(14, 4, 5);
            AddVerticalLine(14, 7, 9);
            AddVerticalLine(14, 11, 12);
            AddVerticalLine(15, 15, 16);
            AddVerticalLine(16, 3, 7);
            AddVerticalLine(16, 11, 14);
            AddVerticalLine(17, 16, 17);
        }

    }
}
