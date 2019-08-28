using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace PoleWalki
{
    public class Ruch
    {
        public string Nazwa { get; set; }
        public Efekt Efekt { get; set; }
        public bool WystąpiłBonus()
        {
            return true;
        }
    }
    public class Umiejetność
    {
        public string Nazwa { get; set; }
        public Efekt Efekt { get; set; }
        public bool WystąpiłBonus()
        {
            return true;
        }
    }
    public class Pokemon
    {
        public string Name { get; set; }
        public Ruch Ruch { get; set; }
        public Umiejetność Umiejętność { get; set; }
        public Pokemon(string name)
        {
            Name = name;
        }

        private readonly Subject<PokemonAtakuje> _atakujeSkurczybyk = new Subject<PokemonAtakuje>();
        private readonly Subject<NałóżEfekt> _rzucaZaklęciaSkurczybyk = new Subject<NałóżEfekt>();
        public IObservable<PokemonAtakuje> Ataki
        {
            get { return _atakujeSkurczybyk; }
        }
        public IObservable<NałóżEfekt> Efekty
        {
            get { return _rzucaZaklęciaSkurczybyk; }
        }

        public void Atakuj(Pokemon atakowany)
        {
            AktywujBonusy(atakowany);
            Obrazenia();
        }
        private void Obrazenia()
        {
            _atakujeSkurczybyk.OnNext(new PokemonAtakuje
            {
                Nazwa = Name,
                Obrażenia = WyliczObrazenia()
            });
        }

        private void AktywujBonusy(Pokemon atakowany)
        {
            if (Ruch.WystąpiłBonus())
            {
                _rzucaZaklęciaSkurczybyk.OnNext(new NałóżEfekt
                {
                    Efekt = Ruch.Efekt,
                    NałóżNa = atakowany,
                });
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

        public int WyliczObrazenia()
        {
            return 200 * DateTime.Now.Second;
        }
    }

    public class PokemonAtakuje
    {
        public double Obrażenia;
        public string Nazwa;
    }
    public class NałóżEfekt
    {
        public Pokemon NałóżNa;
        public Efekt Efekt;
        public int ModyfikatorObrażeń { get; set; }

    }

    public class Efekt
    {
        public string Nazwa { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pok = new Pokemon("Rajczu")
            {
                Ruch = new Ruch { Efekt = new Efekt { Nazwa = "Ogłuszenie" },Nazwa = "Focus Blast"},
                Umiejętność = new Umiejetność { Efekt = new Efekt { Nazwa = "Paraliż"},Nazwa = "Static"}
            };
            var pok2 = new Pokemon("Empoleon")
            {
                Ruch = new Ruch { Efekt = new Efekt { Nazwa = "Ogłuszenie" }, Nazwa = "Hudro Pump" },
                Umiejętność = new Umiejetność { Efekt = new Efekt { Nazwa = "Moc ataku" }, Nazwa = "Torrent" }
            };

            var potokAtaki = pok.Ataki.Zip(pok2.Ataki, (el1, el2) => new {Left = el1,Right = el2}).Subscribe(data =>
            {
                Console.WriteLine($"Atakuje {data.Left.Nazwa}! Zabrał:{data.Left.Obrażenia} życia. Ale to nie koniec bo:");
                Console.WriteLine($"Atakuje {data.Right.Nazwa}! Zabrał:{data.Right.Obrażenia} życia");

            });
            var potokEfekty = pok.Efekty.Zip(pok2.Efekty, (ef1, ef2) => new { Left = ef1, Right = ef2 }).Subscribe(data =>
            {
               Console.WriteLine($"Pokemon:{data.Left.NałóżNa.Name} jest pod wpływem efektu: {data.Left.Efekt.Nazwa}. Ale to nie koniec bo:" );
               Console.WriteLine($"Pokemon:{data.Right.NałóżNa.Name} jest pod wpływem efektu: {data.Right.Efekt.Nazwa}.");

            });

            pok.Ataki.Zip(pok.Efekty, (atakuje, efekt) => new {Atakuje = atakuje, Efekt = efekt}).Subscribe(data =>
            {
                Console.WriteLine($"Skoro pokemon: {data.Atakuje.Nazwa} jest pod wpływem efektu:{data.Efekt.Efekt} jego obrażenia z: {data.Atakuje.Obrażenia} zwiększają się do {data.Atakuje.Obrażenia * data.Efekt.ModyfikatorObrażeń}");
            });

            pok.Atakuj(pok2);
            Console.ReadKey();
            pok2.Atakuj(pok);

            pok.Atakuj(pok2);
            Console.ReadKey();
            pok2.Atakuj(pok);
            Console.ReadKey();

            pok2.Atakuj(pok);
            pok.Atakuj(pok2);

            Console.WriteLine("Hello World!");
        }

    }
}
