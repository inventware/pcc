using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Identifiers.Directors;

namespace PCC.Identifiers.Test.Builders
{
    [TestClass]
    public class PccIntegerVariableBuilderTest
    {
        private PccVariableDirector _director;

        [TestInitialize]
        public void Initialize()
        {
            _director = new PccVariableDirector();
        }

        [TestMethod]
        public void IntegerVariableCantBeNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name, 
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccIntegerVariable);
            Assert.AreEqual(pccIntegerVariable.Id, 10);
            Assert.AreEqual(pccIntegerVariable.IdParent, 1);
            Assert.AreEqual(pccIntegerVariable.Name, "variable");
            Assert.AreEqual(pccIntegerVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccIntegerVariable.Type, PccIdentifierType.INTEGER);
            Assert.AreEqual(pccIntegerVariable.Class, PccIdentifierClass.VARIABLE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Id' field of identifier should be a value greater than zero.")]
        public void IntegerVariableHaveAnIdLessThanZero()
        {
            long id = -1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        public void IdParentOfIntegerVariableIsNull()
        {
            long id = 1;
            long? idParent = null;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccIntegerVariable);
            Assert.AreEqual(pccIntegerVariable.Id, 1);
            Assert.AreEqual(pccIntegerVariable.IdParent, null);
            Assert.AreEqual(pccIntegerVariable.Name, "variable");
            Assert.AreEqual(pccIntegerVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccIntegerVariable.Type, PccIdentifierType.INTEGER);
            Assert.AreEqual(pccIntegerVariable.Class, PccIdentifierClass.VARIABLE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "If 'IdParent' field of identifier is not null, it should be a value greater than zero.")]
        public void IntegerVariableHaveAnIdParentLessThanZero()
        {
            long id = 1;
            long idParent = -1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
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
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value.")]
        public void IntegerVariableNameIsNull()
        {
            long id = 1;
            long idParent = 10;
            string name = null;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value")]
        public void IntegerVariableNameIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = string.Empty;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void IntegerVariableHaveAnInitialPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = -1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void IntegerVariableHaveAFinalPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = -1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void IntegerVariableHaveAnInitialPositionGreaterThanFinalPositionTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 2;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-1";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Scope' of identifier is undefined.")]
        public void IntegerVariableScopeIsUndefined()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.UNDEFINED;
            string value = "1";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }


        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void IntegerVariableValueIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = null;

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccIntegerVariable);
            Assert.AreEqual(pccIntegerVariable.Id, 10);
            Assert.AreEqual(pccIntegerVariable.IdParent, 1);
            Assert.AreEqual(pccIntegerVariable.Name, "variable");
            Assert.AreEqual(pccIntegerVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccIntegerVariable.Type, PccIdentifierType.INTEGER);
            Assert.AreEqual(pccIntegerVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccIntegerVariable.GetValueInStringFormat()));
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void IntegerVariableValueIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = string.Empty;

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccIntegerVariable);
            Assert.AreEqual(pccIntegerVariable.Id, 10);
            Assert.AreEqual(pccIntegerVariable.IdParent, 1);
            Assert.AreEqual(pccIntegerVariable.Name, "variable");
            Assert.AreEqual(pccIntegerVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccIntegerVariable.Type, PccIdentifierType.INTEGER);
            Assert.AreEqual(pccIntegerVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccIntegerVariable.GetValueInStringFormat()));
        }

        [TestMethod]
        public void IntegerVariableHaveAValueLessThanAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "counter";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.LOCAL;
            string value = "-32769"; //<-- Value out of range (The allowed values of 'integer' variable can range from -32768 to 32767)

            try
            {
                PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name, initialPositionIntoTheCode, 
                    finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, string.Format("It's not possible to convert the variable '{0}' which " +
                    "value is {1}, for the '{2}' type.", name, value, PccIdentifierType.INTEGER.ToString().ToLower()) +
                    " - The allowed values of 'integer' variable can range from -32768 to 32767.");
                Assert.IsInstanceOfType(err, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void IntegerVariableHaveAValueGreaterThanAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "counter";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.LOCAL;
            string value = "32768"; //<-- Value out of range (The allowed values of 'integer' variable can range from -32768 to 32767)

            try
            {
                PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name, 
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, string.Format("It's not possible to convert the variable '{0}' which " + 
                    "value is {1}, for the '{2}' type.", name, value, PccIdentifierType.INTEGER.ToString().ToLower()) +
                    " - The allowed values of 'integer' variable can range from -32768 to 32767.");
                Assert.IsInstanceOfType(err, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void IntegerVariableeHaveMinAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-32768";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name, initialPositionIntoTheCode, 
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccIntegerVariable);
            Assert.AreEqual(pccIntegerVariable.Id, 10);
            Assert.AreEqual(pccIntegerVariable.IdParent, 1);
            Assert.AreEqual(pccIntegerVariable.Name, "variable");
            Assert.AreEqual(pccIntegerVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccIntegerVariable.Type, PccIdentifierType.INTEGER);
            Assert.AreEqual(pccIntegerVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccIntegerVariable.GetValue().ToString(), value);
        }

        [TestMethod]
        public void IntegerVariableHaveMaxAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "32767";

            PccIntegerVariable pccIntegerVariable = _director.BuildIntegerVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccIntegerVariable);
            Assert.AreEqual(pccIntegerVariable.Id, 10);
            Assert.AreEqual(pccIntegerVariable.IdParent, 1);
            Assert.AreEqual(pccIntegerVariable.Name, "variable");
            Assert.AreEqual(pccIntegerVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccIntegerVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccIntegerVariable.Type, PccIdentifierType.INTEGER);
            Assert.AreEqual(pccIntegerVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccIntegerVariable.GetValue().ToString(), value);
        }
    }
}
