using ConsoleApp3._Model;

namespace ConsoleApp3.Pomoce
{
    public static class StatystykiPomoc
    {
        
        public static Statystyki MnóżStatystyki(this Statystyki statystyki, double mnożnik)
        {
            return new Statystyki
            {
                Atak = statystyki.Atak * mnożnik,
                SpAtak = statystyki.SpAtak * mnożnik,
                SpObrona = statystyki.SpObrona * mnożnik,
                Obrona = statystyki.Obrona * mnożnik,
                Szybkość = statystyki.Szybkość * mnożnik
            };
        }
    }
}
