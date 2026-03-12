/*
    Ohjelma: Ristinolla Konsolipeli
    Tekijä: Marcus Stenberg
    Versio: 1.4
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

using System;

namespace TikTak_Projekti_Marcus_Stenberg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kysytään pelaajien nimet
            Console.Write("Hei! Mikä on pelaaja X:n nimi? ");
            string playerXName = Console.ReadLine();
            Console.Write("Mikä on pelaaja O:n nimi? ");
            string playerOName = Console.ReadLine();

            // Tallennetaan pelin aloitusaika
            DateTime startTime = DateTime.Now;

            // Luodaan pelin olio, tulostusolio ja käyttöliittymäolio
            GameLogic game = new GameLogic();
            BoardPrinter printer = new BoardPrinter();
            UI ui = new UI();

            int cursor = 0; // Kohdistimen alkupaikka (ylin vasen ruutu)

            while (true) // Pääsilmukka
            {
                Console.Clear(); // Tyhjennetään konsoli
                ui.PrintHeader(playerXName, playerOName, startTime, game.CurrentPlayer); // Tulostetaan info
                printer.PrintBoard(game.Board, cursor); // Tulostetaan lauta

                // Luetaan käyttäjän näppäin
                ConsoleKey key = Console.ReadKey(true).Key;

                // Tarkistetaan ESC -> lopetetaan ohjelma
                if (key == ConsoleKey.Escape)
                {
                    ui.PrintExitMessage(); // Viesti lopetuksesta
                    break;
                }

                // Näytä aiemmat tulokset, jos käyttäjä painaa V
                if (key == ConsoleKey.V)
                {
                    ui.ViewResults();
                    continue;
                }

                // Liikutetaan kohdistinta
                cursor = ui.MoveCursor(key, cursor); // Käytetään UserInterface luokan funktiota

                // ENTER -> asetetaan symboli
                if (key == ConsoleKey.Enter)
                {
                    if (!ui.PlaceSymbol(game, cursor)) continue; // Tarkistaa ruudun vapautta, palauttaa false jos varattu

                    // Tarkistetaan voittaja
                    if (game.CheckWinner())
                    {
                        Console.Clear();
                        printer.PrintBoard(game.Board, cursor);
                        // Näytetään voittaja nimen kanssa
                        string winnerName = game.LastPlayer == 'X' ? playerXName : playerOName;
                        ui.PrintWinner(winnerName);
                        // Tallennetaan tulos
                        ui.SaveResult(winnerName, game.LastPlayer, DateTime.Now, game.TurnCount);
                        if (!ui.PlayAgain(game)) break; // Kysytään uusi peli tai lopetus
                    }
                    // Tarkistetaan tasapeli
                    else if (game.CheckDraw())
                    {
                        Console.Clear();
                        printer.PrintBoard(game.Board, cursor);
                        ui.PrintDraw(); // Näytetään tasapeli
                        // Tallennetaan tasapeli
                        ui.SaveResult(playerXName + " vs " + playerOName, null, DateTime.Now, game.TurnCount);
                        if (!ui.PlayAgain(game)) break; // Kysytään uusi peli tai lopetus
                    }
                }
            }

            Console.WriteLine("Kiitos pelaamisesta! Näkemiin!");
        }
    }
}