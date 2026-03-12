using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    public class GameLogic
    {
        // Board property
        public char[] Board { get; set; }

        // Current player property
        public char CurrentPlayer { get; set; }

        // Constructor
        public GameLogic()
        {
            Board = new char[9];

            // Fill board with empty spaces
            for (int i = 0; i < 9; i++)
            {
                Board[i] = ' ';
            }

            CurrentPlayer = 'X';
        }

        // Method to make a move
        public void MakeMove(int position)
        {
            if (position >= 1 && position <= 9)
            {
                if (Board[position - 1] == ' ')
                {
                    Board[position - 1] = CurrentPlayer;

                    if (CurrentPlayer == 'X')
                    {
                        CurrentPlayer = 'O';
                    }
                    else
                    {
                        CurrentPlayer = 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Position already taken.");
                }
            }
            else
            {
                Console.WriteLine("Invalid position.");
            }
        }
    }

    public class BoardPrinter
    {
        // Method to print the board
        public void PrintBoard(char[] board)
        {
            Console.WriteLine();

            Console.WriteLine(" " + board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + board[6] + " | " + board[7] + " | " + board[8]);

            Console.WriteLine();
        }
    }
}