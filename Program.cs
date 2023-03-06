﻿using System;
using System.Threading;

namespace CyberHW_Pacmen
{
    class Program
    {
        static void Main(string[] args)
        {
            Object locker = -1;
            Console.CursorVisible = false;
            Game game = new Game();
            Thread threadViewer = new Thread(game.MapAction);

            //game.EnemyAction();
            // thread for each

            threadViewer.Start();

            
            ConsoleKey key;
            // Press 1 to start
            key = Console.ReadKey().Key;
            do
            {
                    if (Console.KeyAvailable)
                    {

                        key = Console.ReadKey(true).Key;
                    }
                    game.UserAction(key);
            } while (key != ConsoleKey.D0);
            // End all threads
        }

    }
}
