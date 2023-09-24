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

        private List<Thread> enemiesParameterizedThreads;
        private Thread timerParameterizedThread;
        private Object locker = -1;
        private int enemyThreadExistsCount = 0;

        private bool alreadyLose = false;
        private bool isPause = false;

        public int CurrentTime = 0;
        public int CurrentLevel = 0;

        public GameLogic()
        {
            lock (locker)
            {
                enemiesParameterizedThreads = new List<Thread>();
                InitNewMap();
                timerParameterizedThread = new Thread(new ParameterizedThreadStart(TimerAction));
                timerParameterizedThread.Start(this.map.Level.SecLimit);
            }
        }

        private void TimerAction(object obj_sec)
        {
            do
            {
                IsTimeOver();
                if (!isPause)
                {
                    Thread.Sleep(1000);
                    CurrentTime++;
                }
            } while (true);

        }
        private void EnemyAction(object enemy_index)
        {
            int index = (int)enemy_index;
            this.enemies[index].LastVector = enemies[index].ChosingVector();
            Enemy.Vector new_way;

            while (!alreadyLose && index < enemies.Count)
            {
                if (!isPause)
                {
                    if (map.IsPosAvailable(this.enemies[index].ProcessingWay(this.enemies[index].LastVector)))
                    {
                        this.enemies[index].Move(this.enemies[index].ProcessingWay(this.enemies[index].LastVector));
                        this.map.NewCreationPos(this.enemies[index]);
                        if (Thread.CurrentThread.IsAlive)
                        {
                            Thread.Sleep(this.enemies[index].GetSpeed);
                        }
                    }
                    else
                    {
                        new_way = enemies[index].ChosingVector();
                        if (map.IsPosAvailable(this.enemies[index].ProcessingWay(new_way)))
                        {
                            this.enemies[index].LastVector = new_way;
                            this.enemies[index].Move(this.enemies[index].ProcessingWay(new_way));
                            this.map.NewCreationPos(this.enemies[index]);
                            if (Thread.CurrentThread.IsAlive)
                            {
                                Thread.Sleep(this.enemies[index].GetSpeed);
                            }
                        }
                    }
                    if (IsKilled()) alreadyLose = true;
                }
            }
        }

        public void UserAction(ConsoleKey key)
        {

            if ((ConsoleKey.W == key || ConsoleKey.S == key || ConsoleKey.D == key || ConsoleKey.A == key) && !isPause)
            {
                if (map.IsPosAvailable(this.user.ProcessingKey(key)))
                {
                    this.user.LastKey = key;
                    this.user.Move(this.user.ProcessingKey(key));
                    this.map.NewCreationPos(this.user);
                    Thread.Sleep(this.user.GetSpeed);
                }
                else if (map.IsPosAvailable(this.user.ProcessingKey(this.user.LastKey)) && this.user.LastKey != ConsoleKey.O)
                {
                    this.user.Move(this.user.ProcessingKey(this.user.LastKey));
                    this.map.NewCreationPos(this.user);
                    Thread.Sleep(this.user.GetSpeed);
                }
            }
            else if (key == ConsoleKey.P && !isPause)
            {
                if (isPause != true) isPause = true;

            }
            else if (key == ConsoleKey.U && isPause)
            {
                isPause = false;
                if ((map.IsPosAvailable(this.user.ProcessingKey(this.user.LastKey)) && this.user.LastKey != ConsoleKey.O))
                {
                    this.user.Move(this.user.ProcessingKey(this.user.LastKey));
                    this.map.NewCreationPos(this.user);
                    Thread.Sleep(this.user.GetSpeed);
                }
            }
            else
            {
                if ((map.IsPosAvailable(this.user.ProcessingKey(this.user.LastKey)) && this.user.LastKey != ConsoleKey.O) && !isPause)
                {
                    this.user.Move(this.user.ProcessingKey(this.user.LastKey));
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

        private void RemoveAllEnemy()
        {
            lock (locker)
            {
                enemiesParameterizedThreads.Clear();
                enemies = new List<Enemy>();
            }
        }
        private void InitNewMap()
        {
            lock (locker)
            {
                Console.Clear();
                this.map.InitMap(CurrentLevel);
                this.user = map.InitUser();

                if (!alreadyLose)
                {
                    enemies = map.InitEnemies();
                    InitEnemyThreads();
                }
                this.user.LastKey = ConsoleKey.O;
            }
        }
        private void InitEnemyThreads()
        {
            lock (locker)
            {
                for (int i = 0; i < enemyThreadExistsCount; i++)
                {
                    this.enemiesParameterizedThreads.Add(new Thread(new ParameterizedThreadStart(EnemyAction)));
                }
                for (int i = enemyThreadExistsCount; i < this.enemies.Count; i++)
                {
                    this.enemiesParameterizedThreads.Add(new Thread(new ParameterizedThreadStart(EnemyAction)));
                    enemyThreadExistsCount++;
                    this.enemiesParameterizedThreads[i].Start(i);
                }
            }
        }
        private void GameInfo()
        {
            lock (locker)
            {
                Console.SetCursorPosition(0, map.Level.AreaSizeY);
                if (CurrentLevel == 0)
                {
                    Console.WriteLine("Press D to start...\n");
                }
                if (this.map.Level.IsHaveTimeLimit)
                {
                    Console.WriteLine($"Time(sec): {CurrentTime}/{this.map.Level.SecLimit}");
                }
                else Console.WriteLine("Time(sec): Unlimited");
                Console.WriteLine($"Level: {CurrentLevel}\nScore: {map.UserScore}\n");
                Console.Write("W - UP\nS - DOWN\nD - RIGHT\nA - LEFT\nP - Pause\nU - Continue\nEnter - Restart\nEsc - End");
            }

        }

        public bool IsTimeOver()
        {
            if (this.map.Level.IsHaveTimeLimit)
            {
                lock (locker)
                {
                    if (CurrentTime >= this.map.Level.SecLimit)
                    {
                        return true;
                    }
                    return false;
                }
            }
            else return false;
        }
        public bool IsKilled()
        {
            lock (locker)
            {
                foreach (var i in this.enemies)
                {
                    if (this.user.PositionX == i.PositionX && this.user.PositionY == i.PositionY)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool IsWin()
        {
            lock (locker)
            {
                if (this.user.PositionX == this.map.Level.FinishPosX && this.user.PositionY == this.map.Level.FinishPosY) return true;
                else return false;
            }
        }

        public void Lose()
        {
            lock (locker)
            {
                alreadyLose = true;
                NextLevel(-1);
            }
        }
        public void NextLevel()
        {
            lock (locker)
            {
                RemoveAllEnemy();

                CurrentTime = 0;
                CurrentLevel++;

                InitNewMap();
            }
        }
        public void NextLevel(int lvlNum)
        {
            lock (locker)
            {
                RemoveAllEnemy();

                CurrentTime = 0;
                CurrentLevel = lvlNum;

                InitNewMap();
            }
        }
        public void Restart()
        {
            lock (locker)
            {
                RemoveAllEnemy();
                CurrentLevel = 0;
                enemyThreadExistsCount = 0;
                map.UserScore = 0;
                CurrentTime = 0;
                alreadyLose = false;
                isPause = false;
                InitNewMap();
            }
        }
        public void EndGame()
        {
            lock (locker)
            {
                alreadyLose = true;
                if (timerParameterizedThread.IsAlive) timerParameterizedThread.IsBackground = true;
                RemoveAllEnemy();
            }
        }

    }
}
