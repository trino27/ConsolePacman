using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class User : Creation
    {

        public User(int pos_x, int pos_y)
             : base(pos_x, pos_y) 
        {
            speed = 300;
        }
        public void Move(KeyValuePair<int,int> new_pos)
        {
            lastMove = new KeyValuePair<int, int>(position_x, position_y);
            position_x = new_pos.Key;
            position_y = new_pos.Value;
        }
        public KeyValuePair<int, int> InputMoveKey(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.W:
                    { 
                        return new KeyValuePair<int, int>(position_x, position_y - 1);
                    } break;
                case ConsoleKey.S: 
                    { 
                        return new KeyValuePair<int, int>(position_x, position_y + 1);
                    } break;
                case ConsoleKey.D: 
                    { 
                        return new KeyValuePair<int, int>(position_x + 1, position_y);
                    } break;
                case ConsoleKey.A: 
                    { 
                        return new KeyValuePair<int, int>(position_x - 1, position_y);
                    } break;
                default: 
                    { 
                        return new KeyValuePair<int, int>(position_x, position_y); 
                    } break;
            }
        }
    }
}
