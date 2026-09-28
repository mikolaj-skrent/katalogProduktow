using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace katalogProduktow
{
    internal class Produkt
    {
        private string _nazwa;
        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                if (value == String.Empty)
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

        public string Kategoria;
        public int Ilosc;

        // właściwość wyliczana - nie przechowujemy tego tylko liczymy na żywo
        public double WartoscMagazynu
        {
            get { return _cena * Ilosc; }
        }

        public Product(string nazwa, double cena, string kategoria, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
        }
    }
}