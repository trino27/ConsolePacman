using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class User : Creation
    {
        public ConsoleKey LastKey;

        public User(int posX, int posY)
             : base(posX, posY) 
        {
            speed = 150;
        }
        public KeyValuePair<int, int> ProcessingKey(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.W:
                    { 
                        return new KeyValuePair<int, int>(PositionX, PositionY - 1);
                    } break;
                case ConsoleKey.S: 
                    { 
                        return new KeyValuePair<int, int>(PositionX, PositionY + 1);
                    } break;
                case ConsoleKey.D: 
                    { 
                        return new KeyValuePair<int, int>(PositionX + 1, PositionY);
                    } break;
                case ConsoleKey.A: 
                    { 
                        return new KeyValuePair<int, int>(PositionX - 1, PositionY);
                    } break;
                default: 
                    { 
                        return new KeyValuePair<int, int>(PositionX, PositionY); 
                    } break;
            }
        }
    }
}
