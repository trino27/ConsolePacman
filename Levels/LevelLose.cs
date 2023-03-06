using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class LevelLose : LevelCreator
    {
        public LevelLose() 
            : base(13, 13, 1, 1, 12, 1, true)
        {
            BoundsBuilder();
        }
    }
}
