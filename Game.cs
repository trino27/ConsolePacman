using System;
using System.Collections.Generic;
using System.Threading;

namespace CyberHW_Pacmen
{
    class Game
    {
        private Map map = new Map();
        private User user;
        private List<Enemy> enemies;
        List<Thread> enemiesParameterizedThreads;

        public byte level = 0;

        
        private Object locker = -1;

        public Game()
        {
            InitNewMap();
        }
        public void EnemyAction(object enemy_index)
        {
            int index = (int)enemy_index;
            this.enemies[index].lastWay = enemies[index].ChosingWay();
            Enemy.Way new_way; 
            do
            {
                if (map.IsPosAvailable(this.enemies[index].ProcessingWay(this.enemies[index].lastWay)))
                {
                    this.enemies[index].Move(this.enemies[index].ProcessingWay(this.enemies[index].lastWay));
                    this.map.NewCreationPos(this.enemies[index]);
                    Thread.Sleep(this.enemies[index].GetSpeed);
                }
                else
                {
                    new_way = enemies[index].ChosingWay();
                    if (map.IsPosAvailable(this.enemies[index].ProcessingWay(new_way)))
                    {
                        this.enemies[index].lastWay = new_way;
                        this.enemies[index].Move(this.enemies[index].ProcessingWay(new_way));
                        this.map.NewCreationPos(this.enemies[index]);
                        Thread.Sleep(this.enemies[index].GetSpeed);
                    }
                }
            } while (true);
        }
        public void UserAction(ConsoleKey key)
        {
            if (ConsoleKey.W == key || ConsoleKey.S == key || ConsoleKey.D == key || ConsoleKey.A == key)
            {
                if (map.IsPosAvailable(this.user.ProcessingKey(key)))
                {
                    this.user.lastKey = key;
                    this.user.Move(this.user.ProcessingKey(key));
                    this.map.NewCreationPos(this.user);
                    Thread.Sleep(this.user.GetSpeed);
                }
                else if (map.IsPosAvailable(this.user.ProcessingKey(this.user.lastKey)) && this.user.lastKey != ConsoleKey.O)
                {
                    this.user.Move(this.user.ProcessingKey(this.user.lastKey));
                    this.map.NewCreationPos(this.user);
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
                    map.ShowMap();
                    GameInfo();
                }
            } while (true);
        }

        public void Lose()
        {

        }
        public bool IsLose()
        {
            return false;
        }
        public bool IsWin()
        {
            if (this.user.position_x == this.map.level.finish_pos_x && this.user.position_y == this.map.level.finish_pos_y) return true;
            else return false;
        }
        public void NextLevel()
        {
            lock (locker)
            {
                if (!this.map.level.IsLastLevel)
                {
                    level++;
                    Console.Clear();
                    InitNewMap();
                }
            }
        }

        private void InitNewMap()
        {
            lock (locker)
            {
                this.map.InitMap(level);
                this.user = map.InitUser();
                this.enemies = map.InitEnemies();

                this.enemiesParameterizedThreads = new List<Thread>();
                InitEnemyThreds();

                this.user.lastKey = ConsoleKey.O;
            }
        }
        private void InitEnemyThreds()
        {
            for (int i = 0; i < this.enemies.Count; i++)
            {
                this.enemiesParameterizedThreads.Add(new Thread(new ParameterizedThreadStart(EnemyAction)));
                this.enemiesParameterizedThreads[i].Start(i);
            }
        }
        private void GameInfo()
        {
            Console.SetCursorPosition(0, map.level.area_size_y);
            Console.WriteLine($"Level: {level}\nScore: {map.userPoints}");
            Console.Write("W - UP\nS - DOWN\nD - RIGHT\nA - LEFT\nQ - End\nE - Stop\nPress D to start...");

        }
    }
}
