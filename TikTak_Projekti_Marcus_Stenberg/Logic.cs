using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    public class GameLogic
    {
        public char[] Board { get; set; } // Pelilauta 9 ruutua
        public char CurrentPlayer { get; set; } // Kumman pelaajan vuoro
        public char LastPlayer { get; set; } // Viimeksi pelannut pelaaja

        public GameLogic()
        {
            Board = new char[9]; // Luodaan 9 ruutua
            for (int i = 0; i < 9; i++) Board[i] = ' '; // Alustetaan tyhjiksi
            CurrentPlayer = 'X'; // Aloitetaan X:llä
        }

        // Nollaa pelin
        public void ResetGame()
        {
            for (int i = 0; i < 9; i++) Board[i] = ' '; // Tyhjennetään lauta
            CurrentPlayer = 'X'; // Aloitetaan uudelleen X:llä
        }

        // Tarkistaa voittajan
        public bool CheckWinner()
        {
            char[] b = Board;

            // Vaakasuunnassa
            if (b[0] != ' ' && b[0] == b[1] && b[1] == b[2]) return true;
            if (b[3] != ' ' && b[3] == b[4] && b[4] == b[5]) return true;
            if (b[6] != ' ' && b[6] == b[7] && b[7] == b[8]) return true;

            // Pystysuunnassa
            if (b[0] != ' ' && b[0] == b[3] && b[3] == b[6]) return true;
            if (b[1] != ' ' && b[1] == b[4] && b[4] == b[7]) return true;
            if (b[2] != ' ' && b[2] == b[5] && b[5] == b[8]) return true;

            // Vinosti
            if (b[0] != ' ' && b[0] == b[4] && b[4] == b[8]) return true;
            if (b[2] != ' ' && b[2] == b[4] && b[4] == b[6]) return true;

            return false; // Ei voittajaa
        }

        // Tarkistaa tasapelin
        public bool CheckDraw()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Board[i] == ' ') return false; // Jos löytyy tyhjä ruutu -> ei tasapeli
            }
            return true; // Kaikki ruudut täynnä -> tasapeli
        }
    }

    public class BoardPrinter
    {
        // Tulostaa pelilaudan
        public void PrintBoard(char[] board, int cursor)
        {
            Console.WriteLine(); // Tyhjä rivi

            for (int row = 0; row < 3; row++) // Käydään rivit läpi
            {
                for (int col = 0; col < 3; col++) // Käydään sarakkeet läpi
                {
                    int index = row * 3 + col; // Lasketaan indeksi

                    if (index == cursor) // Jos kohdistin tässä ruudussa
                        Console.Write("[" + board[index] + "]"); // Näytetään hakasulkeissa
                    else
                        Console.Write(" " + board[index] + " "); // Muuten normaali

                    if (col < 2) Console.Write("|"); // Sarake-erotin
                }
                Console.WriteLine(); // Rivi loppuu

                if (row < 2) Console.WriteLine("---+---+---"); // Rivi-erotin
            }

            Console.WriteLine(); // Tyhjä rivi lopuksi
        }
    }
}