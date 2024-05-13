using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_PUJCOVNAAUT
{
    internal class Motorka
    {
        public string VIN { get; set; }
        public string SPZ { get; set; }
        public string Vyrobce { get; set; }
        public string Model { get; set; }
        public int RokVyroby { get; set; }
        public double CenaZaDen { get; set; }
        public double Tachometr { get; set; }
        public bool Dostupnost { get; set; }

        public Motorka(string vin, string spz, string vyrobce, string model, int rokVyroby, double cenaZaDen, double tachometr, bool dostupnost) //konstruktor
        {
            VIN = vin;
            SPZ = spz;
            Vyrobce = vyrobce;
            Model = model;
            RokVyroby = rokVyroby;
            CenaZaDen = cenaZaDen;
            Tachometr = tachometr;
            Dostupnost = dostupnost;
        }
        public void VypisInfo()
        {
            Console.WriteLine($"VIN: {VIN}");
            Console.WriteLine($"SPZ: {SPZ}");
            Console.WriteLine($"Výrobce: {Vyrobce}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Rok výroby: {RokVyroby}");
            Console.WriteLine($"Cena za den: {CenaZaDen}");
            Console.WriteLine($"Tachometr: {Tachometr}");
            Console.Write("Dostupnost: ");
            if (Dostupnost == false) //rozlišování jestli je motorka dostupná
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Nedostupné");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Dostupné");
            }

            Console.ResetColor();
        }
    }

}
