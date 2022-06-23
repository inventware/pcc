using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Identifiers.Directors;
using System;
using System.Threading;


namespace PCC.Identifiers.Test.Builders
{
    [TestClass]
    public class PccSingleVariableBuilderTest
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
        public void SingleVariableHaveAnIdLessThanZero()
        {
            long id = -1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        public void IdParentOfSingleVariableIsNull()
        {
            long id = 1;
            long? idParent = null;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.Id, 1);
            Assert.AreEqual(pccSingleVariable.IdParent, null);
            Assert.AreEqual(pccSingleVariable.Name, "variable");
            Assert.AreEqual(pccSingleVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccSingleVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccSingleVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccSingleVariable.Type, PccIdentifierType.SINGLE);
            Assert.AreEqual(pccSingleVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccSingleVariable.GetValueInStringFormat(), value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "If 'IdParent' field of identifier is not null, it should be a value greater than zero.")]
        public void SingleVariableHaveAnIdParentLessThanZero()
        {
            long id = 1;
            long idParent = -1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value.")]
        public void SingleVariableNameIsNull()
        {
            long id = 1;
            long idParent = 10;
            string name = null;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value")]
        public void SingleVariableNameIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = string.Empty;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void SingleVariableHaveAnInitialPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = -1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void SingleVariableHaveAFinalPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = -1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void SingleVariableHaveAnInitialPositionGreaterThanFinalPositionTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 2;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Scope' of identifier is undefined.")]
        public void SingleVariableScopeIsUndefined()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.UNDEFINED;
            string value = "33333";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }


        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void SingleVariableValueIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = null;

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.Id, 10);
            Assert.AreEqual(pccSingleVariable.IdParent, 1);
            Assert.AreEqual(pccSingleVariable.Name, "variable");
            Assert.AreEqual(pccSingleVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccSingleVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccSingleVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccSingleVariable.Type, PccIdentifierType.SINGLE);
            Assert.AreEqual(pccSingleVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccSingleVariable.GetValueInStringFormat()));
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void SingleVariableValueIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = string.Empty;

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.Id, 10);
            Assert.AreEqual(pccSingleVariable.IdParent, 1);
            Assert.AreEqual(pccSingleVariable.Name, "variable");
            Assert.AreEqual(pccSingleVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccSingleVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccSingleVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccSingleVariable.Type, PccIdentifierType.SINGLE);
            Assert.AreEqual(pccSingleVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccSingleVariable.GetValueInStringFormat()));
        }

        [TestMethod]
        public void CheckSingleVariableWithInvalidDecimalSymbol()
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
                PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The number has invalid characters.");
            }
        }

        [TestMethod]
        public void CheckSingleVariableWithInvalidScientificNotationValue()
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
                PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The allowed values of 'single' variable can range from -3.402823E38 " +
                "to -1.401298E-45 for negative numbers and 1.401298E-45 to 3.402823E38 for positive numbers.");
            }
        }

        [TestMethod]
        public void CheckSingleVariableWithAMinAllowedNegativeValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-1.401298E-45";  // Value less than min limit, values can range from -3.402823E38 to -1.401298E-45 for negative numbers.

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("0.0000000".Replace(".", _decimalSeparator)));
        }

        [TestMethod]
        public void CheckSingleVariableWithMaxAllowedNegativeValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-3.4028235E+38";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse(Single.MinValue.ToString()));
        }

        [TestMethod]
        public void CheckSingleVariableWithMinAllowedPositiveValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "3.4028235E38";  // Value less than min limit, values can range from -3.402823E38 to -1.401298E-45 for negative numbers.

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse(Single.MaxValue.ToString()));
        }

        [TestMethod]
        public void CheckSingleVariableWithMaxAllowedPositiveValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1.401298E-45";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("0.0000000".Replace(".", _decimalSeparator)));
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("0.0000000".Replace(".", _decimalSeparator)));
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("0.5678901".Replace(".", _decimalSeparator)));
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("12345678.9012312".Replace(".", _decimalSeparator)));
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("123456789012345678900000000000.0000000".Replace(".", _decimalSeparator)));
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("56789012341234567890.0000000".Replace(".", _decimalSeparator)));
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), double.Parse("123456789012312345.6789000".Replace(".", _decimalSeparator)));
        }


        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsExceptionWhenSingleVariableShouldBeTruncated()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0.12345678901234567890123456789";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            // Throws error:
            Assert.AreEqual(pccSingleVariable.GetValue(), 0.12345678901234567890123456789);
        }


        [TestMethod]
        public void TruncateNumberFrom20DecimalDigitsToSingleType()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0.12345678901234567890123456789";

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), Convert.ToDouble(0.1234567));
            double auxNumber1 = pccSingleVariable.GetValue() + 1;
            double auxNumber2 = Convert.ToDouble(0.1234567) + 1;
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

            PccSingleVariable pccSingleVariable = _director.BuildSingleVariable(id, idParent, name, initialPositionIntoTheCode,
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccSingleVariable);
            Assert.AreEqual(pccSingleVariable.GetValue(), Convert.ToDouble(0.9999999));
            double auxNumber1 = pccSingleVariable.GetValue() + 1;
            double auxNumber2 = Convert.ToDouble(0.9999999) + 1;
            Assert.AreEqual(auxNumber1, auxNumber2);
        }

    }
}
