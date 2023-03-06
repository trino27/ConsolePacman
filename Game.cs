using System;
using System.Collections.Generic;
using System.Threading;

namespace CyberHW_Pacmen
{
    class Game
    {
        Map map = new Map();

        User user;
        List<Enemy> enemies;

        public byte level = 1;
        public UInt32 numOfEnemies;

        public bool IsStop = false;
        public bool IsWin = false;

        private ConsoleKey lastKey;
        private Object locker = -1;

        public Game()
        {
            InitNewMap();
        }
        public void EnemyAction()
        {

        }
        public void UserAction(ConsoleKey key)
        {
            
                if (ConsoleKey.W == key || ConsoleKey.S == key || ConsoleKey.D == key || ConsoleKey.A == key)
                {
                    if (map.TryMove(this.user.InputMoveKey(key)))
                    {
                        lastKey = key;
                        this.user.Move(this.user.InputMoveKey(key));
                        // IsWin?
                        // IsSamePosWithEnemy
                        this.map.ChangeMap(this.user);
                        Thread.Sleep(this.user.GetSpeed);
                    }
                    else if (map.TryMove(this.user.InputMoveKey(lastKey)) && lastKey != ConsoleKey.O)
                    {
                        this.user.Move(this.user.InputMoveKey(lastKey));
                        // IsWin?
                        // IsSamePosWithEnemy
                        this.map.ChangeMap(this.user);
                        Thread.Sleep(this.user.GetSpeed);
                    }
                }
            
        }
        public void MapAction()
        {
            do
            {
                lock (locker)
                {
                    ShowMap();
                }
            } while (true);
        }
        private void InitNewMap()
        {
            this.map.InitMap(level);
            this.user = map.InitUser();
            this.enemies = new List<Enemy>();
            lastKey = ConsoleKey.O;

            try
            {
                numOfEnemies = (UInt32)enemies.Count;
            }
            catch
            {
                throw new Exception("Error number of enemies");
            }
        }

        private void ShowMap()
        {
            for (int y = 0; y < map.level.area_size_y; y++)
            {
                for (int x = 0; x < map.level.area_size_x * 2; x++)
                {
                    Console.SetCursorPosition(x, y);

                    if (x % 2 == 0)
                    {
                        if (map.GetBorderChar == map.area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (map.GetEnemyChar == map.area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                        }
                        else if (map.GetFoodChar == map.area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (map.GetFinishChar == map.area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (map.GetPacmenChar == map.area[x / 2, y])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.Write(map.area[x / 2, y]);
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
        private void NextLevel()
        {
            level++;
            InitNewMap();
        }
    }
}
