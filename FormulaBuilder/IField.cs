namespace FormulaBuilder
{
    using System;

    public interface IField : IStep
	{
        Guid GetId();
	}
}