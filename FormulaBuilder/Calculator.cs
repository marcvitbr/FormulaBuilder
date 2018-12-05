namespace FormulaBuilder
{
    using System;

    public class Calculator : ICalculator
    {
        private IExpressionParser parser;

        public Calculator (IExpressionParser parser)
        {
            this.parser = parser;
        }

        public int UseFormulaWithValues (IFormula formula, params IValue[] values)
        {
            var expression = "";

            var steps = formula.AllSteps ();

            foreach (IStep step in steps)
            {
                if (step is IField)
                {
                    expression += this.ValueForField (step as IField, values);
                    continue;
                }

                expression += step.ToString ();
            }

            return this.parser.Evaluate (expression);
        }

        private string ValueForField(IField field, IValue[] values)
        {
            var id = field.GetId ();

            foreach (IValue value in values)
            {
                if (value.GetId ().Equals (id))
                {
                    return value.GetValue ().ToString ();
                }
            }

            return string.Empty;
        }
    }
}