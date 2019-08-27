using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3._Bazowe;

namespace ConsoleApp3.Efekty
{
    public interface Efekt
    {
        RodzajEfektu RodzajEfektu { get; }
        int CzasEfektu { get; set; }
        string Nazwa { get; set; }
        bool Działa();
        bool Wygasł();
    }

    public interface BlokującyRuch
    {
         int SzansaNaBlokade { get; set; }
    }
    public class Paraliż : Efekt
    {
        public int SzansaNaBlokade => 50;
        public int ZmniejszenieCelności => 5;
        public int CzasEfektu { get; set; }
        public string Nazwa { get; set; }

        public bool Działa()
        {
            var random= new Random();
            var procent = random.Next(0, 99);
            if (SzansaNaBlokade > procent)
                return true;
            return false;
        }

        public bool Wygasł()
        {
            var random = new Random();
            var procent = random.Next(0, 99);
            if (SzansaNaZakończenie > procent)
            {

                return true;
            }
            else
                CzasEfektu += 1;
            return false;
        }

        public int SzansaNaZakończenie => 20 + 10 * CzasEfektu;

        public RodzajEfektu RodzajEfektu => RodzajEfektu.BlokującyRuch;
    }
}
