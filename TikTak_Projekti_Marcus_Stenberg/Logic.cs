using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    public class GameLogic
    {
        public char[] Board { get; set; } // Pelilauta, 9 ruutua, johon X tai O asetetaan
        public char CurrentPlayer { get; set; } // Kumman pelaajan vuoro on
        public char LastPlayer { get; set; } // Viimeksi pelannut pelaaja, käytetään voittajan näyttämiseen

        public GameLogic()
        {
            Board = new char[9]; // Luodaan 9 ruutua taulukkoon
            for (int i = 0; i < 9; i++) Board[i] = ' '; // Käydään kaikki ruudut läpi ja alustetaan tyhjiksi
            CurrentPlayer = 'X'; // Aloitetaan pelin X:llä
        }

        // Funktio pelin nollaamiseen eli uuden pelin aloittamiseen
        public void ResetGame()
        {
            for (int i = 0; i < 9; i++) Board[i] = ' '; // Käydään kaikki ruudut läpi ja tyhjennetään ne
            CurrentPlayer = 'X'; // Aloitetaan uusi peli X:llä
        }

        // Funktio voittajan tarkistamiseen
        public bool CheckWinner()
        {
            char[] b = Board; // Lyhennetään taulukon nimeä käytön helpottamiseksi

            // Tarkistetaan vaakarivit IF-lauseilla
            if (b[0] != ' ' && b[0] == b[1] && b[1] == b[2]) return true; // Ylin vaakarivi
            if (b[3] != ' ' && b[3] == b[4] && b[4] == b[5]) return true; // Keskimmäinen vaakarivi
            if (b[6] != ' ' && b[6] == b[7] && b[7] == b[8]) return true; // Alin vaakarivi

            // Tarkistetaan pystyrivit IF-lauseilla
            if (b[0] != ' ' && b[0] == b[3] && b[3] == b[6]) return true; // Vasen pystyrivi
            if (b[1] != ' ' && b[1] == b[4] && b[4] == b[7]) return true; // Keskimmäinen pystyrivi
            if (b[2] != ' ' && b[2] == b[5] && b[5] == b[8]) return true; // Oikea pystyrivi

            // Tarkistetaan vinot linjat IF-lauseilla
            if (b[0] != ' ' && b[0] == b[4] && b[4] == b[8]) return true; // Vino vasen yläkulma -> oikea alakulma
            if (b[2] != ' ' && b[2] == b[4] && b[4] == b[6]) return true; // Vino oikea yläkulma -> vasen alakulma

            return false; // Jos ei voittajaa, palautetaan false
        }

        // Funktio tasapelin tarkistamiseen
        public bool CheckDraw()
        {
            for (int i = 0; i < 9; i++) // Käydään kaikki ruudut läpi
            {
                if (Board[i] == ' ') return false; // Jos löytyy tyhjä ruutu -> ei tasapeli
            }
            return true; // Kaikki ruudut täynnä -> tasapeli
        }
    }

    public class BoardPrinter
    {
        // Funktio pelilaudan tulostamiseen
        public void PrintBoard(char[] board, int cursor)
        {
            Console.WriteLine(); // Lisätään tyhjä rivi ennen lautaa

            for (int row = 0; row < 3; row++) // Käydään rivit läpi 0,1,2
            {
                for (int col = 0; col < 3; col++) // Käydään sarakkeet läpi 0,1,2
                {
                    int index = row * 3 + col; // Lasketaan indeksin sijainti taulukossa

                    // Tarkistetaan, onko kohdistin tässä ruudussa
                    if (index == cursor)
                        Console.Write("[" + board[index] + "]"); // Näytetään kohdistin hakasulkeissa
                    else
                        Console.Write(" " + board[index] + " "); // Normaaliruuduissa tyhjä tila ympärillä

                    if (col < 2) Console.Write("|"); // Tulostetaan pystysuora viiva sarakkeiden väliin
                }

                Console.WriteLine(); // Rivi loppuu, siirrytään seuraavalle riville

                if (row < 2) Console.WriteLine("---+---+---"); // Tulostetaan vaakaviiva rivien väliin
            }

            Console.WriteLine(); // Lisätään tyhjä rivi lopuksi
        }
    }
}