namespace Lab3_sa
{
    class Przedzial3 : IPrzedzialy
    {
        public int Id => 3;
        public string Name => "Przedział trzeci od -5 do 0";

        public decimal RangeFrom()
        {
            return -5;
        }

        public decimal RangeTo()
        {
            return 0;
        }
    }
}
