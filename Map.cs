using System;
using System.Collections.Generic;

namespace CyberHW_Pacmen
{
    class Map
    {
        public char[,] area;
        public LevelCreator level;
        public int userPoints;

        private List<KeyValuePair<int, int>> empty_chars;

        private const char EmptyChar = ' ';
        private const char BorderChar = '#';
        private const char FoodChar = '+';
        private const char EnemyChar = '@';
        private const char PacmanChar = 'G';
        private const char FinishChar = '0';

        public void ShowMap()
        {
            for (int y = 0; y < level.area_size_y; y++)
            {
                for (int x = 0; x < level.area_size_x * 2; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x % 2 == 0)
                    {
                        if (BorderChar == area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (EnemyChar == area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        else if (FoodChar == area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (FinishChar == area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (PacmanChar == area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.Write(area[x / 2, y]);
                        Console.ForegroundColor = Console.BackgroundColor;
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
            Console.ResetColor();
        }

        public void NewCreationPos(Creation creation)
        {
            if (area[creation.GetLastMove.Key, creation.GetLastMove.Value] == PacmanChar)
            {
                if (!empty_chars.Contains(new KeyValuePair<int, int>(creation.position_x, creation.position_y)))
                {
                    userPoints++;
                    empty_chars.Add(new KeyValuePair<int, int>(creation.position_x, creation.position_y));
                }
                area[creation.position_x, creation.position_y] = PacmanChar;
            }
            else
            {
                area[creation.position_x, creation.position_y] = EnemyChar;
            }

            if (empty_chars.Contains(creation.GetLastMove))
            {
                area[creation.GetLastMove.Key, creation.GetLastMove.Value] = EmptyChar;
            }
            else
            {
                area[creation.GetLastMove.Key, creation.GetLastMove.Value] = FoodChar;
            }

        }
        public bool IsPosAvailable(KeyValuePair<int, int> try_pos)
        {
            if (area[try_pos.Key, try_pos.Value] != BorderChar) return true;
            else return false;
        }

        public void InitMap(byte lvl_num)
        {
            switch (lvl_num)
            {
                case 0: { level = new LevelStart(); } break;
                case 1: { level = new Level1(); } break;
                case 2: { level = new Level2(); } break;
                case 3: { level = new Level3(); } break;
                case 4: { level = new LevelWin(); } break;
                default: throw new Exception("Unknown Error");
            }
            InitArea();
        }
        public User InitUser()
        {
            return new User(level.user_pos_x, level.user_pos_y);
        }
        public List<Enemy> InitEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();
            foreach (var i in level.GetEnemiesPos)
            {
                enemies.Add(new Enemy(i.Key, i.Value));
            }
            return enemies;
        }

        private void InitArea()
        {
            area = new char[level.area_size_x, level.area_size_y];
            empty_chars = new List<KeyValuePair<int, int>>();

            for (int x = 0; x < level.area_size_x; x++)
            {
                for (int y = 0; y < level.area_size_y; y++)
                {

                    if (level.GetLevelBorders.Contains(new KeyValuePair<int, int>(x, y)))
                    {
                        area[x, y] = BorderChar;
                    }
                    else if (level.GetEnemiesPos.Contains(new KeyValuePair<int, int>(x, y)))
                    {
                        area[x, y] = EnemyChar;
                        empty_chars.Add(new KeyValuePair<int, int>(x, y));

                    }
                    else if (level.user_pos_x == x && level.user_pos_y == y)
                    {
                        area[x, y] = PacmanChar;
                        empty_chars.Add(new KeyValuePair<int, int>(x, y));
                    }
                    else if (level.finish_pos_x == x && level.finish_pos_y == y)
                    {
                        area[x, y] = FinishChar;
                    }
                    else
                    {
                        area[x, y] = FoodChar;
                    }
                }
            }

        }
    }
}
