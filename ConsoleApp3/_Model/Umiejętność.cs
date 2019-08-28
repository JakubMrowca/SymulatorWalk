using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3.Efekty;

namespace ConsoleApp3._Model
{
    public class Umiejętność
    {
        public string Nazwa { get; set; }
        public List<EfektZdażenie<Pokemon, Walka>> Efekty { get; set; }

    }
}
