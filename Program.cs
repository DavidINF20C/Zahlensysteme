using System;
using System.Linq;

namespace Zahlensysteme_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            string ausgangsZahl; //Hier wird die Zahl eingelesen
            string weiterBerechnenStr; // Dieser String wird für die Weiterberechnung benötigt
            string ergebnis;
            string[] binArray = new string[] { "bin", "binär", "Binär", "Bin", "2", "b" }; ; //Diese Arrays sind dazu da, damit man verschiedenen Text eingeben kann, zur einfacheren Bedienung
            string[] oktArray = new string[] { "okt", "oktal", "Oktal", "Okt", "8", "o" }; ;
            string[] dezArray = new string[] { "dez", "dezimal", "Dezimal", "Dez", "10", "d" }; ;
            string[] hexArray = new string[] { "hex", "hexadezimal", "Hexadezimal", "Hex", "16", "h" }; //Diese Arrays sind dazu da, damit man verschiedenen Text eingeben kann, zur einfacheren Bedienung
            int ursprungsZahlensystem = 0; //Dieser Integer wird für die Berechnung benötigt
            int zielZahlensystem = 0; //Dieser Integer wird für die Berechnung benötigt
            int zwischenErgebnis; // Dieser Integer gibt das Ergebnis aus
            bool gleichesZahlensystem = true; //Dieser Bool wird benötigt damit man nicht ins gleiche Zahlensystem zurückrechnen kann
            bool weiterBerechnen; // Dieser Boolean zeigt an ob man abbrechen will oder weitermachen.


            Console.WriteLine("Willkommen zur Umrechnung verschiedener Zahlensysteme!");
            do
            {
                ausgangsZahl = Zahlabfrage(); //Die Methode wird verwendet zum Zahl einlesen.
                do
                {
                    ursprungsZahlensystem = Ursprungeinlesen(ausgangsZahl); // Diese Methode liest das Zahlensystem ein

                    zielZahlensystem = Zieleinlesen(); //Diese Methode liest das Ziel ein

                    if (zielZahlensystem == ursprungsZahlensystem) //Hier eine Schleife damit man nicht fälschlicherweise das gleiche Umrechnet
                    {
                        Console.WriteLine("Man kann nicht ins gleiche Zahlensystem umrechnen.");
                        gleichesZahlensystem = true;
                    }
                    else if (zielZahlensystem != ursprungsZahlensystem)
                    {
                        gleichesZahlensystem = false;
                    }
                } while (gleichesZahlensystem);


                //Die Berechnung wird ausgeführt


                if (zielZahlensystem == 10)//Falls eine Berechnung ins Dezimalsystem durchgeführt wird
                {
                    zwischenErgebnis = Convert.ToInt32(ausgangsZahl, ursprungsZahlensystem);
                    ergebnis = Convert.ToString(zwischenErgebnis);
                }
                else if (ursprungsZahlensystem == 10)//Falls eine Berechnung vom Dezimalsystem durchgeführt wird
                {
                    zwischenErgebnis = Convert.ToInt32(DivisionsRest(ausgangsZahl, zielZahlensystem));
                    ergebnis = Convert.ToString(zwischenErgebnis);

                }
                else //Für die Berechnung aller anderen Zahlensysteme
                {

                    zwischenErgebnis = Convert.ToInt32(ausgangsZahl, ursprungsZahlensystem);
                    ergebnis = Convert.ToString(zwischenErgebnis);
                    ergebnis = DivisionsRest(ergebnis, zielZahlensystem);
                }

                //Hier wird das Restultat ausgegeben
                Console.WriteLine($"Die Ausgangszahl ist {ausgangsZahl}, das Ursprungszahlensystem war {ursprungsZahlensystem}, das Zielzahlensystem ist {zielZahlensystem}, und schlussendlich das Ergebnis: \n{ergebnis}");
                Console.WriteLine("schreiben sie j für weitermachen");
                weiterBerechnenStr = Console.ReadLine();
                if (weiterBerechnenStr == "j")
                {
                    weiterBerechnen = true;
                }
                else
                {
                    weiterBerechnen = false;
                }
            } while (weiterBerechnen);
        }
        //Bei dieser Methode wird die Zahl eingelesen, und auch gleich Kontrolliert
        public static string Zahlabfrage()
        {
            string ausgangsZahl = "0";
            bool nummerntest;
            do
            {
                try
                {
                    Console.WriteLine("Bitte geben sie eine Zahl ein:");
                    ausgangsZahl = Console.ReadLine();
                }
                catch (Exception)
                {

                    Console.WriteLine("Da hat etwas nicht geklappt"); ;
                }
                nummerntest = NummernTest(ausgangsZahl, 'F');

                if (ausgangsZahl == "0")
                {
                    Console.WriteLine("Die Zahl 0 kann nicht umgerechent werden");
                }
                else if (nummerntest == false)
                {
                    Console.WriteLine("Die Eingabe ist keine gültige Zahl");
                }


            } while (ausgangsZahl == "0" || nummerntest == false);
            return ausgangsZahl;
        }

        //Bei dieser Methode wird getestet ob das Zahlensystem stimmen kann.
        public static bool NummernTest(string ausgangsZahl, char ursprungsZSystem)

        {
            char[] ausgangArray;
            bool Nummerntest = true;
            ausgangsZahl = ausgangsZahl.ToUpper();

            ausgangArray = ausgangsZahl.ToCharArray();

            for (int i = 0; i < ausgangsZahl.Length; i++)
            {
                if (ausgangArray[i] > ursprungsZSystem)
                {
                    Nummerntest = false;
                }
                else
                {
                    Nummerntest = true;
                }
            }
            return Nummerntest;

        }
        //Bei dieser Methode wird das Zahlensystem eingelesen, und auch gleich kontrolliert
        public static int Ursprungeinlesen(string ausgangsZahl)
        {
            string eingabeUrsprungsZahlensystem;
            int ursprungsZahlensystem = 0;
            char ursprungsZSystem = '0';
            bool nummernTest = true;
            string[] binArray = new string[] { "bin", "binär", "Binär", "Bin", "2", "b" }; ;
            string[] oktArray = new string[] { "okt", "oktal", "Oktal", "Okt", "8", "o" }; ;
            string[] dezArray = new string[] { "dez", "dezimal", "Dezimal", "Dez", "10", "d" }; ;
            string[] hexArray = new string[] { "hex", "hexadezimal", "Hexadezimal", "Hex", "16", "h" };
            do
            {
                try
                {
                    Console.WriteLine("Bitte geben sie das Ursprungs-Zahlensystem ein: binär, oktal, dezimal, hexadezimal");
                    eingabeUrsprungsZahlensystem = Console.ReadLine();
                    if (binArray.Contains(eingabeUrsprungsZahlensystem))
                    {
                        ursprungsZahlensystem = 2;
                        ursprungsZSystem = '2';

                    }
                    else if (oktArray.Contains(eingabeUrsprungsZahlensystem))
                    {
                        ursprungsZahlensystem = 8;
                        ursprungsZSystem = '8';
                    }
                    else if (dezArray.Contains(eingabeUrsprungsZahlensystem))
                    {
                        ursprungsZahlensystem = 10;
                        ursprungsZSystem = 'A';
                    }
                    else if (hexArray.Contains(eingabeUrsprungsZahlensystem))
                    {
                        ursprungsZahlensystem = 16;
                        ursprungsZSystem = 'F';
                    }
                    else
                    {
                        Console.WriteLine("Eingabe Ungültig");
                    }
                    nummernTest = NummernTest(ausgangsZahl, ursprungsZSystem);
                    if (nummernTest == false)
                    {
                        Console.WriteLine("Das Zahlensystem stimmt nicht überein!");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Da hat etwas nicht geklappt");
                    nummernTest = false;
                }
            } while (ursprungsZahlensystem == 0 || nummernTest == false);
            return ursprungsZahlensystem;
        }
        //Diese Methode Liest das Ziel Zahlensystem ein
        public static int Zieleinlesen()
        {
            string eingabeZielZahlensystem;
            int zielZahlensystem = 0;
            string[] binArray = new string[] { "bin", "binär", "Binär", "Bin", "2", "b" }; ;
            string[] oktArray = new string[] { "okt", "oktal", "Oktal", "Okt", "8", "o" }; ;
            string[] dezArray = new string[] { "dez", "dezimal", "Dezimal", "Dez", "10", "d" }; ;
            string[] hexArray = new string[] { "hex", "hexadezimal", "Hexadezimal", "Hex", "16", "h" };
            do
            {
                try
                {


                    Console.WriteLine("Bitte geben sie das Ziel-Zahlensystem ein: binär, oktal, dezimal, hexadezimal");
                    eingabeZielZahlensystem = Console.ReadLine();
                    if (binArray.Contains(eingabeZielZahlensystem))
                    {
                        zielZahlensystem = 2;
                    }
                    else if (oktArray.Contains(eingabeZielZahlensystem))
                    {
                        zielZahlensystem = 8;
                    }
                    else if (dezArray.Contains(eingabeZielZahlensystem))
                    {
                        zielZahlensystem = 10;
                    }
                    else if (hexArray.Contains(eingabeZielZahlensystem))
                    {
                        zielZahlensystem = 16;
                    }
                    else
                    {
                        Console.WriteLine("Eingabe Ungültig");
                    }
                }
                catch (Exception)
                {
                    zielZahlensystem = 0;
                    Console.WriteLine("Da hat etwas nicht geklappt");
                }
            } while (zielZahlensystem == 0);
            return zielZahlensystem;
        }
        //Diese Methode berechnet das ergebnis, falls das Ziel nicht Dezimal ist
        public static string DivisionsRest(string ausgangsZahl, int zielZahlensystem)
        {
            int rest;
            int zahlNeu = 0;
            string ergebnis2 = "";
            string restString = "";
            int ausgangsInt;
            ausgangsInt = Convert.ToInt32(ausgangsZahl);

            do
            {
                try
                {
                    rest = ausgangsInt % zielZahlensystem;
                    if (rest > 9)
                    {
                        restString = Convert.ToString(Convert.ToChar(rest + 55));
                        ergebnis2 = Convert.ToString(restString + ergebnis2);
                    }
                    else if (rest <= 9)
                    {
                        ergebnis2 = Convert.ToString(rest + ergebnis2);
                    }
                    zahlNeu = ausgangsInt / zielZahlensystem;
                    ausgangsInt = zahlNeu;
                }
                catch (Exception)
                {
                    zahlNeu = 0;
                    Console.WriteLine("Da hat etwas nicht geklappt");
                }

            } while (zahlNeu != 0);
            return ergebnis2;
        }
    }
}
