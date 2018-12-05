namespace FormulaBuilder
{
    using System;

    public interface IValue
    {
        Guid GetId();
        int GetValue();
    }
}