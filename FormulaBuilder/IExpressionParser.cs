namespace FormulaBuilder
{
    using System;

    public interface IExpressionParser
    {
        int Evaluate(string expression);
    }
}