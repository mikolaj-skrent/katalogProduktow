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