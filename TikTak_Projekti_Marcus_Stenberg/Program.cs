using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask user name
            Console.Write("Hi! What is your name? ");
            string playerName = Console.ReadLine();

            // Save start time
            DateTime startTime = DateTime.Now;

            // Create game and printer objects
            GameLogic game = new GameLogic();
            BoardPrinter printer = new BoardPrinter();

            int cursor = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Player: " + playerName);
                Console.WriteLine("Game started at: " + startTime);
                Console.WriteLine("Use ARROW KEYS to move, ENTER to place your symbol.");

                printer.PrintBoard(game.Board, cursor);

                ConsoleKey key = Console.ReadKey(true).Key;

                // Move cursor
                if (key == ConsoleKey.UpArrow && cursor > 2) cursor -= 3;
                if (key == ConsoleKey.DownArrow && cursor < 6) cursor += 3;
                if (key == ConsoleKey.LeftArrow && cursor % 3 != 0) cursor -= 1;
                if (key == ConsoleKey.RightArrow && cursor % 3 != 2) cursor += 1;

                // Place symbol
                if (key == ConsoleKey.Enter)
                {
                    if (game.Board[cursor] == ' ')
                    {
                        game.Board[cursor] = game.CurrentPlayer;
                        game.LastPlayer = game.CurrentPlayer;

                        // Switch player
                        if (game.CurrentPlayer == 'X') game.CurrentPlayer = 'O';
                        else game.CurrentPlayer = 'X';
                    }
                    else
                    {
                        Console.WriteLine("That spot is already taken! Press any key...");
                        Console.ReadKey(true);
                        continue;
                    }

                    // Check for winner
                    if (game.CheckWinner())
                    {
                        Console.Clear();
                        printer.PrintBoard(game.Board, cursor);
                        Console.WriteLine("Congratulations! Player " + game.LastPlayer + " has won!");
                        Console.WriteLine("Press R to play again or Q to quit.");

                        ConsoleKey choice = Console.ReadKey(true).Key;
                        if (choice == ConsoleKey.R) game.ResetGame();
                        else break;
                    }

                    // Check for draw
                    if (game.CheckDraw())
                    {
                        Console.Clear();
                        printer.PrintBoard(game.Board, cursor);
                        Console.WriteLine("It's a draw!");
                        Console.WriteLine("Press R to play again or Q to quit.");

                        ConsoleKey choice = Console.ReadKey(true).Key;
                        if (choice == ConsoleKey.R) game.ResetGame();
                        else break;
                    }
                }

                // Quit
                if (key == ConsoleKey.Q) break;
            }

            Console.WriteLine("Thanks for playing! Goodbye!");
        }
    }
}