using System.Collections.Generic;
using ConsoleApp3._Bazowe;
using ConsoleApp3.Efekty;

namespace ConsoleApp3._Model
{
    public class Ruch: Efektowny
    {
        public double Moc { get; set; }
        public Typy Typ { get; set; }
        public string Rodzaj { get; set; }
        public int Priorytet { get; set; }
        public int Celność { get; set; }
        public string Nazwa { get; set; }

        public bool WymagaPrzygotowania { get; set; }
        public bool WymagaOdpoczynku { get; set; }

        public bool Kontaktowy { get; set; }

        public List<EfektZdażenie<Pokemon, Pokemon>> Efekty { get; set; }

        public override string ToString()
        {
            return Nazwa;
        }
    }
}
