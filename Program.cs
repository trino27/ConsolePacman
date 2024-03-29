﻿using System;
using System.Threading;

namespace CyberHW_Pacmen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120,40);
            
            Object locker = -1;
            GameLogic game = new GameLogic();
            Thread threadViewer = new Thread(game.MapAction);
            threadViewer.Start();
            ConsoleKey key = ConsoleKey.O;

            do
            {
                do
                {
                    if (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.Escape || key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                    game.UserAction(key);
                    if (game.IsWin())
                    {
                        game.NextLevel();
                    }
                    if (game.IsKilled() || game.IsTimeOver())
                    {
                        game.Lose();
                    }

                } while (true);

                if (key == ConsoleKey.Enter)
                {
                    lock (locker)
                    {
                        game.Restart();
                    }
                }
            } while (key != ConsoleKey.Escape);
            threadViewer.IsBackground = true;
            game.EndGame();
            Console.Clear();
            
        }
    }
}
