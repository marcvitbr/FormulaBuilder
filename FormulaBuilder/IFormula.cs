namespace FormulaBuilder
{
    using System.Collections.Generic;

	public interface IFormula
	{
        void AddField(IField field);
        void AddOperator(IOperator @operator);
        IEnumerable<IField> AllFields ();
        IEnumerable<IStep> AllSteps();
	}
}