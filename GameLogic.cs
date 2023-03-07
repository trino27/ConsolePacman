using System;
using System.Collections.Generic;
using System.Threading;

namespace CyberHW_Pacmen
{
    class GameLogic
    {
        private Map map = new Map();
        private User user;
        private List<Enemy> enemies;
        private Object locker = -1;
        private bool AlreadyLose = false;
        private List<Thread> enemiesParameterizedThreads;
        public int level = 0;
        public bool IsPause = false;

        public GameLogic()
        {
            lock (locker)
            {
                InitNewMap();
            }
        }

        public void EnemyAction(object enemy_index)
        {
            int index = (int)enemy_index;
            this.enemies[index].lastWay = enemies[index].ChosingWay();
            Enemy.Way new_way;

            while (!AlreadyLose && index < enemies.Count)
            {
                if (!IsPause)
                {
                    if (map.IsPosAvailable(this.enemies[index].ProcessingWay(this.enemies[index].lastWay)))
                    {
                        this.enemies[index].Move(this.enemies[index].ProcessingWay(this.enemies[index].lastWay));
                        this.map.NewCreationPos(this.enemies[index]);
                        if (Thread.CurrentThread.IsAlive)
                        {
                            Thread.Sleep(this.enemies[index].GetSpeed);
                        }
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
                    IsLose();
                }
            }
        }
        public void UserAction(ConsoleKey key)
        {

            if ((ConsoleKey.W == key || ConsoleKey.S == key || ConsoleKey.D == key || ConsoleKey.A == key) && !IsPause)
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
            else if (key == ConsoleKey.P && !IsPause)
            {
                if (IsPause != true) IsPause = true;
               
            }
            else if (key == ConsoleKey.U && IsPause)
            {
                    IsPause = false;
                    if ((map.IsPosAvailable(this.user.ProcessingKey(this.user.lastKey)) && this.user.lastKey != ConsoleKey.O))
                    {
                        this.user.Move(this.user.ProcessingKey(this.user.lastKey));
                        this.map.NewCreationPos(this.user);
                        Thread.Sleep(this.user.GetSpeed);
                    }
            }
            else
            {
                if ((map.IsPosAvailable(this.user.ProcessingKey(this.user.lastKey)) && this.user.lastKey != ConsoleKey.O) && !IsPause)
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
            lock (locker)
            {
                NextLevel(-1);
            }
        }
        public bool IsLose()
        {
            lock (locker)
            {
                foreach (var i in this.enemies)
                {
                    if (this.user.position_x == i.position_x && this.user.position_y == i.position_y)
                    {
                        AlreadyLose = true;
                        return true;
                    }
                }
                // Закончилось время
                return false;
            }
        }
        public bool IsWin()
        {
            lock (locker)
            {
                if (this.user.position_x == this.map.level.finish_pos_x && this.user.position_y == this.map.level.finish_pos_y) return true;
                else return false;
            }
        }
        public void NextLevel()
        {
            lock (locker)
            {
                RemoveAllEnemy();
                level++;
                InitNewMap();
            }
        }
        public void NextLevel(int lvl_i)
        {
            lock (locker)
            {
                RemoveAllEnemy();
                level = lvl_i;
                InitNewMap();
            }
        }
        public void Restart()
        {
            lock (locker)
            {
                RemoveAllEnemy();
                level = 0;
                map.userPoints = 0;
                AlreadyLose = false;
                InitNewMap();
            }
        }
        private void RemoveAllEnemy()
        {
            lock (locker)
            {
                foreach (var i in enemiesParameterizedThreads)
                {
                    if (i.IsAlive) i.IsBackground = true;
                }

                enemiesParameterizedThreads = new List<Thread>();
                enemies = new List<Enemy>();
            }
        }
        private void InitNewMap()
        {
            lock (locker)
            {
                Console.Clear();
                this.map.InitMap(level);
                this.user = map.InitUser();

                if (!AlreadyLose)
                {
                    this.enemies = map.InitEnemies();
                    this.enemiesParameterizedThreads = new List<Thread>();
                    InitEnemyThreds();
                }
                this.user.lastKey = ConsoleKey.O;
            }
        }
        private void InitEnemyThreds()
        {
            lock (locker)
            {
                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.enemiesParameterizedThreads.Add(new Thread(new ParameterizedThreadStart(EnemyAction)));
                }
                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.enemiesParameterizedThreads[i].Start(i);
                }
            }
        }
        private void GameInfo()
        {
            Console.SetCursorPosition(0, map.level.area_size_y);
            Console.WriteLine($"Level: {level}\nScore: {map.userPoints}");
            Console.Write("W - UP\nS - DOWN\nD - RIGHT\nA - LEFT\nP - Pause\nU - Continue\nEnter - Restart\nEsc - End\nPress D to start...");
        }
    }
}
