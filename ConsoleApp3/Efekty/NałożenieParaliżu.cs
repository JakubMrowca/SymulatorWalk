using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3._Bazowe;
using ConsoleApp3._Model;

namespace ConsoleApp3.Efekty
{
    public class NałożenieParaliżu:EfektZdażenie<Pokemon, Pokemon>
    {
        public bool MożnaAktywować(Pokemon pokemon)
        {
            var random = new Random();
            var szansa = random.Next(0, 99);
            if (SzansaNaEfekt > szansa)
            {
                if (pokemon.Typ != Typy.Ziemny && pokemon.Typ != Typy.Elektryczny)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public int SzansaNaEfekt { get; set; }

        public void Uaktywnij(Pokemon pokemon)
        {
            Console.WriteLine($"{pokemon} został sparaliżowany");
            pokemon.Efekty.Add(new Paraliż(){Nazwa = "Paraliż"});
        }

    }
}
