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

        public byte level = 0;

        private UInt32 numOfEnemies;
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
                    if (map.IsPosAvailable(this.user.InputMoveKey(key)))
                    {
                        lastKey = key;
                        this.user.Move(this.user.InputMoveKey(key));
                        this.map.NewCreationPos(this.user);
                        Thread.Sleep(this.user.GetSpeed);
                    }
                    else if (map.IsPosAvailable(this.user.InputMoveKey(lastKey)) && lastKey != ConsoleKey.O)
                    {
                        this.user.Move(this.user.InputMoveKey(lastKey));
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
                }
            } while (true);
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
                    InitNewMap();
                }
            }
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
    }
}
