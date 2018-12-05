namespace FormulaBuilder
{
    using System;

    public class Operator : IOperator
    {
        private const string MultiplicationOperator = "*";

        private string @operator;

        private Operator(string @operator)
        {
            this.@operator = @operator;
        }

        public static Operator FromString(string operatorAsString)
        {
            if (IsNotAValidOperator(operatorAsString))
            {
                throw new ArgumentException ("The operator is not valid");
            }

            return new Operator (operatorAsString);
        }

        private static bool IsNotAValidOperator(string @operator)
        {
            return string.IsNullOrWhiteSpace (@operator) || !@operator.Equals (MultiplicationOperator);
        }

        public override string ToString ()
        {
            return this.@operator;
        }
    }
}