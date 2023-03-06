using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    abstract class LevelCreator
    {
        public readonly int area_size_x;
        public readonly int area_size_y;

        public readonly int user_pos_x;
        public readonly int user_pos_y;

        public readonly int finish_pos_x;
        public readonly int finish_pos_y;

        protected List<KeyValuePair<int,int>> enemies_pos = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> GetEnemiesPos { get { return enemies_pos; } }

        protected List<KeyValuePair<int, int>> borders = new List<KeyValuePair<int, int>>(); 
        public List<KeyValuePair<int, int>> GetLevelBorders { get { return borders; } }

        protected LevelCreator(int area_size_X, int area_size_Y, int user_start_pos_X, int user_start_pos_Y, int finish_pos_X, int finish_pos_Y)
        {
            if((area_size_X <= 0 || area_size_Y <= 0)
                || (user_start_pos_X <= 0 || user_start_pos_X >= area_size_X)
                || (user_start_pos_Y <= 0 || user_start_pos_Y >= area_size_Y)
                || (finish_pos_X <= 0 || finish_pos_X >= area_size_X)
                || (finish_pos_Y <= 0 || finish_pos_Y >= area_size_Y))
            {
                throw new Exception("Bad value");
            }
            area_size_x = area_size_X+1;
            area_size_y = area_size_Y+1;

            user_pos_x = user_start_pos_X;
            user_pos_y = user_start_pos_Y;

            finish_pos_x = finish_pos_X;
            finish_pos_y = finish_pos_Y;
        }

        protected void AddVerticalLine(int x, int start_y, int end_y)
        {
            if (x <= 0 || start_y <= 0 || end_y <= 0 || x >= area_size_x || start_y >= area_size_y || end_y >= area_size_y || start_y > end_y)
            {
                throw new Exception("Bad value");
            }
            for (int y = start_y; y <= end_y; y++)
            {
                borders.Add(new KeyValuePair<int, int>(x, y));
            }
        }

        protected void AddHorizontallyLine(int y, int start_x, int end_x)
        {
            if (y <= 0 || start_x <= 0 || end_x <= 0 || y >= area_size_y || start_x >= area_size_x || end_x >= area_size_x || start_x > end_x)
            {
                throw new Exception("Bad value");
            }
            for (int x = start_x; x <= end_x; x++)
            {
                borders.Add(new KeyValuePair<int, int>(x, y));
            }
        }

        protected void BoundsBuilder()
        {
            for (int x = 0; x < area_size_x; x++)
            {
                for (int y = 0; y < area_size_y; y++)
                {
                    if (x == 0 || y == 0 || x == area_size_x-1 || y == area_size_y-1)
                    {
                        borders.Add(new KeyValuePair<int, int>(x,y));
                    }
                }
            }
        }
    }
}
