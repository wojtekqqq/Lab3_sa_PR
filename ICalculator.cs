namespace Lab3_sa
{
    interface ICalculator
    {
        string Name { get; }
        decimal GetIntegralValue(IFunction function, decimal rangeFrom, decimal rangeTo);
    }
}
