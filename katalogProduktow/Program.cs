using KatalogProduktów;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz" };
double[] ceny = { 899.00, 249.50, 379.00, 189.99 };

//stwórz nowy obiekt procesor według definicji klasy Produkt
Produkt procesor = new Produkt("AMD Ryzen", 899.00, "Podzespoły", 10);
Produkt ram = new Produkt("Pamięć RAM", 249.50, "Podzespoły", 20);
//Produkt ssd = new Produkt("Dysk SSD", -379.00, "Podzespoły", -15); //celowo źle do testów
Produkt ssd = new Produkt("Dysk SSD", 379.00, "Podzespoły", 15);
Produkt zasilacz = new Produkt("Zasilacz", 189.99, "Podzespoły", 5);


//tworzymy tablicę produktów
Produkt[] produkty = { procesor, ram, ssd, zasilacz };

foreach (Produkt produkt in produkty)
{
    produkt.WypiszProdukt();
}


double suma = 0;
int licznik = 0;

for (int i = 0; i < nazwy.Length; i++)
{
    // Do sumy trafiają tylko produkty droższe niż 200 zł
    if (ceny[i] > 200)
    {
        suma = suma + ceny[i];
        licznik++;
    }
}

// Uwaga: przy pustym liczniku byłoby dzielenie przez zero
double srednia = suma / licznik;
//Console.WriteLine($"Ilość produktów w bazie: {nazwy.Length}");
//Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów");

//wywołanie metody statycznej klasy Produkt, która liczy sumę wartości magazynu dla wszystkich produktów w tablicy
//wywołujemy poprzez nazwę klasy -> kropka -> nazwa metody statycznej -> w nawiasach podajemy tablicę produktów
double wartoscMagazynu = Produkt.ObliczWartoscMagazynu(produkty);
Console.WriteLine($"Suma wartości magazynu dla wszystkich produktów: {wartoscMagazynu:f2} zł");