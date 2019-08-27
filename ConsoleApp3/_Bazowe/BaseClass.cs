using ConsoleApp3.Efekty;

namespace ConsoleApp3._Bazowe
{
    class Umiejętność
    {
        public string Name { get; set; }
        //public EfektZdażenie<,> Efekt { get; set; }
        public bool MożnaAktywować { get; set; }
    }

    class Przedmiot
    {
        public string Name { get; set; }
        //public EfektZdażenie<,> Efekt { get; set; }
        public double Wartość { get; set; }
        public TypJednostki Jednostka { get; set; }
    }

    class Odznaki
    {

    }

    class BaseClass
    {
    }
}
