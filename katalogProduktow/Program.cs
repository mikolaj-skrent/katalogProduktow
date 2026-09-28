using katalogProduktow;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz" };
double[] ceny = { 899.00, 249.50, 379.00, 189.99 };

//stwórz nowy obiekt procesor według definicji klasy Produkt
Produkt procesor = new Produkt();
//nadaj mu wartości pól
procesor.Nazwa = "AMD Ryzen";
procesor.Cena = 899.00;
procesor.Kategoria = "Podzespoły";
procesor.Ilosc = 10;

//można też alternatywnie zainicjalizować obiekt w jednym bloku, bezpośrednio przy tworzeniu obiektu
Produkt ram = new Produkt
{
    Nazwa = "Pamięć RAM",
    Cena = 527.50,
    Kategoria = "Podzespoły",
    Ilosc = 20
};
Produkt ssd = new Produkt
{
    Nazwa = "Dysk SSD",
    Cena = 379.00,
    Kategoria = "Podzespoły",
    Ilosc = 1
};
Produkt zasilacz = new Produkt
{
    Nazwa = "Zasilacz",
    Cena = 189.99,
    Kategoria = "Podzespoły",
    Ilosc = 5
};
//tworzymy tablicę produktów
Produkt[] produkty = { procesor, ram, ssd, zasilacz };

foreach (Produkt produkt in produkty)
{
    Console.WriteLine($"Nazwa: {produkt.Nazwa,-25}| Cena: {produkt.Cena,10:f2} zł | " +
        $"Kategoria: {produkt.Kategoria} | Ilość: {produkt.Ilosc,5}");
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