using System;
using System.Collections.Generic;
using ConsoleApp3._Bazowe;
using ConsoleApp3._Model;
using ConsoleApp3.Efekty;

namespace ConsoleApp3
{
   
    class Program
    {
        static void Main(string[] args)
        {
            var pantibian = new Trener
            {
                Wszechstronny = 0.23,
                Pokemon = new Pokemon("Rajczu")
                {
                    Poziom = 100,
                    Odporności = RajczuOdporności,
                    Przywiązanie = 0.25,
                    Typ = Typy.Elektryczny,
                    Shiny = true,
                    Umiejętność = new Umiejętność()
                    {
                         Nazwa = "Static", Efekty = new List<EfektZdażenie<Pokemon, Walka>> { new NałożenieParaliżu { SzansaNaEfekt = 30, PrzyKontakcie = true } } 
                    },
                    Statystyki = new Statystyki
                    {
                        SpAtak = 1650,
                        Obrona = 1000,
                        SpObrona = 1000,
                        Szybkość = 1200,
                        Życie = 6000
                    },
                    Ruchy = new List<Ruch>
                    {
                        new Ruch
                        {
                            Nazwa = "Thunder",
                            Celność = 70,
                            Moc = 110,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Elektryczny,
                            Efekty = new List<EfektZdażenie<Pokemon, Pokemon>>{new NałożenieParaliżu { SzansaNaEfekt = 30} }
                        },
                        new Ruch
                        {
                            Nazwa = "Zap Cannon",
                            Celność = 50,
                            Moc = 120,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Elektryczny,
                            Efekty = new List<EfektZdażenie<Pokemon, Pokemon>>{new NałożenieParaliżu { SzansaNaEfekt = 100} }
                        },
                        new Ruch
                        {
                            Nazwa = "Focus Blast",
                            Celność = 70,
                            Moc = 120,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Walczący
                        },
                        new Ruch
                        {
                            Nazwa = "Thunderbolt",
                            Celność = 100,
                            Moc = 95,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Elektryczny,
                            Efekty = new List<EfektZdażenie<Pokemon, Pokemon>>{new NałożenieParaliżu { SzansaNaEfekt = 10} }
                        }
                    }
                }
            };
            var brains = new Trener
            {
                Wszechstronny = 0.25,
                Pokemon = new Pokemon("Empoleon")
                {
                    Poziom = 100,
                    Odporności = EmpoleonOdporności,
                    Przywiązanie = 0.25,
                    Shiny = true,
                    Typ = Typy.Wodny,
                    Statystyki = new Statystyki
                    {
                        SpAtak = 1600,
                        Obrona = 1200,
                        SpObrona = 1245,
                        Szybkość = 700,
                        Życie = 8000
                    },
                    Ruchy = new List<Ruch>
                    {
                        new Ruch
                        {
                            Nazwa = "Hydro Pump",
                            Celność = 80,
                            Moc = 110,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Wodny
                        },
                        new Ruch
                        {
                            Nazwa = "Blizzard",
                            Celność = 70,
                            Moc = 120,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Lodowy
                        },
                        new Ruch
                        {
                            Nazwa = "Ice Beam",
                            Celność = 95,
                            Moc = 90,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Lodowy
                        },
                        new Ruch
                        {
                            Nazwa = "Scald",
                            Celność = 100,
                            Moc = 80,
                            Rodzaj = "Specjalny",
                            Typ = Typy.Wodny
                        }
                    }
                }
            };

            var walka = new Walka
            {
                Trener = pantibian,
                Rywal = brains
            };

            walka.Rozpocznij();

            Console.WriteLine("Hello World!");
        }

        private static List<Odporność> RajczuOdporności = new List<Odporność>(
        )
        {
            new Odporność {Typ = Typy.Elektryczny, Multiple = 0.5},
            new Odporność {Typ = Typy.Normalny, Multiple = 1},
            new Odporność {Typ = Typy.Walczący, Multiple = 1},
            new Odporność {Typ = Typy.Wodny, Multiple = 1},
            new Odporność {Typ = Typy.Powietrzny, Multiple = 0.5},
            new Odporność {Typ = Typy.Psychiczny, Multiple = 1},
            new Odporność {Typ = Typy.Ziemny, Multiple = 2},
            new Odporność {Typ = Typy.Kamienny, Multiple = 1},
            new Odporność {Typ = Typy.Duch, Multiple = 1},
            new Odporność {Typ = Typy.Smoczy, Multiple = 1},
            new Odporność {Typ = Typy.Stalowy, Multiple = 0.5},
            new Odporność {Typ = Typy.Ognisty, Multiple = 1},
            new Odporność {Typ = Typy.Lodowy, Multiple = 1}
        };
        private static List<Odporność> EmpoleonOdporności = new List<Odporność>(
        )
        {
            new Odporność {Typ = Typy.Elektryczny, Multiple = 2},
            new Odporność {Typ = Typy.Normalny, Multiple = 0.5},
            new Odporność {Typ = Typy.Walczący, Multiple = 2},
            new Odporność {Typ = Typy.Wodny, Multiple = 0.5},
            new Odporność {Typ = Typy.Powietrzny, Multiple = 0.5},
            new Odporność {Typ = Typy.Psychiczny, Multiple = 0.5},
            new Odporność {Typ = Typy.Ziemny, Multiple = 2},
            new Odporność {Typ = Typy.Kamienny, Multiple = 0.5},
            new Odporność {Typ = Typy.Duch, Multiple = 0.5},
            new Odporność {Typ = Typy.Smoczy, Multiple = 0.5},
            new Odporność {Typ = Typy.Stalowy, Multiple = 0.5},
            new Odporność {Typ = Typy.Ognisty, Multiple = 1},
            new Odporność {Typ = Typy.Lodowy, Multiple = 0.5}
        };
    }



}
