﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3._Model;
using ConsoleApp3.Efekty;

namespace ConsoleApp3.Eventy
{
    public class PokemonAtakuje
    {
        public double Obrażenia;
        public string Nazwa;
        public string NazwaRuchu;
        public string KogoAtakuje;

        public override string ToString()
        {
            return $"Pokemon {Nazwa} używa ruchu {NazwaRuchu}. Zadaje {Obrażenia} obrażeń";
        }
    }
    public class NałóżEfekt
    {
        public Pokemon NałóżNa;
        public Efekt Efekt;

    }
}
