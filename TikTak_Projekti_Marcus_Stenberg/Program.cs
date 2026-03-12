/*
    Ohjelma: Ristinolla Konsolipeli
    Tekijä: Marcus Stenberg
    Versio: 1.2
    Päivämäärä: 12.03.2026
    Selitys ohjelmasta: 
        Tämä on yksinkertainen kahden pelaajan Ristinolla-peli konsolissa.
        Pelaaja liikuttaa kohdistinta 3x3 ruudukossa nuolinäppäimillä
        ja asettaa X- tai O-symbolin ENTER-näppäimellä.
        Ohjelma tunnistaa voiton (vaaka, pysty, vino) ja tasapelin.
        Pelaaja voi aloittaa uuden pelin R-näppäimellä tai lopettaa ESC:llä.

    Ominaisuudet:
        - Nuolinäppäimet liikuttavat kohdistinta
        - ENTER asettaa symbolin
        - ESC lopettaa ohjelman milloin tahansa
        - Voiton tunnistus (vaaka, pysty, vino)
        - Tasapelin tunnistus
        - Pelin uudelleenkäynnistys
        - Näyttää, kumman pelaajan vuoro on
*/

using System; // Käytetään konsoliin liittyviä toimintoja

namespace TikTak_Projekti_Marcus_Stenberg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kysytään käyttäjän nimi
            Console.Write("Hei! Mikä on nimesi? ");
            string playerName = Console.ReadLine(); // Luetaan käyttäjän syöte

            // Tallennetaan pelin aloitusaika
            DateTime startTime = DateTime.Now;

            // Luodaan pelilogiikka ja tulostusolio
            GameLogic game = new GameLogic();
            BoardPrinter printer = new BoardPrinter();

            int cursor = 0; // Kohdistimen alkupaikka (0 = ylin vasen ruutu)

            while (true) // Pääsilmukka
            {
                Console.Clear(); // Tyhjennetään konsoli
                Console.WriteLine("Pelaaja: " + playerName); // Näytetään pelaajan nimi
                Console.WriteLine("Peli alkoi: " + startTime); // Näytetään aloitusaika
                Console.WriteLine("Käytä NUOLI-näppäimiä liikkuaksesi, ENTER asettaa symbolin.");
                Console.WriteLine("ESC lopettaa pelin milloin tahansa.");
                Console.WriteLine("Nykyinen vuoro: Pelaaja " + game.CurrentPlayer); // Näytetään kumman vuoro

                printer.PrintBoard(game.Board, cursor); // Tulostetaan pelilauta

                // Luetaan näppäinpainallus
                ConsoleKey key = Console.ReadKey(true).Key;

                // ESC lopettaa pelin
                if (key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Ohjelma lopetettiin käyttäjän toimesta.");
                    break; // Poistutaan silmukasta
                }

                // Liikutetaan kohdistinta
                if (key == ConsoleKey.UpArrow && cursor > 2) cursor -= 3; // Ylös
                else if (key == ConsoleKey.DownArrow && cursor < 6) cursor += 3; // Alas
                else if (key == ConsoleKey.LeftArrow && cursor % 3 != 0) cursor -= 1; // Vasen
                else if (key == ConsoleKey.RightArrow && cursor % 3 != 2) cursor += 1; // Oikea
                else if (key != ConsoleKey.Enter) // Virheellinen näppäin
                {
                    Console.WriteLine("Virheellinen näppäin! Käytä nuolia, ENTER tai ESC.");
                    Console.ReadKey(true);
                    continue; // Aloitetaan silmukan uusi kierros
                }

                // ENTER asettaa symbolin
                if (key == ConsoleKey.Enter)
                {
                    if (game.Board[cursor] == ' ') // Ruutu tyhjä
                    {
                        game.Board[cursor] = game.CurrentPlayer; // Asetetaan symboli
                        game.LastPlayer = game.CurrentPlayer; // Tallennetaan viimeinen pelaaja

                        // Vaihdetaan pelaaja
                        if (game.CurrentPlayer == 'X') game.CurrentPlayer = 'O';
                        else game.CurrentPlayer = 'X';
                    }
                    else // Ruutu varattu
                    {
                        Console.WriteLine("Tuo ruutu on jo varattu! Paina mitä tahansa jatkaaksesi...");
                        Console.ReadKey(true);
                        continue;
                    }

                    // Tarkistetaan voittaja
                    if (game.CheckWinner())
                    {
                        Console.Clear();
                        printer.PrintBoard(game.Board, cursor);
                        Console.WriteLine("Onnittelut! Pelaaja " + game.LastPlayer + " voitti!");
                        Console.WriteLine("Paina R aloittaaksesi uuden pelin tai ESC lopettaaksesi.");

                        while (true) // Uudelleen valinta
                        {
                            ConsoleKey choice = Console.ReadKey(true).Key;
                            if (choice == ConsoleKey.R) { game.ResetGame(); break; } // Aloitetaan uusi peli
                            else if (choice == ConsoleKey.Escape) { return; } // Lopetetaan ohjelma
                        }
                    }

                    // Tarkistetaan tasapeli
                    else if (game.CheckDraw())
                    {
                        Console.Clear();
                        printer.PrintBoard(game.Board, cursor);
                        Console.WriteLine("Peli päättyi tasapeliin!");
                        Console.WriteLine("Paina R aloittaaksesi uuden pelin tai ESC lopettaaksesi.");

                        while (true) // Uudelleen valinta
                        {
                            ConsoleKey choice = Console.ReadKey(true).Key;
                            if (choice == ConsoleKey.R) { game.ResetGame(); break; }
                            else if (choice == ConsoleKey.Escape) { return; }
                        }
                    }
                }
            }

            Console.WriteLine("Kiitos pelaamisesta! Näkemiin!");
        }
    }
}