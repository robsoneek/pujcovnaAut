using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PROJEKT_PUJCOVNAAUT
{
    internal class Pujcovna
    {
        private List<Auto> auta;
        private List<Zakaznik> zakaznici;
        private List<Pujcka> pujcky;
        private List<Motorka> motorky;
        private List<Pujcka> starePujcky;

        public Pujcovna()
        {
            auta = new List<Auto>();
            zakaznici = new List<Zakaznik>();
            pujcky = new List<Pujcka>();
            motorky = new List<Motorka>();
            starePujcky = new List<Pujcka>();
        }

        public void PridatVozidlo() //metoda na pridani vozidla, auta/motorky
        {
            Console.Clear();
            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Motorka");
            Console.Write("Výběr: ");
            int vyber;
            while (!int.TryParse(Console.ReadLine(), out vyber)) // ošetření vstupu
            {
                Console.WriteLine("Špatně zadané číslo!");
                Thread.Sleep(300); //zastavení programu na určitý čas místo Console.ReadKey
                Console.Write("Výběr: ");
            }
            if (vyber == 1)
            {
                Console.Clear();
                Console.Write("VIN: ");
                string vin = Console.ReadLine();
                while (vin.Length != 17)
                {
                    Console.WriteLine("Špatně zadaný VIN!");
                    Thread.Sleep(300);
                    Console.Write("VIN: ");
                    vin = Console.ReadLine();
                }
                Console.Write("SPZ: ");
                string spz = Console.ReadLine();
                while (spz.Length != 7)
                {
                    Console.WriteLine("Špatně zadaná SPZ!");
                    Thread.Sleep(300);
                    Console.Write("SPZ: ");
                    spz = Console.ReadLine();
                }
                Console.Write("Výrobce: ");
                string vyrobce = Console.ReadLine();
                Console.Write("Model: ");
                string model = Console.ReadLine();
                Console.Write("Počet míst: ");
                int pocetMist;
                while (!int.TryParse(Console.ReadLine(), out pocetMist))
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(300);
                    Console.Write("Počet míst: ");
                }
                Console.Write("Rok výroby: ");
                int rokVyroby = int.Parse(Console.ReadLine());
                while (rokVyroby > DateTime.Now.Year)
                {
                    Console.WriteLine("Špatně zadaný rok výroby!");
                    Thread.Sleep(300);
                    Console.Write("Rok výroby: ");
                    rokVyroby = int.Parse(Console.ReadLine());
                }
                Console.Write("Cena za den: ");
                double cenaZaDen = double.Parse(Console.ReadLine());
                Console.Write("Tachometr: ");
                double tachometr = double.Parse(Console.ReadLine());

                Auto auto = new Auto(vin, spz, vyrobce, model, rokVyroby, cenaZaDen, tachometr, pocetMist, true);
                auta.Add(auto);
            } else if (vyber == 2)
            {
                Console.Clear();
                Console.Write("VIN: ");
                string vin = Console.ReadLine();
                while (vin.Length != 17)
                {
                    Console.WriteLine("Špatně zadaný VIN!");
                    Thread.Sleep(300);
                    Console.Write("VIN: ");
                    vin = Console.ReadLine();
                }
                Console.Write("SPZ: ");
                string spz = Console.ReadLine();
                while (spz.Length != 7)
                {
                    Console.WriteLine("Špatně zadaná SPZ!");
                    Thread.Sleep(300);
                    Console.Write("SPZ: ");
                    spz = Console.ReadLine();
                }
                Console.Write("Výrobce: ");
                string vyrobce = Console.ReadLine();
                Console.Write("Model: ");
                string model = Console.ReadLine();
                Console.Write("Rok výroby: ");
                int rokVyroby = int.Parse(Console.ReadLine());
                while (rokVyroby > DateTime.Now.Year)
                {
                    Console.WriteLine("Špatně zadaný rok výroby!");
                    Thread.Sleep(300);
                    Console.Write("Rok výroby: ");
                    rokVyroby = int.Parse(Console.ReadLine());
                }
                Console.Write("Cena za den: ");
                double cenaZaDen = double.Parse(Console.ReadLine());
                Console.Write("Tachometr: ");
                double tachometr = double.Parse(Console.ReadLine());

                Motorka motorka = new Motorka(vin, spz, vyrobce, model, rokVyroby, cenaZaDen, tachometr, true);
                motorky.Add(motorka);

            }
            Thread.Sleep(500);
        }

        public void OdebratVozidlo()
        {
            Console.Clear();
            if (auta.Count == 0 && motorky.Count == 0) //pokud neexistuje ani jedno vozidlo
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Není registrované žádné vozidlo");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Motorka");
            Console.Write("Výběr: ");
            int vyber;
            while (!int.TryParse(Console.ReadLine(), out vyber))
            {
                Console.WriteLine("Špatně zadané číslo!");
                Thread.Sleep(300);
                Console.Write("Výběr: ");
            }
            if (vyber == 1) //výber aut
            {
                for (int i = 0; i < auta.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {auta[i].Vyrobce} {auta[i].Model}, {auta[i].RokVyroby}");
                }
                Console.Write("Jaké auto si přejete odebrat?: ");
                int input = int.Parse(Console.ReadLine()) - 1;
                auta.RemoveAt(input);
            } else if (vyber == 2) //výběr motorek
            {
                for (int i = 0; i < motorky.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {motorky[i].Vyrobce} {motorky[i].Model}, {motorky[i].RokVyroby}");
                }
                Console.Write("Jakou motorku si přejete odebrat?: ");
                int input = int.Parse(Console.ReadLine()) - 1;
                motorky.RemoveAt(input);
            }
            Thread.Sleep(300);
        }

        public void UpravitVozidlo() //upravování jednotlivých informací u vozidla
        {
            Console.Clear();

            if (auta.Count == 0 && motorky.Count == 0) //pokud neexistuje ani jedno vozidlo
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Není registrované žádné vozidlo");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }

            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Motorka");
            Console.Write("Výběr: ");
            int vyber;
            while (!int.TryParse(Console.ReadLine(), out vyber))
            {
                Console.WriteLine("Špatně zadané číslo!");
                Thread.Sleep(300);
                Console.Write("Výběr: ");
            }

            if (vyber == 1)
            {
                for (int i = 0; i < auta.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {auta[i].Vyrobce} {auta[i].Model}, {auta[i].RokVyroby}");
                }

                Console.Write("Jaké auto si přejete upravit?: ");
                int index = int.Parse(Console.ReadLine());
                Auto auto = auta[index - 1];
                Thread.Sleep(400);

                Console.Clear();

                Console.WriteLine($"Výrobce: {auto.Vyrobce}");
                Console.Write("Chcete změnit? y/n: ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.Write("Nový výrobce: ");
                    auto.Vyrobce = Console.ReadLine();

                }
                Thread.Sleep(200);

                Console.Clear();

                Console.WriteLine($"Model: {auto.Model}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.Write("Nový model: ");
                    auto.Model = Console.ReadLine();
                }
                Thread.Sleep(200);

                Console.Clear();

                Console.WriteLine($"Počet míst: {auto.PocetMist}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    int pocetMist;
                    Console.Write("Počet míst: ");
                    while (!int.TryParse(Console.ReadLine(), out pocetMist))
                    {
                        Console.WriteLine("Špatně zadané číslo!");
                        Thread.Sleep(300);
                        Console.Write("Počet míst: ");
                    }

                    auto.PocetMist = pocetMist;
                }

                Console.Clear();

                Console.WriteLine($"Rok výroby: {auto.RokVyroby}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    int rokVyroby;
                    Console.Write("Rok výroby: ");
                    while (!int.TryParse(Console.ReadLine(), out rokVyroby))
                    {
                        Console.WriteLine("Špatně zadaný rok výroby!");
                        Thread.Sleep(300);
                        Console.Write("Rok výroby: ");
                    }
                    while (rokVyroby > DateTime.Now.Year)
                    {
                        Console.WriteLine("Špatně zadaný rok výroby!");
                        Thread.Sleep(300);
                        Console.Write("Rok výroby: ");
                        while (!int.TryParse(Console.ReadLine(), out rokVyroby))
                        {
                            Console.WriteLine("Špatně zadaný rok výroby!");
                            Thread.Sleep(300);
                            Console.Write("Rok výroby: ");
                        }
                    }

                    auto.RokVyroby = rokVyroby;
                }
                Thread.Sleep(200);

                Console.Clear();

                Console.WriteLine($"Cena za den: {auto.CenaZaDen}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    int cenaZaDen;
                    Console.Write("Nová cena za den: ");
                    while (!int.TryParse(Console.ReadLine(), out cenaZaDen))
                    {
                        Console.WriteLine("Špatně zadaná cena!");
                        Thread.Sleep(300);
                        Console.Write("Cena za den: ");
                    }

                    auto.CenaZaDen = cenaZaDen;
                }

                Console.Clear();

                Console.WriteLine($"Tachometr: {auto.Tachometr}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    double tachometr;
                    Console.Write("Nový stav tachometru: ");
                    while (!double.TryParse(Console.ReadLine(), out tachometr))
                    {
                        Console.WriteLine("Špatně zadané číslo!");
                        Thread.Sleep(300);
                        Console.Write("Tachometr: ");
                    }

                    auto.Tachometr = tachometr;
                }

            }
            else if (vyber == 2)
            {
                for (int i = 0; i < auta.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {motorky[i].Vyrobce} {motorky[i].Model}, {motorky[i].RokVyroby}");
                }

                Console.Write("Jakou motorku si přejete upravit?: ");
                int index = int.Parse(Console.ReadLine());
                Motorka motorka = motorky[index - 1];
                Thread.Sleep(400);

                Console.Clear();

                Console.WriteLine($"Výrobce: {motorka.Vyrobce}");
                Console.Write("Chcete změnit? y/n: ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.Write("Nový výrobce: ");
                    motorka.Vyrobce = Console.ReadLine();

                }
                Thread.Sleep(200);

                Console.Clear();

                Console.WriteLine($"Model: {motorka.Model}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    Console.Write("Nový model: ");
                    motorka.Model = Console.ReadLine();
                }
                Thread.Sleep(200);

                Console.Clear();

                Console.WriteLine($"Rok výroby: {motorka.RokVyroby}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    int rokVyroby;
                    Console.Write("Rok výroby: ");
                    while (!int.TryParse(Console.ReadLine(), out rokVyroby))
                    {
                        Console.WriteLine("Špatně zadaný rok výroby!");
                        Thread.Sleep(300);
                        Console.Write("Rok výroby: ");
                    }
                    while (rokVyroby > DateTime.Now.Year)
                    {
                        Console.WriteLine("Špatně zadaný rok výroby!");
                        Thread.Sleep(300);
                        Console.Write("Rok výroby: ");
                        while (!int.TryParse(Console.ReadLine(), out rokVyroby))
                        {
                            Console.WriteLine("Špatně zadaný rok výroby!");
                            Thread.Sleep(300);
                            Console.Write("Rok výroby: ");
                        }
                    }

                    motorka.RokVyroby = rokVyroby;
                }
                Thread.Sleep(200);

                Console.Clear();

                Console.WriteLine($"Cena za den: {motorka.CenaZaDen}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    int cenaZaDen;
                    Console.Write("Nová cena za den: ");
                    while (!int.TryParse(Console.ReadLine(), out cenaZaDen))
                    {
                        Console.WriteLine("Špatně zadaná cena!");
                        Thread.Sleep(300);
                        Console.Write("Cena za den: ");
                    }

                    motorka.CenaZaDen = cenaZaDen;
                }

                Console.Clear();

                Console.WriteLine($"Tachometr: {motorka.Tachometr}");
                Console.Write("Chcete změnit? y/n: ");
                input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    double tachometr;
                    Console.Write("Nový stav tachometru: ");
                    while (!double.TryParse(Console.ReadLine(), out tachometr))
                    {
                        Console.WriteLine("Špatně zadané číslo!");
                        Thread.Sleep(300);
                        Console.Write("Tachometr: ");
                    }

                    motorka.Tachometr = tachometr;
                }
            }
        }

        public void VypisVozidel() //vypsání všech vozidel
        {
            Console.Clear();
            if (auta.Count == 0 && motorky.Count == 0) //když neexistuje žádné vozidlo
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Není registrované žádné vozidlo");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            else if (motorky.Count == 0 && auta.Count != 0) //existuje min. jedno auto
            {
                foreach (Auto auto in auta)
                {
                    auto.VypisInfo();
                    Console.WriteLine("\n");
                }
            }
            else if (auta.Count == 0 && motorky.Count != 0) //existuje min. jedna motorka
            {

                foreach (Motorka motorka in motorky)
                {
                    motorka.VypisInfo();
                    Console.WriteLine("\n");
                }
            }
            else
            {
                Console.WriteLine("Auta:");
                foreach (Auto auto in auta)
                {
                    auto.VypisInfo();
                    Console.WriteLine("\n");
                }
                Console.WriteLine("Motorky:");
                foreach (Motorka motorka in motorky)
                {
                    motorka.VypisInfo();
                    Console.WriteLine("\n");
                }
            }

            Console.Write("\nZmáčkněte libovolnou klávesu pro pokračování...");
            Console.ReadKey(true);
        }

        public void RegistrovatZakaznika()
        {
            Console.Clear();
            Random random = new Random();
            int id = random.Next(1, 1001); // pouziti randomu na vygenerovani ID

            for (int i = 0; i < zakaznici.Count; i++)
            {
                while (zakaznici[i].ID == id)
                {
                    id = random.Next(1, 1001);
                }
            }

            Console.WriteLine("ID: " + id);
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();
            Console.Write("Přijmení: ");
            string prijmeni = Console.ReadLine();
            Console.WriteLine("Datum narození (dd/mm/yyyy): ");
            int den = 0;
            int mesic = 0;
            int rok = 0;
            string[] parts;
            while (true)
            {
                string datum1 = Console.ReadLine();
                parts = datum1.Split('.'); //splituju string aby se rozdelil na casti pole a k jednotlivym indexum priradim den, mesic a rok


                if (parts.Length == 3 && int.Parse(parts[2]) <= DateTime.Now.Year - 15 && int.Parse(parts[2]) >= DateTime.Now.Year - 100 && int.Parse(parts[0]) > 0 && int.Parse(parts[0]) <= 31 && int.Parse(parts[1]) > 0 && int.Parse(parts[1]) <= 12)
                {
                    den = int.Parse(parts[0]);
                    mesic = int.Parse(parts[1]);
                    rok = int.Parse(parts[2]);
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Neplatné datum");
                    Thread.Sleep(500);
                    Console.ResetColor();
                    Console.Clear();
                    Console.WriteLine("Datum narození (dd/mm/yyyy): ");
                }
            }
            DateTime datumNarozeni = new DateTime(rok, mesic, den);
            datumNarozeni = datumNarozeni.Date;
            Console.Write("Email: ");
            string email;
            string emailZacatek;
            string emailKoncovka;
            while (true)
            {
                email = Console.ReadLine();
                parts = email.Split('@');
                if (parts.Length == 2)
                {
                    emailZacatek = parts[0];
                    emailKoncovka = parts[1];
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Neplatný email");
                    Thread.Sleep(500);
                    Console.ResetColor();
                    Console.WriteLine("Email: ");
                }
            }
            Console.Write("Telefonní číslo: ");
            int telefonniCislo;
            while (true) //kontrolování délky telefonního čísla
            {
                if (!int.TryParse(Console.ReadLine(), out telefonniCislo))
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(300);
                    Console.Write("Telefonní číslo: ");
                }

                else if (telefonniCislo.ToString().Length != 9)
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(300);
                    Console.Write("Telefonní číslo: ");
                }
                else if (telefonniCislo.ToString().Length == 9)
                    break;
            }

            string opravneni;
            if (DateTime.Now.Year - rok >= 18)
                opravneni = "B";
            else
                opravneni = "A";
            // B = auto a motorka, A = motorka

            Zakaznik zakaznik = new Zakaznik(id, jmeno, prijmeni, datumNarozeni, email, telefonniCislo, opravneni);

            zakaznici.Add(zakaznik);
        }

        public void OdebratZakaznika()
        {
            Console.Clear();
            if (zakaznici.Count == 0) //když neexistuje zákazník
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Není registrovaný žádný zákazník");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }

            for (int i = 0; i < zakaznici.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {zakaznici[i].ID}, {zakaznici[i].Jmeno}, {zakaznici[i].Prijmeni}");
            }
            Console.Write("Koho si přejete odebrat? ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Špatně zadané číslo");
                Thread.Sleep(300);
                Console.Write("Koho si přejete odebrat? ");
            }
            zakaznici.RemoveAt(index - 1);
            Console.Clear();
            Thread.Sleep(300);
        }

        public void VypisZakazniku() //vypsání všech zákazníků
        {
            Console.Clear();
            if (zakaznici.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Není registrovaný žádný zákazník");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            foreach (Zakaznik zakaznik in zakaznici)
            {
                zakaznik.VypisInfo(); ;
                Console.WriteLine();
            }
            Console.Write("\nZmáčkněte libovolnou klávesu pro pokračování...");
            Console.ReadKey(true);
        }

        public void UpravitZakaznika() //upravení jednotlivých informací o zákazníkovi
        {
            Console.Clear();
            if (zakaznici.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Není registrovaný žádný zákazník");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            for (int i = 0; i < zakaznici.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {zakaznici[i].ID}, Jméno: {zakaznici[i].Jmeno}, Přijmení: {zakaznici[i].Prijmeni}");
            }
            Console.Write("Koho chcete upravit? ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index))
            {
                Console.WriteLine("Špatně zadané číslo");
                Thread.Sleep(300);
                Console.Write("Koho chcete upravit? ");
            }

            Zakaznik zakaznik = zakaznici[index - 1];
            Console.Clear();

            Console.WriteLine($"Jméno: {zakaznik.Jmeno}");
            Console.Write("Chcete změnit? y/n: ");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Console.Write("Nové jméno: ");
                zakaznik.Jmeno = Console.ReadLine();
            }

            Console.Clear();

            Console.WriteLine($"Přijmení: {zakaznik.Prijmeni}");
            Console.Write("Chcete změnit? y/n: ");
            input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                Console.Write("Nové přijmení: ");
                zakaznik.Prijmeni = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"Datum narození: {zakaznik.DatumNarozeni.Day}.{zakaznik.DatumNarozeni.Month}.{zakaznik.DatumNarozeni.Year}");
            Console.Write("Chcete změnit? y/n: ");
            input = Console.ReadLine().ToLower();
            int den = 0;
            int mesic = 0;
            int rok = 0;
            string[] parts;
            if (input == "y")
            {
                Console.Clear();
                Console.WriteLine("Nové datum narození (dd/mm/yyyy): ");

                while (true)
                {
                    string datum1 = Console.ReadLine();
                    parts = datum1.Split('.');

                    den = int.Parse(parts[0]);
                    mesic = int.Parse(parts[1]);
                    rok = int.Parse(parts[2]);
                    if (parts.Length == 3 && rok <= DateTime.Now.Year - 15 && rok >= DateTime.Now.Year - 100 && den > 0 && den < 31 && mesic > 0 && mesic < 12)
                        break;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Neplatné datum");
                        Thread.Sleep(500);
                        Console.ResetColor();
                        Console.Clear();
                        Console.WriteLine("Nové datum narození (dd/mm/yyyy): ");
                    }
                }
                DateTime datumNarozeni = new DateTime(rok, mesic, den);
                zakaznik.DatumNarozeni = datumNarozeni;

                if (DateTime.Now.Year - rok >= 18)
                    zakaznik.Opravneni = "B";
                else
                    zakaznik.Opravneni = "A";
            }
        }




        public void UlozitDoSouboru(string filePath) //ukládání do souboru pomocí SteamWriter
        {
            using StreamWriter writer = new StreamWriter(filePath);
            {
                writer.WriteLine("Auta:");
                foreach (Auto auto in auta)
                {
                    writer.WriteLine($"{auto.VIN};{auto.SPZ};{auto.Vyrobce};{auto.Model};{auto.PocetMist};{auto.RokVyroby};{auto.CenaZaDen};{auto.Tachometr};{auto.Dostupnost}");
                }

                writer.WriteLine("Zákazníci: ");
                foreach (Zakaznik zakaznik in zakaznici)
                {
                    writer.WriteLine($"{zakaznik.ID};{zakaznik.Jmeno};{zakaznik.Prijmeni};{zakaznik.DatumNarozeni};{zakaznik.Email};{zakaznik.TelefonniCislo};{zakaznik.Opravneni}");
                }

                writer.WriteLine("Aktivní půjčky: ");
                foreach (Pujcka pujcka in pujcky)
                {
                    if (pujcka.Auto != null && pujcka.Motorka == null)
                        writer.WriteLine($"{pujcka.Zakaznik.Jmeno};{pujcka.Zakaznik.Prijmeni};{pujcka.Zakaznik.ID};{pujcka.Zakaznik.Opravneni};{pujcka.Auto.Vyrobce};{pujcka.Auto.Model};{pujcka.Auto.SPZ};{pujcka.Auto.VIN};{pujcka.Auto.Tachometr};{pujcka.DatumPujceni};{pujcka.DatumVraceni};{pujcka.Vraceno};{pujcka.Cena};auto");
                    else if (pujcka.Auto == null && pujcka.Motorka != null)
                        writer.WriteLine($"{pujcka.Zakaznik.Jmeno};{pujcka.Zakaznik.Prijmeni};{pujcka.Zakaznik.ID};{pujcka.Zakaznik.Opravneni};{pujcka.Motorka.Vyrobce};{pujcka.Motorka.Model};{pujcka.Motorka.SPZ};{pujcka.Motorka.VIN};{pujcka.Motorka.Tachometr};{pujcka.DatumPujceni};{pujcka.DatumVraceni};{pujcka.Vraceno};{pujcka.Cena};motorka");
                }

                writer.WriteLine("Staré půjčky: ");
                foreach (Pujcka pujcka in starePujcky)
                {
                    if (pujcka.Auto != null && pujcka.Motorka == null)
                        writer.WriteLine($"{pujcka.Zakaznik.Jmeno};{pujcka.Zakaznik.Prijmeni};{pujcka.Zakaznik.ID};{pujcka.Zakaznik.Opravneni};{pujcka.Auto.Vyrobce};{pujcka.Auto.Model};{pujcka.Auto.SPZ};{pujcka.Auto.VIN};{pujcka.Auto.Tachometr};{pujcka.DatumPujceni};{pujcka.DatumVraceni};{pujcka.Vraceno};{pujcka.Cena};auto");
                    else if (pujcka.Auto == null && pujcka.Motorka != null)
                        writer.WriteLine($"{pujcka.Zakaznik.Jmeno};{pujcka.Zakaznik.Prijmeni};{pujcka.Zakaznik.ID};{pujcka.Zakaznik.Opravneni};{pujcka.Motorka.Vyrobce};{pujcka.Motorka.Model};{pujcka.Motorka.SPZ};{pujcka.Motorka.VIN};{pujcka.Motorka.Tachometr};{pujcka.DatumPujceni};{pujcka.DatumVraceni};{pujcka.Vraceno};{pujcka.Cena};motorka");
                }
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Data byla úspěšně uložena");
            Console.ResetColor();
            Thread.Sleep(800);
        }

        public void NacistZeSouboru(string filePath) //načítání ze souboru
        {
            Console.Clear();
            if (File.Exists(filePath))
            {
                auta.Clear();
                zakaznici.Clear();
                using StreamReader reader = new StreamReader(filePath);
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length == 9)
                        {
                            string vin = parts[0];
                            string spz = parts[1];
                            string vyrobce = parts[2];
                            string model = parts[3];
                            int pocetMist = int.Parse(parts[4]);
                            int rokVyroby = int.Parse(parts[5]);
                            double cenaZaDen = double.Parse(parts[6]);
                            double tachometr = double.Parse(parts[7]);
                            bool dostupnost = bool.Parse(parts[8]);

                            Auto auto = new Auto(vin, spz, vyrobce, model, rokVyroby, cenaZaDen, tachometr, pocetMist, dostupnost);
                            auta.Add(auto);
                        }
                        else if (parts.Length == 7)
                        {
                            int id = int.Parse(parts[0]);
                            string jmeno = parts[1];
                            string prijmeni = parts[2];
                            DateTime datumNarozeni = DateTime.Parse(parts[3]);
                            string email = parts[4];
                            int telefonniCislo = int.Parse(parts[5]);
                            string opravneni = parts[6];

                            Zakaznik zakaznik = new Zakaznik(id, jmeno, prijmeni, datumNarozeni, email, telefonniCislo, opravneni);
                            zakaznici.Add(zakaznik);
                        }

                        else if (parts.Length == 14)
                        {
                            string jmeno = parts[0];
                            string prijmeni = parts[1];
                            int id = int.Parse(parts[2]);
                            string opravneni = parts[3];
                            string vyrobce = parts[4];
                            string model = parts[5];
                            string spz = parts[6];
                            string vin = parts[7];
                            int tachometr = int.Parse(parts[8]);
                            DateTime datumPujceni = DateTime.Parse(parts[9]);
                            DateTime datumVraceni = DateTime.Parse(parts[10]);
                            bool vraceno = bool.Parse(parts[11]);
                            double cena = double.Parse(parts[12]);
                            string vozidlo = parts[13];
                            DateTime date = new DateTime();

                            Zakaznik zakaznik = new Zakaznik(id, jmeno, prijmeni, date, null, 0, opravneni);
                            Pujcka pujcka = new Pujcka(datumPujceni, datumVraceni, vraceno, cena, null, zakaznik, null);

                            //rozpoznávání jaké to je vozidlo, pro vytvoření správného objektu
                            if (vozidlo == "auto")
                            {
                                Auto auto = new Auto(vin, spz, vyrobce, model, 0, cena, tachometr, 0, vraceno);
                                pujcka.Auto = auto;
                                pujcka.Motorka = null;
                            }
                            else
                            {
                                Motorka motorka = new Motorka(vin, spz, vyrobce, model, 0, cena, tachometr, vraceno);
                                pujcka.Motorka = motorka;
                                pujcka.Auto = null;
                            }

                            if (vraceno == false)
                                pujcky.Add(pujcka);
                            else
                                starePujcky.Add(pujcka);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Data byla načtena");
                    Console.ResetColor();
                }
            }
            else
                Console.WriteLine("Soubor neexistuje");
            Thread.Sleep(800);
        }

        public void PujceniVozidla() //půjčení vozidla, dostupnost = false
        {
            Console.Clear();
            if (auta.Count == 0 && motorky.Count == 0) //když neexistuje žádné vozidlo
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Není registrováno žádné vozidlo");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            Console.WriteLine("1. Auto");
            Console.WriteLine("2. Motorka");
            Console.Write("Výběr: ");
            int vyber;
            while (!int.TryParse(Console.ReadLine(), out vyber))
            {
                Console.WriteLine("Špatně zadané číslo!");
                Thread.Sleep(300);
                Console.Write("Výběr: ");
            }

            for (int i = 0; i < zakaznici.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID: {zakaznici[i].ID}, Jméno: {zakaznici[i].Jmeno}, Přijmení: {zakaznici[i].Prijmeni}, Oprávnění: {zakaznici[i].Opravneni}");
            }
            Console.Write("Zákazník: ");
            int zakaznikIndex;
            while (!int.TryParse(Console.ReadLine(), out zakaznikIndex))
            {
                Console.WriteLine("Špatně zadané číslo");
                Thread.Sleep(300);
                Console.Write("Zákazník: ");
            }
            Zakaznik zakaznik = zakaznici[zakaznikIndex - 1];
            Console.Clear();
            if (zakaznik.Opravneni == "A" && vyber == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Tento zákazník si může půjčit jen motorku!");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            if (vyber == 1)
            {
                Console.Clear();
                if (auta.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Není registrováno žádné auto");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    return;
                }
                for (int i = 0; i < auta.Count; i++)
                {
                    Console.Write($"{i + 1}. {auta[i].Vyrobce} {auta[i].Model}, {auta[i].RokVyroby}, Dostupnost: ");
                    if (auta[i].Dostupnost == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Nedostupné");
                    }

                    else if (auta[i].Dostupnost == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Dostupné");
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }
                Console.ResetColor();

                Console.WriteLine("\nJaké auto si chcete půjčit? ");
                int index;
                while (!int.TryParse(Console.ReadLine(), out index))
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(300);
                    Console.Write("Jaké auto si chcete půjčit? ");
                }

                Auto auto = auta[index - 1];

                if (auto.Dostupnost == true)
                {
                    int den = 0;
                    int mesic = 0;
                    int rok = 0;
                    int den2 = 0;
                    int mesic2 = 0;
                    int rok2 = 0;
                    string[] parts;
                    Console.Clear();
                    auto.Dostupnost = false;
                    Console.WriteLine("Od kdy si chcete auto zapůjčit(dd/mm/yyyy)?");
                    while (true)
                    {
                        string datum1 = Console.ReadLine();
                        parts = datum1.Split('.');

                        DateTime datum = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));
                            
                        if (parts.Length == 3 && int.Parse(parts[2]) >= DateTime.Now.Year && int.Parse(parts[0]) > 0 && int.Parse(parts[0]) <= 31 && int.Parse(parts[1]) > 0 && int.Parse(parts[1]) <= 12 && datum.Date >= DateTime.Now.Date)
                        {
                            den = int.Parse(parts[0]);
                            mesic = int.Parse(parts[1]);
                            rok = int.Parse(parts[2]);
                            break;
                        }    
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Neplatné datum");
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("Od kdy si chcete auto zapůjčit(dd/mm/yyyy)?");
                        }
                    }
                    DateTime datumPujceni = new DateTime(rok, mesic, den);
                    Console.WriteLine("Do kdy si chcete auto zapůjčit(dd/mm/yyyy)?");
                    while (true) 
                    {
                        string datum2 = Console.ReadLine();
                        parts = datum2.Split('.');

                        DateTime datum = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));

                        if (parts.Length == 3 && int.Parse(parts[0]) <= 31 && int.Parse(parts[0]) > 0 && int.Parse(parts[1]) > 0 && int.Parse(parts[1]) <= 12 && datum.Date >= datumPujceni.Date)
                        {
                            
                            den2 = int.Parse(parts[0]);
                            mesic2 = int.Parse(parts[1]);
                            rok2 = int.Parse(parts[2]);
                            break;
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Neplatné datum");
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("Do kdy si chcete auto zapůjčit(dd/mm/yyyy)?");
                        }
                    }
                    DateTime datumVraceni = new DateTime(rok2, mesic2, den2);
                    bool vraceno = false;

                    TimeSpan dnyRozdil = datumVraceni - datumPujceni;

                    double cena = (dnyRozdil.Days * auto.CenaZaDen) + (dnyRozdil.Days * auto.CenaZaDen) * 0.1; //vypočítání ceny
                    Pujcka pujcka = new Pujcka(datumPujceni, datumVraceni, vraceno, cena, auto, zakaznik, null);
                    pujcky.Add(pujcka);
                }



                else if (auto.Dostupnost == false)
                {
                    Console.WriteLine("Auto nelze zapůjčit");
                    Thread.Sleep(900);
                }
            } else if (vyber == 2)
            {
                Console.Clear();
                if (motorky.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Není registrována žádná motorka");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    return;
                }
                for (int i = 0; i < motorky.Count; i++)
                {
                    Console.Write($"{i + 1}. {motorky[i].Vyrobce} {motorky[i].Model}, {motorky[i].RokVyroby}, Dostupnost: ");
                    if (motorky[i].Dostupnost == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Nedostupné");
                    }

                    else if (motorky[i].Dostupnost == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Dostupné");
                    }
                }
                Console.ResetColor();
                Console.WriteLine("\nJakou motorku si chcete půjčit? ");
                int index;
                while (!int.TryParse(Console.ReadLine(), out index))
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(300);
                    Console.Write("Jakou motorku si chcete půjčit? ");
                }

                Motorka motorka = motorky[index - 1];

                if (motorka.Dostupnost == true)
                {
                    int den = 0;
                    int mesic = 0;
                    int rok = 0;
                    int den2 = 0;
                    int mesic2 = 0;
                    int rok2 = 0;
                    string[] parts;
                    Console.Clear();
                    motorka.Dostupnost = false;
                    Console.WriteLine("Od kdy si chcete motorku zapůjčit(dd/mm/yyyy)?");
                    while (true)
                    {
                        string datum1 = Console.ReadLine();
                        parts = datum1.Split('.');
                        DateTime datum = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));
                        if (parts.Length == 3 && int.Parse(parts[0]) > 0 && int.Parse(parts[0]) <= 31 && int.Parse(parts[1]) > 0 && int.Parse(parts[1]) <= 12 && datum.Date >= DateTime.Now.Date)
                        {
                            den = int.Parse(parts[0]);
                            mesic = int.Parse(parts[1]);
                            rok = int.Parse(parts[2]);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Neplatné datum");
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("Od kdy si chcete motorku zapůjčit(dd/mm/yyyy)?");
                        }
                    }

                    DateTime datumPujceni = new DateTime(rok, mesic, den);
                    Console.WriteLine("Do kdy si chcete motorku zapůjčit(dd/mm/yyyy)?");
                    while (true)
                    {
                        string datum1 = Console.ReadLine();
                        parts = datum1.Split('.');

                        DateTime datum = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));
                        if (parts.Length == 3 && int.Parse(parts[0]) > 0 && int.Parse(parts[0]) <= 31 && int.Parse(parts[1]) > 0 && int.Parse(parts[1]) <= 12 && datum.Date >= datumPujceni)
                        {
                            den = int.Parse(parts[0]);
                            mesic = int.Parse(parts[1]);
                            rok = int.Parse(parts[2]);
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Neplatné datum");
                            Console.ResetColor();
                            Console.Clear();
                            Console.WriteLine("Do kdy si chcete motorku zapůjčit(dd/mm/yyyy)?");
                        }
                    }
                    DateTime datumVraceni = new DateTime(rok, mesic, den);

                    bool vraceno = false;

                    TimeSpan dnyRozdil = datumVraceni - datumPujceni;

                    double cena = Math.Round(dnyRozdil.Days * motorka.CenaZaDen, 2);
                    Pujcka pujcka = new Pujcka(datumPujceni, datumVraceni, vraceno, cena, null, zakaznik, motorka);
                    pujcky.Add(pujcka);


                }
                else if (motorka.Dostupnost == false)
                {
                    Console.WriteLine("Motorka nelze zapůjčit");
                    Thread.Sleep(900);
                }
                
            }
        }

        public void VraceniVozidla() //vrácení vozidla, dostupnost = true
        {
            Console.Clear();
            if (pujcky.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Neexistují žádné půjčky");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            for (int i = 0; i < pujcky.Count; i++)
            {
                if (pujcky[i].Auto != null)
                Console.WriteLine($"{i + 1}. {pujcky[i].Zakaznik.Jmeno} {pujcky[i].Zakaznik.Prijmeni}, ID: {pujcky[i].Zakaznik.ID}, Auto: VIN: {pujcky[i].Auto.VIN}, SPZ: {pujcky[i].Auto.SPZ}");
                else if (pujcky[i].Motorka != null)
                    Console.WriteLine($"{i + 1}. {pujcky[i].Zakaznik.Jmeno} {pujcky[i].Zakaznik.Prijmeni}, ID: {pujcky[i].Zakaznik.ID}, Motorka: VIN: {pujcky[i].Motorka.VIN}, SPZ: {pujcky[i].Motorka.SPZ}");
            }
            Console.Write("Půjčka: ");
            int pujckaIndex;
            while (!int.TryParse(Console.ReadLine(), out pujckaIndex))
            {
                Console.WriteLine("Špatně zadané číslo");
                Thread.Sleep(300);
                Console.Write("Půjčka: ");
            }

            Pujcka pujcka = pujcky[pujckaIndex - 1];

            if (pujcka.Auto != null)
            {
                Console.WriteLine($"Původní stav tachometru: {pujcka.Auto.Tachometr}km");
                Console.Write("Nový stav tachometru: ");
                int novyStavTachometru;
                while(!int.TryParse(Console.ReadLine(), out novyStavTachometru))
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(300);
                    Console.Write("Nový stav tachometru: ");
                }
                while (pujcka.Auto.Tachometr > novyStavTachometru)
                {
                    Console.WriteLine("Nový stav tachometru musí být vyšší než předchozí");
                    Thread.Sleep(300);
                    Console.Write("Nový stav tachometru: ");
                    while (!int.TryParse(Console.ReadLine(), out novyStavTachometru))
                    {
                        Console.WriteLine("Špatně zadané číslo");
                        Thread.Sleep(300);
                        Console.Write("Nový stav tachometru: ");
                    }
                }
                Auto auto = pujcka.Auto;
                auto.Dostupnost = true;
                auto.Tachometr = novyStavTachometru;
                pujcka.Vraceno = true;
                starePujcky.Add(pujcka);
                pujcky.RemoveAt(pujckaIndex - 1);
            }
            else if(pujcka.Motorka != null)
            {
                Console.WriteLine($"Původní stav tachometru: {pujcka.Motorka.Tachometr}km");
                Console.Write("Nový stav tachometru: ");
                int novyStavTachometru;
                while (!int.TryParse(Console.ReadLine(), out novyStavTachometru))
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(300);
                    Console.Write("Nový stav tachometru: ");
                }
                while (pujcka.Motorka.Tachometr > novyStavTachometru)
                {
                    Console.WriteLine("Nový stav tachometru musí být vyšší než předchozí");
                    Thread.Sleep(300);
                    Console.Write("Nový stav tachometru: ");
                    while (!int.TryParse(Console.ReadLine(), out novyStavTachometru))
                    {
                        Console.WriteLine("Špatně zadané číslo");
                        Thread.Sleep(300);
                        Console.Write("Nový stav tachometru: ");
                    }
                }
                Motorka motorka = pujcka.Motorka;
                motorka.Tachometr = novyStavTachometru;
                motorka.Dostupnost = true;
                pujcka.Vraceno = true;
                starePujcky.Add(pujcka);
                pujcky.RemoveAt(pujckaIndex - 1);
            }
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vozidlo bylo vráceno");
            Console.ResetColor();
            
            Thread.Sleep(800);
        }

        public void VypisPujcek() //vypsání všech půjček
        {
            Console.Clear();
            if (pujcky.Count == 0 && starePujcky.Count == 0) //když neexistuje žádná půjčka
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Neexistují žádné půjčky");
                Console.ResetColor();
                Thread.Sleep(1000);
                return;
            }
            else if (pujcky.Count != 0 && starePujcky.Count == 0) //když existuje min. 1 aktivní půjčka
            {
                Console.WriteLine("Aktivní půjčky:");
                foreach (Pujcka pujcka in pujcky)
                {
                    pujcka.VypsatPujcku();
                    Console.WriteLine();
                }
            }
            else if (starePujcky.Count != 0 && pujcky.Count == 0)//když existuje min. 1 neaktivní půjčka
            {
                Console.WriteLine("Staré půjčky:");
                foreach (Pujcka pujcka1 in starePujcky)
                {
                    pujcka1.VypsatPujcku();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Aktivní půjčky:");
                foreach (Pujcka pujcka in pujcky)
                {
                    pujcka.VypsatPujcku();
                    Console.WriteLine();
                }
                Console.WriteLine("Staré půjčky:");
                foreach (Pujcka pujcka1 in starePujcky)
                {
                    pujcka1.VypsatPujcku();
                    Console.WriteLine();
                }
            }
            Console.Write("\nZmáčkněte libovolnou klávesu pro pokračování...");
            Console.ReadKey(true);
        }
    }    
}
