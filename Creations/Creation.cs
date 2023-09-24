using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    public abstract class Creation
    {
        public int PositionX;
        public int PositionY;
        protected int speed;
        protected KeyValuePair<int, int> lastMove;
        public KeyValuePair<int, int> GetLastMove
        {
            get { return lastMove; }
        }
        public int GetSpeed
        {
            get { return speed; }
        }

        public Creation(int posX, int posY)
        {
            PositionX = posX;
            PositionY = posY;
            lastMove = new KeyValuePair<int, int>(PositionX, PositionY);
        }

        public void Move(KeyValuePair<int, int> newPos)
        {
            lastMove = new KeyValuePair<int, int>(PositionX, PositionY);
            PositionX = newPos.Key;
            PositionY = newPos.Value;
        }
    }
}
