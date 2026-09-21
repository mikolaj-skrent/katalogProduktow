using katalogProduktow;

double cena = 1234.567;
int sztuk = 4;

// Sklejanie plusami - działa, ale przy dłuższym napisie robi się nieczytelne
Console.WriteLine("Cena: " + cena + " zł, sztuk: " + sztuk);

// Interpolacja: znak dolara przed cudzysłowem pozwala wstawić wartość
// wprost w tekst, w nawiasach klamrowych
Console.WriteLine($"Cena: {cena} zł, sztuk: {sztuk}");



Console.OutputEncoding = System.Text.Encoding.UTF8;

string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz", "Karta graficzna" };
double[] ceny = { 899.00, 249.50, 379.00, 189.99, 5099.00 };

//////////////////////////////////

Product procesor = new Product();
procesor.Nazwa = "Procesor";
procesor.Cena = 899.00;
procesor.Kategoria = "Podzespoły";
procesor.ilosc = 10;

//////////////////////////////////

Product ram = new Product
{
    Nazwa = "Pamięć RAM",
    Cena = 249.50,
    Kategoria = "Podzespoły",
    ilosc = 20
};

Product ssd = new Product
{
    Nazwa = "Dysk SSD",
    Cena = 379.00,
    Kategoria = "Podzespoły",
    ilosc = 15
};

Product zasilacz = new Product
{
    Nazwa = "Zasilacz",
    Cena = 189.99,
    Kategoria = "Podzespoły",
    ilosc = 30
};



//////////////////////////////////
Product[] products = { procesor, ram, ssd, zasilacz };

foreach (Product product in products)
{
    Console.WriteLine($"Produkt: {product.Nazwa, -25} | cena: {product.Cena,10:F2} zł | kategoria: {product.Kategoria} | ilość: {product.ilosc}");
};

// Obliczenie najniższej, najwyższej i średniej ceny w nowej tablicy
double najnizsza = double.MaxValue;
double najwyzsza = double.MinValue;
double sumaCen = 0;
int ile = products.Length;

foreach (Product p in products)
{
    if (p.Cena < najnizsza) najnizsza = p.Cena;
    if (p.Cena > najwyzsza) najwyzsza = p.Cena;
    sumaCen += p.Cena;
}

double sredniaCen = ile > 0 ? sumaCen / ile : 0;
Console.WriteLine($"Najniższa: {najnizsza:F2} zł | Najwyższa: {najwyzsza:F2} zł | Średnia: {sredniaCen:F2} zł z {ile} produktów");

///////////////////////////////////////////////////////////////

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
Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów");