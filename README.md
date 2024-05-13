# pujcovnaAut
Dokumentace k projektu Půjčovna aut
Funkce:
-	registrace vozidla (auto/motorka)
o	zadání VIN, SPZ, výrobce, modelu, rok výroby, ceny za den, stavu tachometru, počet míst, dostupnost (je-li vozidlo vypůjčeno nebo ne)
-	odebrání vozidla
o	vymazání vozidla z listu
-	upravení informací o vozidlu
o	možnost upravit jednotlivé údaje o vozidlu
-	vypisování všech vozidel
o	pomocí foreach a metody VypisInfo daného objektu vypíše každou položku v listu
-	vypůjčení vozidla
o	vybrání zákazníka (kdo si vypůjčí vozidlo), vybrání vozidla, zadání data vypůjčení a vrácení, dostupnost vozidla se změní na false a nejde půjčit
-	vrácení vozidla
o	vrácení vozidla, dostupnost auta se změní na true, vozidlo může být půjčeno
-	vytvoření půjčky 
o	při vypůjčení vytvoří do listu aktivních půjček, při vrácení ji přesune do listu neaktivních půjček a smaže z listu aktivních
o	kód těchto funkcí se nachází v metodách na vypůjčení a vrácení vozidla
-	výpis aktivních i neaktivních půjček
o	viz. vypisování všech vozidel
-	registrace zákazníka
o	vytvoření náhodného ID, zadání jména, příjmení, data narození, emailu, telefonního čísla a vytvoření oprávnění (A = motorka, B = auto a motorka)
-	odebrání zákazníka
o	odebere zákazníka z listu pomocí indexu zakaznici.RemoveAt(index-1)
-	upravení údajů zákazníka
o	viz. upravení údajů o vozidle
-	vypisování všech zákazníků
o	viz. vypisování všech vozidel
-	uložení do souboru, načtení ze souboru
o	pomocí SteamWriter uloží data do souboru, pomocí SteamReader je načte zpátky ze souboru
Využití tříd a metod:
-	6 tříd (auto, motorka, zákazník, půjčka, půjčovna)
-	každá třída (kromě třídy půjčovna) má vlastní metodu na vypsání informací o daném objektu
-	třída půjčovna – skládá se z metod pro každou funkci
-	v metodách pracuji s listy (pro každý objekt), polem, DateTime, klasické proměnné (int, double, string), využil jsem také poprvé TimeSpan a Thread.Sleep
-	v třídě půjčovna se nachází 11 metod (všechny public void)
-	nikde nevyužívám { get; set;}



