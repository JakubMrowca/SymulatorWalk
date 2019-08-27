using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp3._Bazowe;
using ConsoleApp3.Ataki;
using ConsoleApp3.Efekty;

namespace ConsoleApp3._Model
{
    public class Pokemon: Efektowny
    {
        public List<Ruch> Ruchy { get; set; }
        public string Name { get; set; }
        public Typy Typ { get; set; }
        public double Przywiązanie { get; set; }
        public Statystyki Statystyki { get; set; }
        public List<Odporność> Odporności { get; set; }
        public bool Shiny { get; set; }
        public Ruch OstatniRuch { get; private set; }
        public List<Efekt> Efekty { get; set; }

        public double Celność = 100;
        public double Unik = 100;

        public Pokemon(string name)
        {
            Name = name;
            Efekty = new List<Efekt>();
        }

        public int Poziom { get; set; }

        public double ZadajObrażenia(Pokemon rywal, Walka walka)
        {

            if (OstatniRuch.Rodzaj == "Specjalny")
                return Wzory.WzórNaSpAtak(rywal, this, OstatniRuch);
            else if (OstatniRuch.Rodzaj == "Fizyczny")
                return Wzory.WzórNaAtak(rywal, this, OstatniRuch);
            else
            {
                return 0;
            }
        }

        public Ruch WybierzRuch(Walka walka)
        {
            Ruch ruch;
            if (OstatniRuch == null)
                ruch = Ruchy.FirstOrDefault();
            else
            {
                var index = Ruchy.IndexOf(OstatniRuch);
                index = index + 1;
                if (index > 3)
                    index = 0;
                ruch = Ruchy.Skip(index).FirstOrDefault();
            }
            OstatniRuch = ruch;
            return ruch;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
