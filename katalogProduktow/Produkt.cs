using System;
using System.Collections.Generic;
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
        // to jest prywatne pole które przechowuje wartość ceny produktu
        private double _cena;
        //to jest publiczna właściwość (pole) która pozwala na KONTROLOWANY dostęp do prywatnego pola _cena
        public double Cena
        {
            get { return _cena; } //jeśli ktoś chce przeczytać cenę produktu, to zwracamy wartość prywatnego pola _cena - nie ma problemu
            set //jeśli ktoś chce ustawić cenę produktu, to sprawdzamy czy wartość jest poprawna
            {
                if (value < 0) //jeśli ktoś próbuje ustawić cenę na wartość ujemną, to wyrzucamy wyjątek
                {
                    _cena = 0;
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else //w innym przypadku ustawiamy wartość prywatnego pola _cena na wartość podaną przez użytkownika
                {
                    _cena = value;
                }
            }
        }
        public int MinimalnyStan { get; set; } // minimalny stan magazynu - można ustawić z zewnątrz

        public string Kategoria { get; set; }
        public int Ilosc { get; private set; } // ilość nie może być zmieniana z zewnątrz, tylko w konstruktorze lub metodach klasy}

        // właściwość wyliczana - nie przechowujemy tego tylko liczymy na żywo
        public double WartoscMagazynu
        {
            get { return Cena * Ilosc; }
        }

        //konstruktor - ten wymaga podania wszytkich parametrów przy tworzeniu obiektu
        public Produkt(string nazwa, double cena, string kategoria, int ilosc)
        {
            //nadajemy wartości pól obiektu na podstawie parametrów konstruktora
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
            MinimalnyStan = 1; // ustawiamy domyślny minimalny stan magazynu
        }
        //ten konstruktor pozwala na tworzenie obiektu tylko z nazwą, reszta pól przyjmie wartości domyślne
        public Produkt(string nazwa)
        {
            Nazwa = nazwa;
            Cena = 0;
            Kategoria = "Brak kategorii";
            Ilosc = 0;
            MinimalnyStan = 1;
        }
        //funkcja wypisuje informacje o produkcie w formacie kolumn tabeli
        public void WypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość magazynu: {WartoscMagazynu,10:f2} zł");
        }
        //ta metoda zwraca string z tymi samymi informacjami o produkcie, ale nie wypisuje ich na ekran
        public string InformacjeOProdukcie()
        {
            return $"Nazwa: {Nazwa,-15}| Cena: {Cena,10:f2} zł | " +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość magazynu: {WartoscMagazynu,10:f2} zł";
        }
        //funkcja statyczna - liczy sumę wartości magazynu dla wszystkich produktów w tablicy
        public static double ObliczWartoscMagazynu(Produkt[] produkty)
        {
            double suma = 0; // pusty licznik na sume
            foreach (Produkt produkt in produkty) //dla każdego produktu w tablicy produktów
            {
                suma += produkt.WartoscMagazynu; // dodajemy jego wartość magazynu do sumy
            }
            return suma; //na koniec zwracamy sumę wartości magazynu
        }
        //zwraca prawda jeśli ilość jest większa niż minimalny stan, czyli można zamówić produkt
        public bool CzyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan; // jeśli ilość jest większa niż minimalny stan, to można zamówić
        }
        //funkcja sprzedaje produkt - zmniejsza ilość o 1 jeśli jest na stanie, jeśli nie ma to wypisuje komunikat
        public void Sprzedaj()
        {
            if (CzyMoznaZamowic()) //czy można zamówić - czy mamy dość na stanie?
            {
                //tak, zdejmij ze stanu jedną sztukę
                Ilosc--;
                //wypisz informację o sprzedaży
                Console.WriteLine($"Sprzedano produkt: {Nazwa}. Pozostało na stanie: {Ilosc}");
            }
            else
            {
                //nie, nie można sprzedać, bo nie ma na stanie
                Console.WriteLine($"Nie można sprzedać produktu: {Nazwa}. Brak na stanie.");
            }
        }
    }
}