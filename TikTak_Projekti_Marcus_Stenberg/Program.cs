/*
    Ohjelma: Ristinolla Konsolipeli
    Tekijä: Marcus Stenberg
    Versio: 1.3
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
            // Kysytään käyttäjän nimi ja tallennetaan muuttujaan
            Console.Write("Hei! Mikä on nimesi? ");
            string playerName = Console.ReadLine(); // Luetaan käyttäjän syöte konsolista

            // Tallennetaan pelin aloitusaika
            DateTime startTime = DateTime.Now;

            // Luodaan pelin logiikka-olio ja tulostusolio
            GameLogic game = new GameLogic();
            BoardPrinter printer = new BoardPrinter();

            int cursor = 0; // Määritetään kohdistimen alkupaikka (ylin vasen ruutu = 0)

            while (true) // Pääsilmukka alkaa
            {
                Console.Clear(); // Tyhjennetään konsoli jokaisella kierroksella
                Console.WriteLine("Pelaaja: " + playerName); // Näytetään pelaajan nimi
                Console.WriteLine("Peli alkoi: " + startTime); // Näytetään pelin aloitusaika
                Console.WriteLine("Käytä NUOLI-näppäimiä liikkuaksesi, ENTER asettaa symbolin.");
                Console.WriteLine("ESC lopettaa pelin milloin tahansa.");
                Console.WriteLine("Nykyinen vuoro: Pelaaja " + game.CurrentPlayer); // Näytetään, kumman vuoro

                printer.PrintBoard(game.Board, cursor); // Tulostetaan pelilauta

                // Luetaan näppäin painallus ilman konsoliin näyttämistä
                ConsoleKey key = Console.ReadKey(true).Key;

                // Tarkistetaan, onko ESC painettu -> ohjelma lopetetaan
                if (key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Ohjelma lopetettiin käyttäjän toimesta.");
                    break; // Poistutaan pääsilmukasta
                }

                // Tarkistetaan nuolinäppäimet ja liikutetaan kohdistinta
                if (key == ConsoleKey.UpArrow && cursor > 2) cursor -= 3; // Siirretään ylös
                else if (key == ConsoleKey.DownArrow && cursor < 6) cursor += 3; // Siirretään alas
                else if (key == ConsoleKey.LeftArrow && cursor % 3 != 0) cursor -= 1; // Siirretään vasemmalle
                else if (key == ConsoleKey.RightArrow && cursor % 3 != 2) cursor += 1; // Siirretään oikealle
                else if (key != ConsoleKey.Enter) // Tarkistetaan, että painettu näppäin ei ole hyväksytty
                {
                    // Ilmoitetaan virheellinen näppäin
                    Console.WriteLine("Virheellinen näppäin! Käytä nuolia, ENTER tai ESC.");
                    Console.ReadKey(true); // Odotetaan, että käyttäjä painaa mitä tahansa
                    continue; // Aloitetaan pääsilmukan uusi kierros
                }

                // Jos painetaan ENTER -> yritetään asettaa symboli
                if (key == ConsoleKey.Enter)
                {
                    if (game.Board[cursor] == ' ') // Tarkistetaan, onko ruutu tyhjä
                    {
                        game.Board[cursor] = game.CurrentPlayer; // Asetetaan nykyisen pelaajan symboli
                        game.LastPlayer = game.CurrentPlayer; // Tallennetaan viimeiseksi pelannut pelaaja

                        // Vaihdetaan pelaaja IF-lauseella
                        if (game.CurrentPlayer == 'X') game.CurrentPlayer = 'O';
                        else game.CurrentPlayer = 'X';
                    }
                    else // Jos ruutu on jo varattu
                    {
                        Console.WriteLine("Tuo ruutu on jo varattu! Paina mitä tahansa jatkaaksesi...");
                        Console.ReadKey(true); // Odotetaan näppäinpainallusta
                        continue; // Aloitetaan pääsilmukan uusi kierros
                    }

                    // Tarkistetaan voittaja IF-lauseilla
                    if (game.CheckWinner())
                    {
                        Console.Clear(); // Tyhjennetään ruutu
                        printer.PrintBoard(game.Board, cursor); // Tulostetaan lopullinen lauta
                        Console.WriteLine("Onnittelut! Pelaaja " + game.LastPlayer + " voitti!");
                        Console.WriteLine("Paina R aloittaaksesi uuden pelin tai ESC lopettaaksesi.");

                        while (true) // Silmukka, jolla käyttäjä voi valita uudelleen
                        {
                            ConsoleKey choice = Console.ReadKey(true).Key;
                            if (choice == ConsoleKey.R) { game.ResetGame(); break; } // IF: jos R -> uusi peli
                            else if (choice == ConsoleKey.Escape) { return; } // IF: jos ESC -> lopetetaan ohjelma
                        }
                    }

                    // Tarkistetaan tasapeli IF-lauseella
                    else if (game.CheckDraw())
                    {
                        Console.Clear(); // Tyhjennetään ruutu
                        printer.PrintBoard(game.Board, cursor); // Tulostetaan lopullinen lauta
                        Console.WriteLine("Peli päättyi tasapeliin!");
                        Console.WriteLine("Paina R aloittaaksesi uuden pelin tai ESC lopettaaksesi.");

                        while (true) // Silmukka, jolla käyttäjä voi valita uudelleen
                        {
                            ConsoleKey choice = Console.ReadKey(true).Key;
                            if (choice == ConsoleKey.R) { game.ResetGame(); break; } // IF: jos R -> uusi peli
                            else if (choice == ConsoleKey.Escape) { return; } // IF: jos ESC -> lopetetaan ohjelma
                        }
                    }
                }
            }

            Console.WriteLine("Kiitos pelaamisesta! Näkemiin!"); // Lopuksi kiitetään pelaajaa
        }
    }
}