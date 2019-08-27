using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearning.Raport
{
    public class Pokemon
    {
        public double Atak { get; set; }
        public double SpAtak { get; set; }
        public double Obrona { get; set; }
        public double SpObrona { get; set; }
        public double Szybkość { get; set; }
        public double Życie { get; set; }
        public string Nazwa { get; set; }

        public Ruch Ruch { get; set; }
    }
}
