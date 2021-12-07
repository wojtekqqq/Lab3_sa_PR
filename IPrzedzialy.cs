namespace Lab3_sa
{
    interface IPrzedzialy
    {
        int Id { get; }
        string Name { get; }
        decimal RangeFrom();
        decimal RangeTo();
    }
}
