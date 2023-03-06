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
            Game game = new Game();

            Thread threadViewer = new Thread(game.MapAction);
            threadViewer.Start();

            ConsoleKey key;
            key = Console.ReadKey().Key;
            do
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true).Key;
                }
                game.UserAction(key);
                if(game.IsWin())
                {
                    game.NextLevel();
                }
            } while (key != ConsoleKey.Q);
            // End all threads
        }

    }
}
