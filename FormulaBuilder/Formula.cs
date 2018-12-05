namespace FormulaBuilder
{
    using System;
    using System.Collections.Generic;

    public class Formula : IFormula
    {
        private Queue<IStep> structure;

        public Formula ()
        {
            this.structure = new Queue<IStep> ();
        }

        public void AddField (IField field)
        {
            this.structure.Enqueue (field);
        }

        public void AddOperator (IOperator @operator)
        {
            this.structure.Enqueue (@operator);
        }

        public IEnumerable<IField> AllFields ()
        {
            return null;
        }

        public IEnumerable<IStep> AllSteps()
        {
            return this.structure;
        }

        public override string ToString ()
        {
            var result = string.Empty;

            while (this.structure.Count > 0)
            {
                result += this.structure.Dequeue ().ToString ();
            }

            return result;
        }
    }
}