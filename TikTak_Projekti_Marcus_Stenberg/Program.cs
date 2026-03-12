using System;
using TikTak_Projekti_Marcus_Stenberg;

namespace TikTak_Projekti_Marcus_Stenberg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask user name
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            // Save start time
            DateTime startTime = DateTime.Now;

            // Create objects
            GameLogic game = new GameLogic();
            BoardPrinter printer = new BoardPrinter();

            // Cursor position
            int cursor = 0;

            while (true)
            {
                // Clear screen
                Console.Clear();

                // Print information
                Console.WriteLine("Player: " + playerName);
                Console.WriteLine("Started: " + startTime);
                Console.WriteLine("Use WASD to move, E to place, Q to quit");

                // Print board with cursor
                printer.PrintBoard(game.Board, cursor);

                // Read key
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                {
                    break;
                }

                if (key == ConsoleKey.W)
                {
                    cursor = cursor - 3;
                    if (cursor < 0)
                    {
                        cursor = 0;
                    }
                }

                if (key == ConsoleKey.S)
                {
                    cursor = cursor + 3;
                    if (cursor > 8)
                    {
                        cursor = 8;
                    }
                }

                if (key == ConsoleKey.A)
                {
                    cursor = cursor - 1;
                    if (cursor < 0)
                    {
                        cursor = 0;
                    }
                }

                if (key == ConsoleKey.D)
                {
                    cursor = cursor + 1;
                    if (cursor > 8)
                    {
                        cursor = 8;
                    }
                }

                if (key == ConsoleKey.E)
                {
                    game.MakeMove(cursor + 1);
                }
            }

            Console.WriteLine("Program closing. Thank you for playing.");
        }
    }
}