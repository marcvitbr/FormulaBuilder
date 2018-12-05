namespace FormulaBuilderTest
{
    using System;
    using FormulaBuilder;
    using NUnit.Framework;

    [TestFixture]
    public class FormulaTest
    {
        private static readonly Guid GuidField1 = Guid.NewGuid();
        private static readonly Guid GuidField2 = Guid.NewGuid();

        private Formula multiplication;

        [SetUp]
        public void Initialize()
        {
            this.multiplication = new Formula ();
        }

        [Test]
        public void AddingFormulaStepsShouldRepresentTheStructureOfTheFormula()
        {
            this.multiplication.AddField (new Field (GuidField1));
            this.multiplication.AddOperator (Operator.FromString("*"));
            this.multiplication.AddField (new Field (GuidField2));

            var expectedStringRepresentation = $"{GuidField1}*{GuidField2}";

            Assert.AreEqual (expectedStringRepresentation, this.multiplication.ToString (), "The structure of the formula is not the expected");
        }
    }
}