using System;
using System.Threading;

namespace CyberHW_Pacmen
{
    class Program
    {
        static void Main(string[] args)
        {
            Object locker = -1;
            Console.CursorVisible = false;
            ConsoleKey key;
            do
            {
                GameLogic game = new GameLogic();

                Thread threadViewer = new Thread(game.MapAction);
                threadViewer.Start();

                key = Console.ReadKey(true).Key;
                do
                {
                    if (Console.KeyAvailable)
                    {
                        key = Console.ReadKey(true).Key;
                    }
                    game.UserAction(key);
                    if (game.IsWin())
                    {
                        game.NextLevel();
                    }
                    if(game.IsLose())
                    {
                        game.Lose();
                    }
                } while (key != ConsoleKey.Escape || key != ConsoleKey.Enter);
                // End all threads
            } while (key != ConsoleKey.Escape);
        }

    }
}
