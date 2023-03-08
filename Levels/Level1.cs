using System.Collections.Generic;

namespace CyberHW_Pacmen
{
    class Level1 : LevelCreator
    {
        public Level1()
            : base(15, 15, 3, 12, 14, 1, false) // Розмір карти, стартові координати гравця та координати фінішу 
        {
            BoundsBuilder();
            AddTimeLimitSec(90);

            enemies_pos.Add(new KeyValuePair<int, int>(8, 7));
            enemies_pos.Add(new KeyValuePair<int, int>(9, 7));
            enemies_pos.Add(new KeyValuePair<int, int>(1,1));
            enemies_pos.Add(new KeyValuePair<int, int>(14, 14));
            enemies_pos.Add(new KeyValuePair<int, int>(12,1));

            AddHorizontallyLine(2, 2, 3);
            AddHorizontallyLine(5, 7, 10);
            AddHorizontallyLine(5, 13,14);
            AddHorizontallyLine(7, 3, 6);
            AddHorizontallyLine(7, 11, 13);
            AddHorizontallyLine(9, 2, 4);
            AddHorizontallyLine(9, 8, 11);
            AddHorizontallyLine(11, 2, 4);
            AddHorizontallyLine(11, 10, 13);
            AddHorizontallyLine(13, 10, 13);

            AddVerticalLine(1, 4, 7);
            AddVerticalLine(2, 12, 13);
            AddVerticalLine(3, 3, 5);
            AddVerticalLine(4, 12, 14);
            AddVerticalLine(5, 2, 5);
            AddVerticalLine(6, 9, 13);
            AddVerticalLine(7, 2, 4);
            AddVerticalLine(8, 11, 14);
            AddVerticalLine(9, 1, 3);
            AddVerticalLine(11, 2, 6);
            AddVerticalLine(13, 1, 3);
            AddVerticalLine(13, 8, 10);
        }
    }
}
