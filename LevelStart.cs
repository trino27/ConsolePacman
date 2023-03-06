using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class LevelStart : LevelCreator
    {
        public LevelStart() 
            : base(18, 17, 3, 15, 14, 15, false)
        {
            BoundsBuilder();
        }
    }
}
