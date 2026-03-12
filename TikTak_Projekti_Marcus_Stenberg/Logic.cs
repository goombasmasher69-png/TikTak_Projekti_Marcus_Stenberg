using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    public class GameLogic
    {
        public char[] Board { get; set; }
        public char CurrentPlayer { get; set; }
        public char LastPlayer { get; set; }

        public GameLogic()
        {
            Board = new char[9];
            for (int i = 0; i < 9; i++) Board[i] = ' ';
            CurrentPlayer = 'X';
        }

        public void ResetGame()
        {
            for (int i = 0; i < 9; i++) Board[i] = ' ';
            CurrentPlayer = 'X';
        }

        public bool CheckWinner()
        {
            char[] b = Board;

            if (b[0] != ' ' && b[0] == b[1] && b[1] == b[2]) return true;
            if (b[3] != ' ' && b[3] == b[4] && b[4] == b[5]) return true;
            if (b[6] != ' ' && b[6] == b[7] && b[7] == b[8]) return true;

            if (b[0] != ' ' && b[0] == b[3] && b[3] == b[6]) return true;
            if (b[1] != ' ' && b[1] == b[4] && b[4] == b[7]) return true;
            if (b[2] != ' ' && b[2] == b[5] && b[5] == b[8]) return true;

            if (b[0] != ' ' && b[0] == b[4] && b[4] == b[8]) return true;
            if (b[2] != ' ' && b[2] == b[4] && b[4] == b[6]) return true;

            return false;
        }

        public bool CheckDraw()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Board[i] == ' ') return false;
            }
            return true;
        }
    }

    public class BoardPrinter
    {
        public void PrintBoard(char[] board, int cursor)
        {
            Console.WriteLine();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    int index = row * 3 + col;

                    if (index == cursor)
                        Console.Write("[" + board[index] + "]");
                    else
                        Console.Write(" " + board[index] + " ");

                    if (col < 2) Console.Write("|");
                }
                Console.WriteLine();

                if (row < 2) Console.WriteLine("---+---+---");
            }

            Console.WriteLine();
        }
    }
}