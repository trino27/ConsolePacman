using System;
using System.Collections.Generic;
using System.Text;

namespace CyberHW_Pacmen
{
    class Map
    {
        public char[,] area;
        public LevelCreator level;
        public int userPoints;

        private List<KeyValuePair<int, int>> empty_chars;

        private const char EmptyChar = ' ';
        public char GetEmptyChar
        {
            get { return EmptyChar; }
        }
        private const char BorderChar = '#';
        public char GetBorderChar
        {
            get { return BorderChar; }
        }
        private const char FoodChar = '+';
        public char GetFoodChar
        {
            get { return FoodChar; }
        }
        private const char EnemyChar = '@';
        public char GetEnemyChar
        {
            get { return EnemyChar; }
        }
        private const char PacmenChar = 'G';
        public char GetPacmenChar
        {
            get { return PacmenChar; }
        }
        private const char FinishChar = '0';
        public char GetFinishChar
        {
            get { return FinishChar; }
        }

        public void ChangeMap(Creation creation)
        {
            if (area[creation.GetLastMove.Key, creation.GetLastMove.Value] == PacmenChar)
            {
                if (!empty_chars.Contains(new KeyValuePair<int, int>(creation.position_x, creation.position_y)))
                {
                    userPoints++;
                    empty_chars.Add(new KeyValuePair<int, int>(creation.position_x, creation.position_y));
                }
                area[creation.position_x, creation.position_y] = PacmenChar;
            }else
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
        public bool TryMove(KeyValuePair<int, int> try_pos)
        {
            if (area[try_pos.Key, try_pos.Value] != BorderChar) return true;
            else return false;
        }
        public void InitMap(byte lvl_num)
        {
            switch (lvl_num)
            {
                case 1: { level = new Level1(); } break;
                case 2: { level = new Level2(); } break;
                case 3: { level = new Level3(); } break;
                default: throw new Exception("Unknown Error");
            }
            InitArea();
        }
        public User InitUser()
        {
            return new User(level.user_pos_x, level.user_pos_y);
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
                        area[x, y] = PacmenChar;
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
        public List<Enemy> InitEnemies()
        {
            List < Enemy > enemies= new List<Enemy>();
            foreach(var i in level.GetEnemiesPos)
            {
                enemies.Add(new Enemy(i.Key, i.Value));
            }
            return enemies;
        }
        
    }
}
