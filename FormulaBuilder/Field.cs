namespace FormulaBuilder
{
    using System;

    public class Field : IField
    {
        private Guid id;

        public Field (Guid id)
        {
            this.id = id;
        }

        public Guid GetId ()
        {
            return this.id;
        }

        public override string ToString ()
        {
            return this.id.ToString ();
        }
    }
}