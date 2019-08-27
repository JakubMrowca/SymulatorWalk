
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3._Model;

namespace ConsoleApp3.Efekty
{
    public abstract class Efektowny
    {

    }
    public interface EfektZdażenie<TDlaczego,KGdzie> where TDlaczego:Efektowny where KGdzie:Efektowny
    {
        bool MożnaAktywować(TDlaczego element);

        int SzansaNaEfekt { get; set; }
        void Uaktywnij(KGdzie element);
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
