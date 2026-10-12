using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatalogProduktów
{
    internal class Produkt
    {
        private string _nazwa;
        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                if (value == String.Empty || value == null)
                {
                    _nazwa = "Brak nazwy";
                    throw new ArgumentException("Nazwa nie może być pusta.");
                }
                else
                {
                    _nazwa = value;
                }
            }
        }

        // Prywatne pole przechowujące cenę
        private double _cena;
        public double Cena
        {
            get { return _cena; }
            set
            {
                if (value < 0)
                {
                    _cena = 0;
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else
                {
                    _cena = value;
                }
            }
        }

        public int MinimalnyStan { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; private set; } // Poprawiono błąd z nadmiarową klamrą zamykającą klasę

        // Właściwość wyliczana
        public double WartoscMagazynu
        {
            get { return Cena * Ilosc; }
        }

        // Konstruktor pełny
        public Produkt(string nazwa, double cena, string kategoria, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
            MinimalnyStan = 1;
        }

        // Konstruktor skrócony (tylko nazwa)
        public Produkt(string nazwa)
        {
            Nazwa = nazwa;
            Cena = 0;
            Kategoria = "Brak kategorii";
            Ilosc = 0;
            MinimalnyStan = 1;
        }

        // Metoda wypisująca bezpośrednio na konsolę
        public void WypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość magazynu: {WartoscMagazynu,10:f2} zł");
        }

        // Przeciążenie metody ToString() dla eleganckiego zwracania tekstu
        public override string ToString()
        {
            return $"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość magazynu: {WartoscMagazynu,10:f2} zł";
        }

        // Metoda statyczna dla tablicy produktów
        public static double ObliczWartoscMagazynu(Produkt[] produkty)
        {
            double suma = 0;
            foreach (Produkt produkt in produkty)
            {
                suma += produkt.WartoscMagazynu;
            }
            return suma;
        }

        // Przeciążona metoda statyczna dla listy produktów (użycie LINQ)
        public static double ObliczWartoscMagazynu(List<Produkt> produkty)
        {
            return produkty.Sum(p => p.WartoscMagazynu);
        }

        // Sprawdzenie czy można zamówić produkt
        public bool CzyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan;
        }

        // Obsługa sprzedaży produktu
        public void Sprzedaj()
        {
            if (CzyMoznaZamowic())
            {
                Ilosc--;
                Console.WriteLine($"Sprzedano produkt: {Nazwa}. Pozostało na stanie: {Ilosc}");
            }
            else
            {
                Console.WriteLine($"Nie można sprzedać produktu: {Nazwa}. Brak na stanie.");
            }
        }

        public static Produkt ZnajdzPoNazwie(Produkt[] produkty, string nazwa)
        {
            foreach (var produkt in produkty)
            {
                if (produkt.Nazwa == nazwa)
                {
                    return produkt;
                }
                
            }
            return null; // Zwraca null, jeśli produkt nie został znaleziony
        }
    }
}