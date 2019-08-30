using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ConsoleApp3.Efekty;
using ConsoleApp3.Eventy;
using ConsoleApp3.Pomoce;

namespace ConsoleApp3._Model
{
    public class Walka: Efektowny
    {
        public Walka()
        {
            Disposables = new List<IDisposable>();
            
        }

        private List<IDisposable> Disposables { get; set; }
        public List<Tura> Tury { get; set; }
        public Trener Trener { get; set; }
        public Trener Rywal { get; set; }
        private Tura AktualnaTura { get; set; }
        public bool KoniecWalki { get; set; }
        public List<EfektyWWalce> EfektyWWalce { get; set; }

        private List<Pokemon> PokemonyWWalce { get; set; }

        private readonly Subject<Zdarzenie> _walka = new Subject<Zdarzenie>();
        public IObservable<Zdarzenie> Walk
        {
            get { return _walka; }
        }
        public void Rozpocznij()
        {

            PokemonyWWalce = new List<Pokemon>{Trener.Pokemon,Rywal.Pokemon};
            EfektyWWalce = new List<EfektyWWalce>();
            
            InicjujTrenera(Trener);
            InicjujTrenera(Rywal);

            Subskrybuj();
            Tury = new List<Tura>();
            var pierwszaTura = new Tura(1);
            AktualnaTura = pierwszaTura;
            pierwszaTura.Start(this);

            while (!KoniecWalki)
            {
                var nextTura = new Tura(AktualnaTura.NumerTury + 1);
                AktualnaTura = nextTura;
                nextTura.Start(this);
            }
        }

        public void ZakończWalke()
        {
            KoniecWalki = true;
            Disposuj();
        }

        private void Disposuj()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
        }

        private void Subskrybuj()
        {
            var potok = Trener.Pokemon.Atakuje.Merge(Rywal.Pokemon.Atakuje).Subscribe(data => Zaatakował(data));

            Disposables.Add(potok);
            //Disposables.Add(potok2);

        }

        private void Zaatakował(PokemonAtakuje atakuje)
        {
            var ZabierzŻycie = PokemonyWWalce.FirstOrDefault(x => x.Name == atakuje.KogoAtakuje);
            ZabierzŻycie.Statystyki.Życie -= atakuje.Obrażenia;

            Console.WriteLine($"{atakuje}");

            if (ZabierzŻycie.Statystyki.Życie <= 0)
            {
                _walka.OnNext(new WalkaZakończona{Walka = this});
                Console.WriteLine($"{ZabierzŻycie.Name} Pada na ziemie. Wygrywa {atakuje.Nazwa}");
            }
        }

        private void InicjujTrenera(Trener trener)
        {
            var pokemon = trener.Pokemon;
            var statyList = new List<Statystyki>();
            if (pokemon.Shiny)
                statyList.Add(pokemon.Statystyki.MnóżStatystyki(0.15));

            statyList.Add(pokemon.Statystyki.MnóżStatystyki(trener.Wszechstronny));
            statyList.Add(pokemon.Statystyki.MnóżStatystyki(pokemon.Przywiązanie));

            pokemon.Statystyki.Atak += statyList.Sum(x => x.Atak);
            pokemon.Statystyki.SpAtak += statyList.Sum(x => x.SpAtak);
            pokemon.Statystyki.SpObrona += statyList.Sum(x => x.SpObrona);
            pokemon.Statystyki.Obrona += statyList.Sum(x => x.Obrona);
            pokemon.Statystyki.Szybkość += statyList.Sum(x => x.Szybkość);

            AktywujUmiejętność(trener);
        }

        private void AktywujUmiejętność(Trener trener)
        {
            //throw new System.NotImplementedException();
        }

        public void NastępnaTura()
        {

        }
    }
}
