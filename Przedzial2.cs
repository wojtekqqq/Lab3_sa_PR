namespace Lab3_sa
{
    class Przedzial2 : IPrzedzialy
    {
        public int Id => 2;
        public string Name => "Przedział drugi od -5 do 20";

        public decimal RangeFrom()
        {
            return -5;
        }

        public decimal RangeTo()
        {
            return 20;
        }
    }
}
