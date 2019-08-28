using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using ConsoleApp3._Bazowe;
using ConsoleApp3.Ataki;
using ConsoleApp3.Efekty;
using ConsoleApp3.Eventy;

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

        public Umiejętność Umiejętność { get; set; }
        public List<Efekt> Efekty { get; set; }

        private readonly Subject<PokemonAtakuje> _atakujeSkurczybyk = new Subject<PokemonAtakuje>();
        private readonly Subject<NałóżEfekt> _rzucaZaklęciaSkurczybyk = new Subject<NałóżEfekt>();
        public IObservable<PokemonAtakuje> Ataki
        {
            get { return _atakujeSkurczybyk; }
        }
        public IObservable<NałóżEfekt> Efektuje
        {
            get { return _rzucaZaklęciaSkurczybyk; }
        }

        private void Atakuj(Pokemon atakowany, Walka walka)
        {
             AktywujBonusy(atakowany);
            _atakujeSkurczybyk.OnNext(new PokemonAtakuje
            {
                Nazwa = Name,
                Obrażenia = ZadajObrażenia(atakowany,walka)
            });
        }

        private void AktywujBonusy(Pokemon atakowany)
        {
            if (OstatniRuch.Efekty != null)
            {
                foreach (var efektZdażeny in OstatniRuch.Efekty)
                {
                    if (efektZdażeny.MożnaAktywować(atakowany, null))
                    {
                        _rzucaZaklęciaSkurczybyk.OnNext(new NałóżEfekt
                        {
                            Efekt = efektZdażeny.Uaktywnij(atakowany),
                            NałóżNa = atakowany,
                        });
                    }
                }

               
            }

            if (atakowany.Umiejętność.WystąpiłBonus())
            {
                _rzucaZaklęciaSkurczybyk.OnNext(new NałóżEfekt
                {
                    Efekt = Umiejętność.Efekt,
                    NałóżNa = this,
                    ModyfikatorObrażeń = 2
                });
            }
        }

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
