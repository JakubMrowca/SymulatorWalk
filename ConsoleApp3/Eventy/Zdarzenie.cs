using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3._Model;

namespace ConsoleApp3.Eventy
{
    public interface Zdarzenie
    {
        Walka Walka { get; set; }
    }

    public class WalkaZakończona:Zdarzenie
    {
        public Pokemon Wygrał { get; set; }
        public Pokemon Przegrał { get; set; }
        public Walka Walka { get; set; }
    }
}
