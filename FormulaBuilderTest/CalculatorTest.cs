using FormulaBuilder;
using System.Collections.Generic;

namespace FormulaBuilderTest
{
    using System;
    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class CalculatorTest
    {
        private static readonly Guid GuidField1 = Guid.NewGuid();
        private static readonly Guid GuidField2 = Guid.NewGuid();

        [Test]
        public void ExecuteAFormulaAndGetResult()
        {
            var formulaMock = new Mock<IFormula> ();
            formulaMock.Setup (f => f.AllFields ()).Returns (this.MultiplicationFields ());
            formulaMock.Setup (f => f.AllSteps ()).Returns (this.MultiplicationSteps ());

            var valueField1Mock = new Mock<IValue> ();
            valueField1Mock.Setup (v => v.GetId ()).Returns (GuidField1);
            valueField1Mock.Setup (v => v.GetValue ()).Returns (5);

            var valueField2Mock = new Mock<IValue> ();
            valueField2Mock.Setup (v => v.GetId ()).Returns (GuidField2);
            valueField2Mock.Setup (v => v.GetValue ()).Returns (2);

            var expressionParserMock = new Mock<IExpressionParser> ();
            expressionParserMock.Setup (ep => ep.Evaluate ("5*2")).Returns (10);

            var calculator = new Calculator (expressionParserMock.Object);

            var result = calculator.UseFormulaWithValues (
                formulaMock.Object,
                valueField1Mock.Object,
                valueField2Mock.Object);

            Assert.AreEqual (10, result, "The multiplication of 5 and 2 should be 10");
        }

        private IEnumerable<IField> MultiplicationFields ()
        {
            var fields = new List<Field> ();

            fields.Add(new Field(GuidField1));
            fields.Add(new Field(GuidField2));

            return fields;
        }

        private IEnumerable<IStep> MultiplicationSteps ()
        {
            var steps = new List<IStep> ();

            steps.Add (new Field (GuidField1));
            steps.Add (Operator.FromString ("*"));
            steps.Add (new Field (GuidField2));

            return steps;
        }
    }
}