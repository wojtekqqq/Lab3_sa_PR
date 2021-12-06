namespace Lab2_sa
{
    class Przedzial1 : IPrzedzialy
            {
        public int Id => 1;
        public string Name => "Przedział pierwszy od -10 do 10";

        public decimal RangeFrom()
        {
            return -10;
        }

        public decimal RangeTo()
        {
            return 10;
        }
    }
}
