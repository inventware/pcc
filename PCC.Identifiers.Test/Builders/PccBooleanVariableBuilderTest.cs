using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Identifiers.Directors;


namespace PCC.Identifiers.Test.Builders
{
    [TestClass]
    public class PccBooleanVariableBuilderTest
    {
        private PccVariableDirector _director;

        [TestInitialize]
        public void Initialize()
        {
            _director = new PccVariableDirector();
        }

        [TestMethod]
        public void BooleanVariableAllFilledFields()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "false";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.Id, 10);
            Assert.AreEqual(pccBooleanVariable.IdParent, 1);
            Assert.AreEqual(pccBooleanVariable.Name, "variable");
            Assert.AreEqual(pccBooleanVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccBooleanVariable.Type, PccIdentifierType.BOOLEAN);
            Assert.AreEqual(pccBooleanVariable.Class, PccIdentifierClass.VARIABLE);
            bool auxBoolean = true;
            Assert.IsTrue(bool.TryParse(pccBooleanVariable.GetValueInStringFormat(), out auxBoolean));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Id' field of identifier should be a value greater than zero.")]
        public void BooleanVariableHaveAnIdLessThanZero()
        {
            long id = -1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        public void IdParentOfBooleanVariableIsNull()
        {
            long id = 1;
            long? idParent = null;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.Id, 1);
            Assert.AreEqual(pccBooleanVariable.IdParent, null);
            Assert.AreEqual(pccBooleanVariable.Name, "variable");
            Assert.AreEqual(pccBooleanVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccBooleanVariable.Type, PccIdentifierType.BOOLEAN);
            Assert.AreEqual(pccBooleanVariable.Class, PccIdentifierClass.VARIABLE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "If 'IdParent' field of identifier is not null, it should be a value greater than zero.")]
        public void BooleanVariableHaveAnIdParentLessThanZero()
        {
            long id = 1;
            long idParent = -1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0A";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
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
            string value = "0A";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value.")]
        public void BooleanVariableNameIsNull()
        {
            long id = 1;
            long idParent = 10;
            string name = null;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value")]
        public void BooleanVariableNameIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = string.Empty;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void BooleanVariableHaveAnInitialPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = -1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void BooleanVariableHaveAFinalPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = -1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void BooleanVariableHaveAnInitialPositionGreaterThanFinalPositionTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 2;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "Text";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Scope' of identifier is undefined.")]
        public void BooleanVariableScopeIsUndefined()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.UNDEFINED;
            string value = "Text";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }


        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void BooleanVariableValueIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = null;
            const bool INITIAL_DEFAULT_BOOLEAN_VALUE_FOR_BASIC_LANGUAGE = false;

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.Id, 10);
            Assert.AreEqual(pccBooleanVariable.IdParent, 1);
            Assert.AreEqual(pccBooleanVariable.Name, "variable");
            Assert.AreEqual(pccBooleanVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccBooleanVariable.Type, PccIdentifierType.BOOLEAN);
            Assert.AreEqual(pccBooleanVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccBooleanVariable.GetValue(), INITIAL_DEFAULT_BOOLEAN_VALUE_FOR_BASIC_LANGUAGE);
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void BooleanVariableValueIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = string.Empty;
            const bool INITIAL_DEFAULT_BOOLEAN_VALUE_FOR_BASIC_LANGUAGE = false;

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.Id, 10);
            Assert.AreEqual(pccBooleanVariable.IdParent, 1);
            Assert.AreEqual(pccBooleanVariable.Name, "variable");
            Assert.AreEqual(pccBooleanVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccBooleanVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccBooleanVariable.Type, PccIdentifierType.BOOLEAN);
            Assert.AreEqual(pccBooleanVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccBooleanVariable.GetValue(), INITIAL_DEFAULT_BOOLEAN_VALUE_FOR_BASIC_LANGUAGE);
        }

        [TestMethod]
        public void BooleanVariableValueWhenValueIsInvalidText()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "T";

            try
            {
                PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid boolean value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void BooleanVariableValueWhenValueIsInvalidNumber()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "2";

            try
            {
                PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid boolean value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void BooleanVariableValueWhenValueIsTheNumberOne()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.GetValue(), true);
        }

        [TestMethod]
        public void BooleanVariableValueWhenValueIsTheNumberOneNegative()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-1";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.GetValue(), true);
        }

        [TestMethod]
        public void BooleanVariableValueWhenValueIsTheNumberZero()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.GetValue(), false);
        }

        [TestMethod]
        public void BooleanVariableValueWhenValueIsFalse()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "fAlSe";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.GetValue(), false);
        }

        [TestMethod]
        public void BooleanVariableValueWhenValueIsTrue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "TrUe";

            PccBooleanVariable pccBooleanVariable = _director.BuildBooleanVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccBooleanVariable);
            Assert.AreEqual(pccBooleanVariable.GetValue(), true);
        }
    }
}
