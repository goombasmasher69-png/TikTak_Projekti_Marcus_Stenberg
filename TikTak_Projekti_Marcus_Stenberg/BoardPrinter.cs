using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    public class BoardPrinter
    {
        // Tulostaa pelilaudan ja korostaa kohdistimen
        public void PrintBoard(char[] board, int cursor)
        {
            Console.WriteLine(); // Tyhjä rivi

            for (int row = 0; row < 3; row++) // Käydään rivit läpi
            {
                for (int col = 0; col < 3; col++) // Käydään sarakkeet läpi
                {
                    int index = row * 3 + col; // Lasketaan indeksi taulukosta

                    // Tarkistetaan onko kohdistin tässä ruudussa
                    if (index == cursor)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray; // Kohdistimen tausta
                        // Näytetään symboli
                        PrintColoredSymbol(board[index]);
                        Console.ResetColor(); // Palautetaan värit
                    }
                    else // Normaalit ruudut
                    {
                        PrintColoredSymbol(board[index]); // Tulostetaan X tai O värillä
                    }

                    if (col < 2) Console.Write("|"); // Sarake-erotin
                }

                Console.WriteLine(); // Rivin loppu

                if (row < 2) Console.WriteLine("---+---+---"); // Rivi-erotin
            }

            Console.WriteLine(); // Tyhjä rivi lopuksi
        }

        // Apufunktio, joka tulostaa X punaisena, O vihreänä ja tyhjän normaalina
        private void PrintColoredSymbol(char symbol)
        {
            if (symbol == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Red; // X = punainen
                Console.Write(" " + symbol + " ");
                Console.ResetColor();
            }
            else if (symbol == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Green; // O = vihreä
                Console.Write(" " + symbol + " ");
                Console.ResetColor();
            }
            else // Tyhjä ruutu
            {
                Console.Write("   ");
            }
        }
    }
}