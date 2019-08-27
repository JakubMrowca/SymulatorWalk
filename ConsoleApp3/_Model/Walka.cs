using System.Collections.Generic;
using System.Linq;
using ConsoleApp3.Efekty;
using ConsoleApp3.Pomoce;

namespace ConsoleApp3._Model
{
    public class Walka: Efektowny
    {
        public List<Tura> Tury { get; set; }
        public Trener Trener { get; set; }
        public Trener Rywal { get; set; }
        private Tura AktualnaTura { get; set; }
        public bool KoniecWalki { get; set; }

        public void Rozpocznij()
        {
            InicjujTrenera(Trener);
            InicjujTrenera(Rywal);

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
        }

        public void NastępnaTura()
        {

        }
    }
}
