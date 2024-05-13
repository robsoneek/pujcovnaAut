using System.Net.Http.Headers;

namespace PROJEKT_PUJCOVNAAUT
{
    /*SPRÁVA AUTOMOBILŮ
     *přidat nové vozidlo
     *odebrat voźidlo
     *změna dostupnosti
     *cena za den
     *
     *SPRÁVA AUTOMOBILŮ
     *registrace nového zákazníka
     *přehled záznamů zákazníka(vypůjčení/vrácení)
     *výpis evidence zákazníků  
     *oprávnění řídit a co
     *
     *ZAPŮJČENÍ VOZIDLA
     *zákazník si může půjčit vozidlo
     *evidence typu A/B
     *datum od kdy, do kdy
     *výpočet ceny vypůjčení (podle typu auta počtu dní)
     *
     *VRÁCENÍ VOZIDLA
     *zákazní vrací vozidlo
     *změna stavu vozidla
     *měnit stav tachometru
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Pujcovna pujcovna = new Pujcovna(); //vytvoření objektu pro používání všech metod
            int input;
            string filePath; //cesta k souboru na uložení a načtení
            do
            {
                Console.Clear();
                Console.ResetColor();
                VypisMenu();
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Špatně zadané číslo");
                    Thread.Sleep(500);
                }
                switch (input)
                {
                    case 1:
                        pujcovna.PridatVozidlo();
                        break;
                    case 2:
                        pujcovna.OdebratVozidlo();
                        break;
                    case 3:
                        pujcovna.UpravitVozidlo();
                        break;
                    case 4:
                        pujcovna.VypisVozidel();
                        break;
                    case 5:
                        pujcovna.RegistrovatZakaznika();
                        break;
                    case 6:
                        pujcovna.OdebratZakaznika();
                        break;
                    case 7:
                        pujcovna.UpravitZakaznika();
                        break;
                    case 8:
                        pujcovna.VypisZakazniku();
                        break;
                    case 9:
                        pujcovna.PujceniVozidla();
                        break;
                    case 10:
                        pujcovna.VraceniVozidla();
                        break;
                    case 11:
                        pujcovna.VypisPujcek();
                        break;
                    case 12:
                        Console.Clear();
                        Console.Write("Název souboru: "); //název souboru kam se uloží data
                        filePath = Console.ReadLine();
                        pujcovna.UlozitDoSouboru(filePath);
                        break;
                    case 13:
                        Console.Clear();
                        Console.Write("Název souboru: ");//název souboru odkud se načtou data
                        filePath = Console.ReadLine();
                        pujcovna.NacistZeSouboru(filePath);
                        break;
                    case 14: //ukončení programu bez uložení
                        return;
                    case 15: //automatické uložení do souboru "pujcovna" a ukončení programu
                        filePath = "pujcovna";
                        pujcovna.UlozitDoSouboru(filePath);
                        return;
                }
            } while (input != 14 || input != 15);
        }

        static void VypisMenu() //vypsání menu
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. Registrovat vozidlo");
            Console.WriteLine("2. Odebrat vozidlo");
            Console.WriteLine("3. Upravit údaje o vozidle");
            Console.WriteLine("4. Výpis všech vozidel");
            Console.WriteLine("5. Registrovat zákazníka");
            Console.WriteLine("6. Odebrat zákazníka");
            Console.WriteLine("7. Upravit údaje zákazníka");
            Console.WriteLine("8. Výpis všech zákazníků");
            Console.WriteLine("9. Vypůjčit vozidlo");
            Console.WriteLine("10. Vrátit vozidlo");
            Console.WriteLine("11. Výpis půjček");
            Console.WriteLine("12. Uložit do souboru");
            Console.WriteLine("13. Načíst ze souboru");
            Console.WriteLine("14. Odejít");
            Console.WriteLine("15. Odejít a uložit");
            Console.Write("?: ");
        }
    }
}