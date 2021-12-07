namespace Lab3_sa
{
    interface IFunction
    {
        int Id { get; }
        string Name { get; }
        decimal GetY(decimal x);
    }
}
