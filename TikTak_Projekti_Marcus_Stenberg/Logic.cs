using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    public class GameLogic
    {
        public char[] Board { get; set; }

        public char CurrentPlayer { get; set; }

        public GameLogic()
        {
            Board = new char[9];

            for (int i = 0; i < 9; i++)
            {
                Board[i] = ' ';
            }

            CurrentPlayer = 'X';
        }

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
            }
        }
    }

    public class BoardPrinter
    {
        public void PrintBoard(char[] board, int cursor)
        {
            Console.WriteLine();

            PrintCell(board, 0, cursor);
            Console.Write("|");
            PrintCell(board, 1, cursor);
            Console.Write("|");
            PrintCell(board, 2, cursor);

            Console.WriteLine();
            Console.WriteLine("---+---+---");

            PrintCell(board, 3, cursor);
            Console.Write("|");
            PrintCell(board, 4, cursor);
            Console.Write("|");
            PrintCell(board, 5, cursor);

            Console.WriteLine();
            Console.WriteLine("---+---+---");

            PrintCell(board, 6, cursor);
            Console.Write("|");
            PrintCell(board, 7, cursor);
            Console.Write("|");
            PrintCell(board, 8, cursor);

            Console.WriteLine();
        }

        public void PrintCell(char[] board, int index, int cursor)
        {
            if (index == cursor)
            {
                Console.Write("[" + board[index] + "]");
            }
            else
            {
                Console.Write(" " + board[index] + " ");
            }
        }
    }
}