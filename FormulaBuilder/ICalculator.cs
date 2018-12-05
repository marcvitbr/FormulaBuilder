namespace FormulaBuilder
{
    using System;

    public interface ICalculator
    {
        int UseFormulaWithValues(IFormula formula, params IValue[] values);
    }
}