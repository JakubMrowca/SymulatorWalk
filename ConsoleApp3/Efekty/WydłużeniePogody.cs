
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3._Model;

namespace ConsoleApp3.Efekty
{
    public interface Efektowny
    {

    }
    public interface EfektZdażenie<TDlaczego,KGdzie> where TDlaczego:Efektowny where KGdzie:Efektowny
    {
        bool MożnaAktywować(TDlaczego element,KGdzie element2);

        int SzansaNaEfekt { get; set; }
        void Uaktywnij(KGdzie element, TDlaczego element2);
        Efekt Efekt { get; set; }
    }

    //public class WydłużeniePogody:Efekt
    //{
    //    //public double
    //    //public void Uaktywnij(Tura tura)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //}
}
