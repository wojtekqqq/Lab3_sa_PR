using System;

namespace Lab2_sa
{
    class Kalkulator1 : ICalculator
    {
        public int Id => 2;
        public string Name => "Metoda trapezow";

        public decimal GetIntegralValue(IFunction function, decimal rangeFrom, decimal rangeTo)
        {
            decimal powierzchnia = 0;

            decimal krok = (rangeTo - rangeFrom) / 100;
  


            for (int i = 1; i < 100; i++)
            {
                powierzchnia += function.GetY(rangeFrom + i * krok);
            }

            powierzchnia = (powierzchnia + (function.GetY(rangeFrom) + function.GetY(rangeTo)) / 2) * krok;
            Console.WriteLine("Przybliżona wartość całki metodą trapezów :" + powierzchnia);
            return powierzchnia;
        }
    }
}
