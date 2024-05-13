using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_PUJCOVNAAUT
{
    internal class Zakaznik
    {
        public int ID;
        public string Jmeno;
        public string Prijmeni;
        public DateTime DatumNarozeni;
        public string Email;
        public int TelefonniCislo;
        public string Opravneni;
        public Auto Auto;

        public Zakaznik(int id, string jmeno, string prijmeni, DateTime datumNarozeni, string email, int telefonniCislo, string opravneni)
        {
            ID = id;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datumNarozeni;
            Email = email;
            TelefonniCislo = telefonniCislo;
            Opravneni = opravneni;
        }

        public void VypisInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Jméno: {Jmeno}");
            Console.WriteLine($"Přijmení: {Prijmeni}");
            Console.WriteLine($"Datum narození: {DatumNarozeni.Day}.{DatumNarozeni.Month}.{DatumNarozeni.Year}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Telefonní číslo: {TelefonniCislo}");
            Console.WriteLine($"Oprávnění: {Opravneni}");
        }
    }
}
