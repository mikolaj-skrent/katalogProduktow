using System;
using System.Collections.Generic;
using System.Linq;
using KatalogProduktów;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz" };
double[] ceny = { 899.00, 249.50, 379.00, 189.99 };

// Tworzymy obiekty produktów
Produkt procesor = new Produkt("AMD Ryzen", 899.00, "Podzespoły", 10);
Produkt ram = new Produkt("Pamięć RAM", 249.50, "Podzespoły", 20);
// Produkt ssd = new Produkt("Dysk SSD", -379.00, "Podzespoły", -15); // celowo źle do testów
Produkt ssd = new Produkt("Dysk SSD", 379.00, "Podzespoły", 15);
Produkt zasilacz = new Produkt("Zasilacz", 189.99, "Podzespoły", 5);

// Tworzymy tablicę produktów
Produkt[] produkty = { procesor, ram, ssd, zasilacz };

// Tworzymy listę produktów
List<Produkt> listaProduktow = new List<Produkt> { procesor, ram, ssd, zasilacz };

Console.WriteLine("--- WYPISYWANIE PRODUKTÓW Z TABLICY ---");
foreach (Produkt produkt in produkty)
{
    produkt.WypiszProdukt();
}

Console.WriteLine("\n--- WYPISYWANIE PRODUKTÓW Z LISTY (ZA POMOCĄ ToString) ---");
foreach (Produkt produkt in listaProduktow)
{
    // Wykorzystujemy nadpisaną metodę ToString()
    Console.WriteLine(produkt.ToString());
}

// Obliczenia tradycyjne (pętla for)
double suma = 0;
int licznik = 0;
for (int i = 0; i < nazwy.Length; i++)
{
    if (ceny[i] > 200)
    {
        suma = suma + ceny[i];
        licznik++;
    }
}

// Obliczenia przy użyciu LINQ dla listy
double sumaListy = listaProduktow.Sum(p => p.Cena);
double sredniaListy = listaProduktow.Average(p => p.Cena);
double sumaDrogichProduktow = listaProduktow.Where(p => p.Cena > 200).Sum(p => p.Cena);

Console.WriteLine($"\nŚrednia cena wszystkich produktów z listy: {sredniaListy:F2} zł");
Console.WriteLine($"Suma cen produktów droższych niż 200 zł (LINQ): {sumaDrogichProduktow:F2} zł");

// Wywołania metod statycznych dla wartości magazynu
double wartoscMagazynuTablicy = Produkt.ObliczWartoscMagazynu(produkty);
Console.WriteLine($"\nSuma wartości magazynu (tablica): {wartoscMagazynuTablicy:F2} zł");

double wartoscMagazynuListy = Produkt.ObliczWartoscMagazynu(listaProduktow);
Console.WriteLine($"Suma wartości magazynu (lista): {wartoscMagazynuListy:F2} zł");

// Test sprzedaży
Console.WriteLine("\n--- TEST SPRZEDAŻY ---");
procesor.Sprzedaj();