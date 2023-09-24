using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class Enemy : Creation
    {
        public enum Vector
        {
            Up,
            Down,
            Left,
            Right
        }

        public Vector LastVector;

        public Enemy(int posX, int posY)
             : base(posX, posY)
        {
            speed = 350;
        }

        public Vector ChosingVector()
        {
            Random random = new Random();
            int way = random.Next(4);
            return (Vector)way;
        }

        public KeyValuePair<int, int> ProcessingWay(Vector way)
        {
            
            switch (way)
            {
                case Vector.Up:
                    {
                        return new KeyValuePair<int, int>(PositionX, PositionY - 1);
                    }
                    break;
                case Vector.Down:
                    {
                        return new KeyValuePair<int, int>(PositionX, PositionY + 1);
                    }
                    break;
                case Vector.Right:
                    {
                        return new KeyValuePair<int, int>(PositionX + 1, PositionY);
                    }
                    break;
                case Vector.Left:
                    {
                        return new KeyValuePair<int, int>(PositionX - 1, PositionY);
                    }
                    break;
                default:
                    {
                        return new KeyValuePair<int, int>(PositionX, PositionY);
                    }
                    break;
            }
        }
    }
}
