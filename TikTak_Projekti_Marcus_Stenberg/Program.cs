using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask user name
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            // Save date and time
            DateTime startTime = DateTime.Now;

            // Print welcome message
            Console.WriteLine("Welcome to Tic Tac Toe " + playerName);
            Console.WriteLine("Game started at: " + startTime);

            // Create objects
            GameLogic game = new GameLogic();
            BoardPrinter printer = new BoardPrinter();

            // Game loop
            while (true)
            {
                // Print board
                printer.PrintBoard(game.Board);

                // Ask move
                Console.Write("Enter position (1-9) or 0 to quit: ");
                int move = int.Parse(Console.ReadLine());

                // Exit program
                if (move == 0)
                {
                    break;
                }

                // Make move
                game.MakeMove(move);
            }

            // Exit message
            Console.WriteLine("Program closing. Thank you for playing.");
        }
    }
}