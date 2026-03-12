# Ristinolla Konsolipeli

**Tekijä:** Marcus Stenberg  
**Versio:** 1.4  
**Päivämäärä:** 12.03.2026  

---

## Kuvaus
Tämä on yksinkertainen kahden pelaajan **Tic-Tac-Toe / Ristinolla -peli** konsolissa.  
Pelaajat liikuttavat kohdistinta 3x3 ruudukossa **nuolinäppäimillä** ja asettavat X- tai O-symbolin **ENTER**-näppäimellä.  

Ohjelma tunnistaa automaattisesti **voiton (vaaka, pysty, vino)** ja **tasapelin**, ja pelaaja voi halutessaan **aloittaa uuden pelin** tai **lopettaa ohjelman ESC-näppäimellä**.

---

## Ominaisuudet
- Nuolinäppäimet liikuttavat kohdistinta ruudukossa.
- ENTER asettaa X- tai O-symbolin.
- ESC lopettaa ohjelman milloin tahansa.
- Voiton tunnistus:
  - Vaakasuoraan
  - Pystysuoraan
  - Vinottain
- Tasapelin tunnistus
- Pelin uudelleenkäynnistys R-näppäimellä
- Näyttää, kumman pelaajan vuoro on
- X näkyy **punaisena**, O **vihreänä**
- Kohdistin näkyy taustavärillä helpottamaan valintaa
- Jokainen koodirivi kommentoitu selkosuomella opiskelijan näkökulmasta

---

## Projektin rakenne
TikTak_Projekti_Marcus_Stenberg/
│
├─ Program.cs # Pääohjelma, käyttäjän syötteet, pääsilmukka
├─ GameLogic.cs # Pelin säännöt, lauta, tarkistukset voittajalle ja tasapelille
├─ BoardPrinter.cs # Lautan tulostus, värit ja kohdistimen näyttäminen
└─ README.md # Tämä tiedosto

---

## Käyttöohjeet

1. Käynnistä ohjelma Visual Studio -konsolissa tai muussa C#-ympäristössä.
2. Anna nimesi kun kysytään.
3. Käytä **nuolinäppäimiä** liikuttaaksesi kohdistinta ruudukossa.
4. Paina **ENTER** asettaaksesi X tai O valittuun ruutuun.
5. **ESC** lopettaa ohjelman milloin tahansa.
6. Kun peli loppuu voittoon tai tasapeliin:
   - Paina **R** aloittaaksesi uuden pelin.
   - Paina **ESC** lopettaaksesi ohjelman.

---

## Kehitystekniikat / oppimispisteet
- Käytetty **luokkia ja olioita** (OOP)  
- Eri **vastuualueet** eriytetty:  
  - Pelilogiikka → GameLogic  
  - Näyttö / värit → BoardPrinter  
  - Käyttäjäsyötteet / silmukka → Program  
- Harjoiteltu:
  - Taulukoita ja silmukoita
  - Ehtolauseita ja virheentarkistuksia
  - Konsolin I/O ja värien käyttö
  - Pelin tilan hallintaa ja pelaajien vuorojen vaihtoa
  - Boolean-arvojen käyttö (voittaja / tasapeli)

---

## Versiohistoria

1.0 – Peruslogiikka ja ruudukon tulostus

1.1 – Nuolinäppäimet liikuttavat kohdistinta, ENTER syötteen käyttö

1.2 – Tasapelin ja voiton tarkistus, R-näppäin uudelleenkäynnistykseen

1.3 – Kolmen luokan rakenne: Program, GameLogic, BoardPrinter

1.4 – Värit lisätty: X = punainen, O = vihreä, kohdistin taustalla

1.5 – Tulosten tallennus results.txt
1.5 – Uudet UI-metodit: SaveResult(...) ja ViewResults()
1.5 – Tallennusmuoto: YYYY-MM-DD HH:mm:ss - X: <name> - O: <name> - Voittaja: <name/Tasapeli> - Siirrot: <turns>
1.5 – Perusvirheenkäsittely tiedostolle (try/catch, käyttäjälle ilmoitus)
1.5 – Kysytään molempien pelaajien nimet (playerXName, playerOName)
1.5 – PrintHeader näyttää nykyisen pelaajan nimen + symbolin
1.5 – PrintWinner näyttää voittajan nimen
1.5 – Vuorojen laskenta: TurnCount kasvaa jokaisesta siirrosta, nollautuu uudessa pelissä
1.5 – Ohjelman kulku: tallennetaan tulos voiton/tasapelin jälkeen, V-näppäin näyttää aiemmat tulokset
1.5 – Nykyiset kontrollit säilyvät: ENTER = aseta, R = uusi peli, ESC = lopeta

---

## Tulevat parannukset (valinnainen)
- Peli yksinpeliä vastaan (AI)  
- Parempi graafinen esitys (ASCII / Console art)

---

## Yhteenveto
Tämä projekti on valmis **näytettäväksi kouluprojektina** tai Git-portfolioon.  
Se demonstroi selkeästi:  

- Olio-ohjelmointia ja metodien käyttöä  
- Konsoli-IO:n hallintaa  
- Pelin logiikan suunnittelua  
- Käyttäjäystävällisen, värillisen konsolinäkymän toteuttamista  
- Boolean-arvojen hyödyntämistä pelin tilan hallinnassa  
