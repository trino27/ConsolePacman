using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class LevelWin : LevelCreator
    {
        public LevelWin()
            : base(17, 11, 6, 9, 12, 9, true)
        {
            BoundsBuilder();
        }
    }
}
