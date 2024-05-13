using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PROJEKT_PUJCOVNAAUT
{
    internal class Pujcka
    {
        public Zakaznik Zakaznik;
        public DateTime DatumPujceni;
        public DateTime DatumVraceni;
        public bool Vraceno;
        public double Cena;
        public Auto Auto;
        public Motorka Motorka;

        public Pujcka(DateTime datumPujceni, DateTime datumVraceni, bool vraceno, double cena, Auto auto, Zakaznik zakaznik, Motorka motorka) //konstruktor
        {
            DatumPujceni = datumPujceni;
            DatumVraceni = datumVraceni;
            Vraceno = vraceno;
            Cena = cena;
            Zakaznik = zakaznik;
            Auto = auto;
            Motorka = motorka;
        }
        public void VypsatPujcku()
        {
            Console.WriteLine($"Zákazník: {Zakaznik.Jmeno}, {Zakaznik.Prijmeni}, ID: {Zakaznik.ID}, Oprávnění: {Zakaznik.Opravneni}");
            if (Motorka == null)
                Console.WriteLine($"Auto: {Auto.Vyrobce}, {Auto.Model}, SPZ: {Auto.SPZ}, VIN: {Auto.VIN}");
            else if (Auto == null)
                Console.WriteLine($"Motorka: {Motorka.Vyrobce}, {Motorka.Model}, SPZ: {Motorka.SPZ}, VIN: {Motorka.VIN}");
            if (Vraceno == true) //rozlišování jestli je půjčka aktivní nebo ne
            {
                Console.Write($"Datum vrácení: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{DatumVraceni.Day}.{DatumVraceni.Month}.{DatumVraceni.Year}");
                Console.ResetColor();
                Console.WriteLine($"\nZaplaceno: {Math.Round(Cena, 2)}");
            }
            else
            {
                Console.Write($"Datum vrácení: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Vozidlo nebylo vráceno");
                Console.ResetColor();
                Console.WriteLine($"\nK zaplacení: {Math.Round(Cena, 2)}");
            }
            

        }
    }
}

