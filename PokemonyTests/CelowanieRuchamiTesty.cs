using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp3._Model;
using ConsoleApp3.Celność;
using FluentAssertions;
using NUnit.Framework;

namespace PokemonyTests
{
    [TestFixture]
    public class CelowanieRuchamiTesty
    {
        [Test]
        public void PowinienObliczyćCelność()
        {
            var pudła = 30;
            var celne = 100;

            var walka = new Walka() { };
            var celujący = new Pokemon("Rajczu")
            {
                Statystyki = new Statystyki { Szybkość = 1776 },
                Ruchy = new List<Ruch> { new Ruch { Celność = 70 }, new Ruch { Celność = 50 } }
            };

            var unikający = new Pokemon("Venusaur")
            {
                Statystyki = new Statystyki { Szybkość = 1036 }
            };

            celujący.WybierzRuch(walka);

            var celowanie = new CelowanieRuchami();
            var trafilNieTrafił = new List<bool>();
            var random = new Random();
            var procent = celowanie.Traf(walka, celujący, unikający);

            for (var i = 0; i < 130; i++)
            {
                var proce = random.Next(0, 99);
                if (proce <= procent)
                {
                    trafilNieTrafił.Add(true);
                }
                else
                {
                    trafilNieTrafił.Add(false);
                }
            }

            var trafił = trafilNieTrafił.Count(x => x);
            var nieTrafił = trafilNieTrafił.Count(x => x == false);


            trafił.Should().BeInRange(celne - 8, celne + 8);
            nieTrafił.Should().BeInRange(pudła - 7, pudła + 3);
        }
    }
}
