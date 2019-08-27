using System;
using System.Collections.Generic;
using System.Text;

namespace MachineLearning.Raport
{
    public class Tura
    {
        public Pokemon Atakujący { get; set; }
        public Pokemon Broniący { get; set; }
        public int NumerTury { get; set; }
        public List<Efekt> Efekty { get; set; }
    }
}
