namespace Lab3_sa
{
    class Funkcja3 : IFunction
    {
        public int Id => 3;

        public string Name => "y=2*x-3";

        public decimal GetY(decimal x)
        {
            return 2 * x - 3;
        }
    }
}
