using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Identifiers.Directors;
using System;
using System.Threading;


namespace PCC.Identifiers.Test.Builders
{
    [TestClass]
    public class PccDoubleVariableBuilderTest
    {
        private PccVariableDirector _director;
        private string _decimalSeparator;

        [TestInitialize]
        public void Initialize()
        {
            _director = new PccVariableDirector();
            _decimalSeparator = Convert.ToString(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Id' field of identifier should be a value greater than zero.")]
        public void DoubleVariableHaveAnIdLessThanZero()
        {
            long id = -1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        public void IdParentOfDoubleVariableIsNull()
        {
            long id = 1;
            long? idParent = null;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.Id, 1);
            Assert.AreEqual(pccDoubleVariable.IdParent, null);
            Assert.AreEqual(pccDoubleVariable.Name, "variable");
            Assert.AreEqual(pccDoubleVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccDoubleVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccDoubleVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccDoubleVariable.Type, PccIdentifierType.DOUBLE);
            Assert.AreEqual(pccDoubleVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccDoubleVariable.GetValueInStringFormat(), value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "If 'IdParent' field of identifier is not null, it should be a value greater than zero.")]
        public void DoubleVariableHaveAnIdParentLessThanZero()
        {
            long id = 1;
            long idParent = -1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'IdParent' field of identifier can't be equals to " +
            "'Id' field. The son variable should be different of parent variable.")]
        public void IdCantBeEqualsToIdParent()
        {
            long id = 1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value.")]
        public void DoubleVariableNameIsNull()
        {
            long id = 1;
            long idParent = 10;
            string name = null;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value")]
        public void DoubleVariableNameIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = string.Empty;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void DoubleVariableHaveAnInitialPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = -1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void DoubleVariableHaveAFinalPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = -1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void DoubleVariableHaveAnInitialPositionGreaterThanFinalPositionTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 2;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Scope' of identifier is undefined.")]
        public void DoubleVariableScopeIsUndefined()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.UNDEFINED;
            string value = "33333";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }


        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void DoubleVariableValueIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = null;

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.Id, 10);
            Assert.AreEqual(pccDoubleVariable.IdParent, 1);
            Assert.AreEqual(pccDoubleVariable.Name, "variable");
            Assert.AreEqual(pccDoubleVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccDoubleVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccDoubleVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccDoubleVariable.Type, PccIdentifierType.DOUBLE);
            Assert.AreEqual(pccDoubleVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccDoubleVariable.GetValueInStringFormat()));
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void DoubleVariableValueIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = string.Empty;

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.Id, 10);
            Assert.AreEqual(pccDoubleVariable.IdParent, 1);
            Assert.AreEqual(pccDoubleVariable.Name, "variable");
            Assert.AreEqual(pccDoubleVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccDoubleVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccDoubleVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccDoubleVariable.Type, PccIdentifierType.DOUBLE);
            Assert.AreEqual(pccDoubleVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccDoubleVariable.GetValueInStringFormat()));
        }

        [TestMethod]
        public void CheckDoubleVariableWithInvalidDecimalSymbol()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.LOCAL;
            string value = "-4,94065645841246544"; //<-- 'Using 'comma' rather than 'dot'.

            try
            {
                PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The number has invalid characters.");
            }
        }

        [TestMethod]
        public void CheckDoubleVariableWithInvalidScientificNotationValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.LOCAL;
            string value = "-3.402823EE38"; //<-- '...EE38' simulates typing error.

            try
            {
                PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The allowed values of 'single' variable can range from -4.94065645841246544E-324 to " +
                    "-1.79769313486231570E308 for negative numbers and 1.79769313486231570E308 to 4.94065645841246544E-324 " +
                    "for positive numbers.");
            }
        }

        [TestMethod]
        public void CheckDoubleVariableWithAMinAllowedNegativeValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-4.94065645841246544E-324";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), double.Parse("0.000000000000000".Replace(".", _decimalSeparator)));
        }

        [TestMethod]
        public void CheckDoubleVariableWithMaxAllowedNegativeValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-1.79769313486231570E308";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), double.MinValue);
        }

        [TestMethod]
        public void CheckDoubleVariableWithMinAllowedPositiveValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1.79769313486231570E308";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), double.MaxValue);
        }

        [TestMethod]
        public void CheckDoubleVariableWithMaxAllowedPositiveValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "4.94065645841246544E-324";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), double.Parse("0.000000000000000".Replace(".", _decimalSeparator)));
        }


        [TestMethod]
        public void TruncateScientificNotationForNegativeNumberWhenNumberOfSignificantDigitsLenght_IsGreaterThan_IntegerPartNumberLenght()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1234567890.1234567890E-20";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), double.Parse("0.000000000012345".Replace(".", _decimalSeparator)));
        }

        [TestMethod]
        public void TruncateScientificNotationForNegativeNumberWhenNumberOfSignificantDigitsLenght_IsEqualsTo_IntegerPartNumberLenght()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "5678901234.1234567890E-10";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), double.Parse("0.567890123412345".Replace(".", _decimalSeparator)));
        }

        [TestMethod]
        public void TruncateScientificNotationForNegativeNumberWhenNumberOfSignificantDigitsLenght_IsLessThan_IntegerPartNumberLenght()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1234567890123.1234567890E-5";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), double.Parse("12345678.901231234567890".Replace(".", _decimalSeparator)));
        }


        [TestMethod]
        public void TruncateScientificNotationForPositiveNumberWhenNumberOfSignificantDigitsLenght_IsGreaterThan_IntegerPartNumberLenght()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1234567890.1234567890E+20";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), 
                double.Parse("123456789012345678900000000000.000000000000000".Replace(".", _decimalSeparator)));
        }

        [TestMethod]
        public void TruncateScientificNotationForPositiveNumberWhenNumberOfSignificantDigitsLenght_IsEqualsTo_IntegerPartNumberLenght()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "5678901234.1234567890E+10";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), 
                double.Parse("56789012341234567890.000000000000000".Replace(".", _decimalSeparator)));
        }

        [TestMethod]
        public void TruncateScientificNotationForPositiveNumberWhenNumberOfSignificantDigitsLenght_IsLessThan_IntegerPartNumberLenght()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1234567890123.1234567890E5";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), 
                double.Parse("123456789012312345.678900000000000".Replace(".", _decimalSeparator)));
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsExceptionWhenDoubleVariableShouldBeTruncated()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0.12345678901234567890123456789";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            // Throws error:
            Assert.AreEqual(pccDoubleVariable.GetValue(), 0.12345678901234567890123456789);
        }


        [TestMethod]
        public void TruncateNumberFrom30DecimalDigitsToSingleType()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0.123456789012345678901234567890";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), Convert.ToDouble("0.123456789012345".Replace(".", _decimalSeparator)));
            double auxNumber1 = pccDoubleVariable.GetValue() + 1;
            double auxNumber2 = Convert.ToDouble("0.123456789012345".Replace(".", _decimalSeparator)) + 1;
            Assert.AreEqual(auxNumber1, auxNumber2);
        }

        [TestMethod]
        public void TruncateNumberFrom10DecimalDigitsOf9ToSingleType()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0.9999999999";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), Convert.ToDouble("0.9999999999".Replace(".", _decimalSeparator)));
            double auxNumber1 = pccDoubleVariable.GetValue() + 1;
            double auxNumber2 = Convert.ToDouble("0.9999999999".Replace(".", _decimalSeparator)) + 1;
            Assert.AreEqual(auxNumber1, auxNumber2);
        }

        [TestMethod]
        public void TruncateNumberFrom15DecimalDigitsOf9ToSingleType()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0.999999999999999";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), Convert.ToDouble("0.999999999999999".Replace(".", _decimalSeparator)));
            double auxNumber1 = pccDoubleVariable.GetValue() + 1;
            double auxNumber2 = Convert.ToDouble("0.999999999999999".Replace(".", _decimalSeparator)) + 1;
            Assert.AreEqual(auxNumber1, auxNumber2);
        }

        [TestMethod]
        public void TruncateNumberFrom25DecimalDigitsOf9ToSingleType()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0.9999999999999999999999999";

            PccDoubleVariable pccDoubleVariable = _director.BuildDoubleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccDoubleVariable);
            Assert.AreEqual(pccDoubleVariable.GetValue(), 
                Convert.ToDouble("0.999999999999999".Replace(".", _decimalSeparator)));
            double auxNumber1 = pccDoubleVariable.GetValue() + 1;
            double auxNumber2 = Convert.ToDouble("0.999999999999999".Replace(".", _decimalSeparator)) + 1;
            Assert.AreEqual(auxNumber1, auxNumber2);
        }
    }
}
