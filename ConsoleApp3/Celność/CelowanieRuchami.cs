using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp3._Model;
using ConsoleApp3.Efekty;

namespace ConsoleApp3.Celność
{
    public class CelowanieRuchami
    {
        public double Traf(Walka walka, Pokemon celujący, Pokemon unikający)
        {
            var efektModyfikator = 1;
    
            double maxCelność = celujący.OstatniRuch.Celność * 2;
            double minCelność = celujący.OstatniRuch.Celność * 0.4;

            var celność = celujący.Celność;
            var uniki = unikający.Unik;

            var szybkośćCelujący = celujący.Statystyki.Szybkość;
            var szybkośćUnikający = unikający.Statystyki.Szybkość;

            var stosunek = szybkośćCelujący / szybkośćUnikający;
            double modyfikator = 1;

            if (stosunek > 1 && stosunek < 1.2)
                modyfikator = 1.04;
            if (stosunek > 1.2 && stosunek < 1.4)
                modyfikator = 1.08;
            if (stosunek > 1.4 && stosunek < 1.7)
                modyfikator = 1.1;
            if (stosunek > 1.7 && stosunek < 1.9)
                modyfikator = 1.17;
            if (stosunek > 1.9 && stosunek < 2.2)
                modyfikator = 1.26;
            if (stosunek > 2.2 && stosunek < 2.5)
                modyfikator = 1.31;
            if (stosunek > 2.5 && stosunek < 2.8)
                modyfikator = 1.35;
            if (stosunek > 2.8 && stosunek < 3.1)
                modyfikator = 1.40;
            if (stosunek > 3.1 && stosunek < 3.5)
                modyfikator = 1.49;
            if (stosunek > 3.5 && stosunek < 3.9)
                modyfikator = 1.55;
            if (stosunek > 3.9 && stosunek < 4.4)
                modyfikator = 1.63;
            if (stosunek > 4.4 && stosunek < 5.0)
                modyfikator = 1.81;
            if (stosunek > 5.0 && stosunek < 5.5)
                modyfikator = 1.92;
            if (stosunek > 5.5 && stosunek < 6)
                modyfikator = 2;

            if (stosunek < 1 && stosunek > 0.9)
                modyfikator = 0.96;
            if (stosunek < 0.9 && stosunek > 0.8)
                modyfikator = 0.92;
            if (stosunek < 0.8 && stosunek > 0.7)
                modyfikator = 0.90;
            if (stosunek < 0.7 && stosunek > 0.6)
                modyfikator = 0.83;
            if (stosunek < 0.54 && stosunek > 0.4)
                modyfikator = 0.74;
            if (stosunek < 0.4 && stosunek > 0.37)
                modyfikator = 0.69;
            if (stosunek < 0.37 && stosunek > 0.33)
                modyfikator = 0.65;
            if (stosunek < 0.33 && stosunek > 0.31)
                modyfikator = 0.60;
            if (stosunek < 0.31 && stosunek > 0.28)
                modyfikator = 0.51;
            if (stosunek < 0.28 && stosunek > 0.26)
                modyfikator =0.45;
            if (stosunek < 0.26 && stosunek > 0.23)
                modyfikator = 0.37;
            if (stosunek < 0.23 && stosunek > 0.19)
                modyfikator = 0.19;
            if (stosunek < 0.19 && stosunek > 0.17)
                modyfikator = 0.8;
            if (stosunek < 0.17 && stosunek > 0.14)
                modyfikator = 0.1;

            var ruchCelność = celujący.OstatniRuch.Celność;
            var procent = ruchCelność * modyfikator * (celność / uniki);
            if (procent > maxCelność)
                return maxCelność;
            if (procent < minCelność)
                return minCelność;

            return procent;
        }
    }
}
