using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3._Bazowe;
using ConsoleApp3._Model;

namespace ConsoleApp3.Ataki
{
    public class BlokowanieAtaków
    {
        public bool ZablokujAtak(Pokemon atakujący, Pokemon broniący, Walka walka)
        {
            foreach (var efekt in atakujący.Efekty)
            {
                if (efekt.RodzajEfektu == RodzajEfektu.BlokującyRuch)
                {
                    if (efekt.Działa())
                    {
                        Console.WriteLine($"{atakujący} jest pod wpływem efektu: {efekt.Nazwa} nie może wykonać ruchu");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
