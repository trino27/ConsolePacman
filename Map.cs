using System;
using System.Collections.Generic;
using System.Threading;

namespace CyberHW_Pacmen
{
    class Map
    {
        public char[,] Area;
        public LevelCreator Level;
        public int UserScore;

        private List<KeyValuePair<int, int>> empty_chars;

        private const char emptyChar = ' ';
        private const char borderChar = '#';
        private const char foodChar = '+';
        private const char enemyChar = '@';
        private const char pacmanChar = 'G';
        private const char finishChar = '0';

        public void ShowMap()
        {
            for (int y = 0; y < Level.area_size_y; y++)
            {
                for (int x = 0; x < Level.area_size_x * 2; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x % 2 == 0)
                    {
                        if (borderChar == Area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (enemyChar == Area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        else if (foodChar == Area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (finishChar == Area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (pacmanChar == Area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        if (Thread.CurrentThread.IsAlive)
                        {
                            Console.Write(Area[x / 2, y]);
                        }
                        Console.ForegroundColor = Console.BackgroundColor;
                    }
                    else
                    {
                        if (Thread.CurrentThread.IsAlive)
                        {
                            Console.Write(' ');
                        }
                    }
                }
            }
            Console.ResetColor();
        }

        public void NewCreationPos(Creation creation)
        {
            if (Area[creation.GetLastMove.Key, creation.GetLastMove.Value] == pacmanChar)
            {
                if (!empty_chars.Contains(new KeyValuePair<int, int>(creation.position_x, creation.position_y)))
                {
                    UserScore++;
                    empty_chars.Add(new KeyValuePair<int, int>(creation.position_x, creation.position_y));
                }
                Area[creation.position_x, creation.position_y] = pacmanChar;
            }
            else
            {
                Area[creation.position_x, creation.position_y] = enemyChar;
            }

            if (empty_chars.Contains(creation.GetLastMove))
            {
                Area[creation.GetLastMove.Key, creation.GetLastMove.Value] = emptyChar;
            }
            else
            {
                Area[creation.GetLastMove.Key, creation.GetLastMove.Value] = foodChar;
            }

        }
        public bool IsPosAvailable(KeyValuePair<int, int> try_pos)
        {
            if (Area[try_pos.Key, try_pos.Value] != borderChar) return true;
            else return false;
        }

        public void InitMap(int lvl_num)
        {
            switch (lvl_num)
            {
                case -1: { Level = new LevelLose(); } break;
                case 0: { Level = new LevelStart(); } break;
                case 1: { Level = new Level1(); } break;
                case 2: { Level = new Level2(); } break;
                case 3: { Level = new Level3(); } break;
                case 4: { Level = new LevelWin(); } break;
                default: throw new Exception("Unknown Error");
            }
            InitArea();
        }
        public User InitUser()
        {
            return new User(Level.user_pos_x, Level.user_pos_y);
        }
        public List<Enemy> InitEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();
            foreach (var i in Level.GetEnemiesPos)
            {
                enemies.Add(new Enemy(i.Key, i.Value));
            }
            return enemies;
        }

        private void InitArea()
        {
            Area = new char[Level.area_size_x, Level.area_size_y];
            empty_chars = new List<KeyValuePair<int, int>>();

            for (int x = 0; x < Level.area_size_x; x++)
            {
                for (int y = 0; y < Level.area_size_y; y++)
                {

                    if (Level.GetLevelBorders.Contains(new KeyValuePair<int, int>(x, y)))
                    {
                        Area[x, y] = borderChar;
                    }
                    else if (Level.GetEnemiesPos.Contains(new KeyValuePair<int, int>(x, y)))
                    {
                        Area[x, y] = enemyChar;
                        empty_chars.Add(new KeyValuePair<int, int>(x, y));

                    }
                    else if (Level.user_pos_x == x && Level.user_pos_y == y)
                    {
                        Area[x, y] = pacmanChar;
                        empty_chars.Add(new KeyValuePair<int, int>(x, y));
                    }
                    else if (Level.finish_pos_x == x && Level.finish_pos_y == y)
                    {
                        Area[x, y] = finishChar;
                    }
                    else
                    {
                        Area[x, y] = foodChar;
                    }
                }
            }

        }
    }
}
