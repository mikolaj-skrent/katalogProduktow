using System;

namespace katalogProduktow
{
    internal class Produkt
    {
        private string _nazwa = "Brak nazwy";
        public string Nazwa
        {
            get => _nazwa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nazwa nie może być pusta.");
                _nazwa = value;
            }
        }

        private double _cena;
        public double Cena
        {
            get => _cena;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Cena nie może być ujemna.");
                _cena = value;
            }
        }

        public string Kategoria { get; set; } = string.Empty;

        private int _ilosc;
        public int Ilosc
        {
            get => _ilosc;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ilość nie może być ujemna.");
                _ilosc = value;
            }
        }

        public double WartoscMagazynu => Cena * Ilosc;

        // Konstruktor bezparametrowy używany w Program.cs
        public Produkt()
        {
            _nazwa = "Brak nazwy";
            _cena = 0;
            Kategoria = string.Empty;
            _ilosc = 0;
        }

        // Konstruktor parametryczny
        public Produkt(string nazwa, double cena, string kategoria, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            Ilosc = ilosc;
        }

        public void WypiszProdukt()
        {
            Console.WriteLine($"Nazwa: {Nazwa}, Cena: {Cena:F2} zł, Kategoria: {Kategoria}, Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu:F2} zł");
        }

        public string InformacjeOProdukcie()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena:F2} zł, Kategoria: {Kategoria}, Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu:F2} zł";
        }

        public static double ObliczWartoscMagazynu(Produkt[] produkty)
        {
            double suma = 0;
            foreach (Produkt produkt in produkty)
            {
                suma += produkt.WartoscMagazynu;
            }
            return suma;
        }

        public bool CzyMoznaZamowic()
        {
            return Ilosc > MinimalnyStan;
        }

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
    }
}