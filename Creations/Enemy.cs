using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class Enemy : Creation
    {
        public enum Way
        {
            Up,
            Down,
            Left,
            Right
        }
        public Way LastWay;
        public Enemy(int pos_x, int pos_y)
             : base(pos_x, pos_y)
        {
            speed = 300;
        }
        public Way ChosingWay()
        {
            Random random = new Random();
            int way = random.Next(4);
            return (Way)way;
        }
        public KeyValuePair<int, int> ProcessingWay(Way way)
        {
            
            switch (way)
            {
                case Way.Up:
                    {
                        return new KeyValuePair<int, int>(position_x, position_y - 1);
                    }
                    break;
                case Way.Down:
                    {
                        return new KeyValuePair<int, int>(position_x, position_y + 1);
                    }
                    break;
                case Way.Right:
                    {
                        return new KeyValuePair<int, int>(position_x + 1, position_y);
                    }
                    break;
                case Way.Left:
                    {
                        return new KeyValuePair<int, int>(position_x - 1, position_y);
                    }
                    break;
                default:
                    {
                        return new KeyValuePair<int, int>(position_x, position_y);
                    }
                    break;
            }
        }
    }
}
