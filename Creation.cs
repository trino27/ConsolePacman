using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    public abstract class Creation
    {
        public int position_x;
        public int position_y;
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

        public Creation(int pos_x, int pos_y)
        {
            position_x = pos_x;
            position_y = pos_y;
            lastMove = new KeyValuePair<int, int>(position_x, position_y);
        }

        public void Move(KeyValuePair<int, int> new_pos)
        {
            lastMove = new KeyValuePair<int, int>(position_x, position_y);
            position_x = new_pos.Key;
            position_y = new_pos.Value;
        }
    }
}
