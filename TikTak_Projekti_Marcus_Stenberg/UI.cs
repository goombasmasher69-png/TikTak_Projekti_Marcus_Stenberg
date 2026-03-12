using System;
using System.IO;

namespace TikTak_Projekti_Marcus_Stenberg
{
    public class UI
    {
        // Tulostaa pelin aloitusinfo
        public void PrintHeader(string playerXName, string playerOName, DateTime startTime, char currentPlayer)
        {
            Console.WriteLine("Pelaaja X: " + playerXName + "    Pelaaja O: " + playerOName);
            Console.WriteLine("Peli alkoi: " + startTime);
            Console.WriteLine("Käytä NUOLI-näppäimiä liikkuaksesi, ENTER asettaa symbolin.");
            Console.WriteLine("ESC lopettaa pelin milloin tahansa.");
            Console.WriteLine("Paina V nähdäksesi aiemmat pelitulokset.");

            string currentName = currentPlayer == 'X' ? playerXName : playerOName;
            Console.WriteLine("Nykyinen vuoro: " + currentName + " (" + currentPlayer + ")");
        }

        // Liikutetaan kohdistinta nuolinäppäimillä
        public int MoveCursor(ConsoleKey key, int cursor)
        {
            if (key == ConsoleKey.UpArrow && cursor > 2) cursor -= 3;
            else if (key == ConsoleKey.DownArrow && cursor < 6) cursor += 3;
            else if (key == ConsoleKey.LeftArrow && cursor % 3 != 0) cursor -= 1;
            else if (key == ConsoleKey.RightArrow && cursor % 3 != 2) cursor += 1;

            return cursor;
        }

        // Asettaa symbolin ruutuun, palauttaa false jos varattu
        public bool PlaceSymbol(GameLogic game, int cursor)
        {
            if (game.Board[cursor] == ' ')
            {
                game.Board[cursor] = game.CurrentPlayer;
                game.LastPlayer = game.CurrentPlayer;
                // Kasvatetaan siirtojen laskuria
                game.TurnCount++;

                // Vaihdetaan pelaaja IF-lauseella
                if (game.CurrentPlayer == 'X') game.CurrentPlayer = 'O';
                else game.CurrentPlayer = 'X';

                return true;
            }
            else
            {
                Console.WriteLine("Tuo ruutu on jo varattu! Paina mitä tahansa jatkaaksesi...");
                Console.ReadKey(true);
                return false;
            }
        }

        // Näytetään voittaja (nimi)
        public void PrintWinner(string winnerName)
        {
            Console.WriteLine("Onnittelut! " + winnerName + " voitti!");
            Console.WriteLine("Paina R aloittaaksesi uuden pelin tai ESC lopettaaksesi.");
        }

        // Näytetään tasapeli
        public void PrintDraw()
        {
            Console.WriteLine("Peli päättyi tasapeliin!");
            Console.WriteLine("Paina R aloittaaksesi uuden pelin tai ESC lopettaaksesi.");
        }

        // Kysytään pelaajalta, haluaako uuden pelin
        public bool PlayAgain(GameLogic game)
        {
            while (true)
            {
                ConsoleKey choice = Console.ReadKey(true).Key;
                if (choice == ConsoleKey.R) { game.ResetGame(); return true; }
                else if (choice == ConsoleKey.Escape) return false;
            }
        }

        // Tallentaa pelin lopputuloksen tiedostoon
        public void SaveResult(string playerName, char? winner, DateTime time, int turns)
        {
            string path = "results.txt";
            string result = winner.HasValue ? $"Voittaja: {winner.Value}" : "Tasapeli";
            string line = $"{time:yyyy-MM-dd HH:mm:ss} - Pelaaja: {playerName} - {result} - Siirrot: {turns}";

            try
            {
                File.AppendAllText(path, line + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tulosten tallennus epäonnistui: " + ex.Message);
                Console.WriteLine("Paina mitä tahansa jatkaaksesi...");
                Console.ReadKey(true);
            }
        }

        // Näyttää tallennetut tulokset käyttäjälle
        public void ViewResults()
        {
            string path = "results.txt";
            Console.Clear();
            Console.WriteLine("Aiemmat pelitulokset:");

            if (!File.Exists(path))
            {
                Console.WriteLine("Ei tallennettuja tuloksia.");
            }
            else
            {
                try
                {
                    string[] lines = File.ReadAllLines(path);
                    if (lines.Length == 0) Console.WriteLine("Ei tallennettuja tuloksia.");
                    else
                    {
                        foreach (var l in lines) Console.WriteLine(l);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Tulosten lukeminen epäonnistui: " + ex.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Paina mitä tahansa jatkaaksesi...");
            Console.ReadKey(true);
        }

        // Tulostetaan lopetusviesti
        public void PrintExitMessage()
        {
            Console.WriteLine("Ohjelma lopetettiin käyttäjän toimesta.");
        }
    }
}