using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class Enemy : Creation
    {
        public Enemy(int pos_x, int pos_y)
             : base(pos_x, pos_y)
        {
            speed = 500;
        }

    }
}
