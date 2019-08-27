using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp3._Model;

namespace ConsoleApp3.Ataki
{
    public static class Wzory
    {
        public static double WzórNaSpAtak(Pokemon broniący, Pokemon atakujący, Ruch ruch)
        {
            var stab = atakujący.Typ == ruch.Typ ? 1.25 : 1;
            var random = new Random();
            var losowaLiczba = (double)random.Next(205, 255);
            var modyfikatorOdporności = broniący.Odporności.Where(x => x.Typ == ruch.Typ).Select(x => x.Multiple).FirstOrDefault();
            var dmg = ((((atakujący.Poziom * 0.4) + 2) * atakujący.Statystyki.SpAtak * ruch.Moc / 50 / broniący.Statystyki.SpObrona) + 2) * modyfikatorOdporności * stab * (losowaLiczba / 255) * 5;
            return dmg;
        }
        public static double WzórNaAtak(Pokemon broniący, Pokemon atakujący, Ruch ruch)
        {
            var stab = atakujący.Typ == ruch.Typ ? 1.25 : 1;
            var random = new Random();
            var losowaLiczba = random.Next(205, 255);
            var modyfikatorOdporności = broniący.Odporności.Where(x => x.Typ == ruch.Typ).Select(x => x.Multiple).FirstOrDefault();
            var dmg = ((((atakujący.Poziom * 0.4) + 2) * atakujący.Statystyki.Atak * ruch.Moc / 50 / broniący.Statystyki.Obrona) + 2) * modyfikatorOdporności * stab * (losowaLiczba / 255) * 5;
            return dmg;
        }
    }
}
