using System;
using System.Collections.Generic;
using ConsoleApp3._Bazowe;
using ConsoleApp3.Ataki;
using ConsoleApp3.Celność;
using ConsoleApp3.Efekty;

namespace ConsoleApp3._Model
{
    public class Tura: Efektowny
    {
        public Pogoda Pogoda { get; set; }
        //public List<EfektZdażenie<,>> Efekty { get; set; }

        public int NumerTury { get; set; }

        public Tura(int numerTury)
        {
            NumerTury = numerTury;
        }
        private Pokemon AtakujePierwszy { get; set; }
        private Pokemon AtakujeDrugi { get; set; }

        public void Start(Walka walka)
        {
            
            walka.Trener.Pokemon.WybierzRuch(walka);
            walka.Rywal.Pokemon.WybierzRuch(walka);
            OkreślKolejność(walka);
            InitTuraEfekt(AtakujePierwszy);
            InitTuraEfekt(AtakujeDrugi);

            var rezultat = PróbujZabić(AtakujePierwszy, AtakujeDrugi, walka);
          
            if (rezultat)
                return;

            PróbujZabić(AtakujeDrugi, AtakujePierwszy, walka);
            
        }

        private bool PróbujZabić(Pokemon atakujący, Pokemon broniący, Walka walka)
        {
            var result = false;
            var blokowanieAtaków = new BlokowanieAtaków();
            if (!blokowanieAtaków.ZablokujAtak(atakujący, broniący, walka))
            {

                var obliczCelnośc = new CelowanieRuchami();
                var random = new Random();

                var celnośćAtakProcent = obliczCelnośc.Traf(walka, atakujący, broniący);
                var procent = random.Next(0, 99);

                if (celnośćAtakProcent >= procent)
                    WykonajRuch(atakujący, broniący, walka);
                else
                    Console.WriteLine($"{atakujący} używa ruchu {atakujący.OstatniRuch.Nazwa}. Jednak pudłuję");

                if (broniący.Statystyki.Życie < 0)
                {
                    ZakończWalke(broniący, atakujący, walka);
                    result = true;
                }
            }
            return result;
        }

        private void InitTuraEfekt(Pokemon atakujący)
        {
            var refectToRemove = new List<Efekt>();
            foreach (var efekt in atakujący.Efekty)
            {
                if (efekt.Wygasł())
                {
                    refectToRemove.Add(efekt);
                    Console.WriteLine($"{atakujący} nie jest już pod wpływem efektu: {efekt.Nazwa}");
                }
            }

            foreach (var efekt in refectToRemove)
            {
                atakujący.Efekty.Remove(efekt);
            }
        }

        private void WykonajRuch(Pokemon atakujący, Pokemon broniący, Walka walka)
        {
            var obrazenia = atakujący.ZadajObrażenia(broniący, walka);
            broniący.Statystyki.Życie -= obrazenia;
            Console.WriteLine($"{atakujący} używa ruchu {atakujący.OstatniRuch.Nazwa}. Zadaje {(int)obrazenia} obrażeń");
            if (atakujący.OstatniRuch.Efekty != null && atakujący.OstatniRuch.Efekty.Count > 0)
            {
                foreach (var efekt in atakujący.OstatniRuch.Efekty)
                {
                    if (efekt.MożnaAktywować(broniący))
                        efekt.Uaktywnij(broniący);
                }
            }
         
        }

        private void ZakończWalke(Pokemon przegrany, Pokemon wygrany, Walka walka)
        {
            walka.KoniecWalki = true;
            Console.WriteLine($"{przegrany} Pada na ziemie. Wygrywa {wygrany}");
        }

        public void OkreślKolejność(Walka walka)
        {
            var priorytetRuchTrener = walka.Trener.Pokemon.OstatniRuch.Priorytet;
            var priorytetRuchRywal = walka.Rywal.Pokemon.OstatniRuch.Priorytet;

            if (priorytetRuchRywal == priorytetRuchTrener)
            {
                var szybkośćTrener = walka.Trener.Pokemon.Statystyki.Szybkość;
                var szybkośćRywal = walka.Rywal.Pokemon.Statystyki.Szybkość;
                if (szybkośćTrener > szybkośćRywal)
                {
                    AtakujePierwszy = walka.Trener.Pokemon;
                    AtakujeDrugi = walka.Rywal.Pokemon;
                }

                else
                {
                    AtakujePierwszy = walka.Rywal.Pokemon;
                    AtakujeDrugi = walka.Trener.Pokemon;

                }
            }
            else if (priorytetRuchRywal > priorytetRuchTrener)
            {
                AtakujePierwszy = walka.Trener.Pokemon;
                AtakujeDrugi = walka.Rywal.Pokemon;
            }
            else
            {
                AtakujePierwszy = walka.Rywal.Pokemon;
                AtakujeDrugi = walka.Trener.Pokemon;
            }
            return;
        }
    }
}
