using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Identifiers.Directors;


namespace PCC.Identifiers.Test.Builders
{
    [TestClass]
    public class PccLongVariableBuilderTest
    {
        private PccVariableDirector _director;

        [TestInitialize]
        public void Initialize()
        {
            _director = new PccVariableDirector();
        }

        [TestMethod]
        public void LongVariableCantBeNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name, initialPositionIntoTheCode, 
                finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccLongVariable);
            Assert.AreEqual(pccLongVariable.Id, 10);
            Assert.AreEqual(pccLongVariable.IdParent, 1);
            Assert.AreEqual(pccLongVariable.Name, "variable");
            Assert.AreEqual(pccLongVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccLongVariable.Type, PccIdentifierType.LONG);
            Assert.AreEqual(pccLongVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccLongVariable.GetValueInStringFormat(), value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Id' field of identifier should be a value greater than zero.")]
        public void LongVariableHaveAnIdLessThanZero()
        {
            long id = -1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        public void IdParentOfLongVariableIsNull()
        {
            long id = 1;
            long? idParent = null;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccLongVariable);
            Assert.AreEqual(pccLongVariable.Id, 1);
            Assert.AreEqual(pccLongVariable.IdParent, null);
            Assert.AreEqual(pccLongVariable.Name, "variable");
            Assert.AreEqual(pccLongVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccLongVariable.Type, PccIdentifierType.LONG);
            Assert.AreEqual(pccLongVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccLongVariable.GetValueInStringFormat(), value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), 
            "If 'IdParent' field of identifier is not null, it should be a value greater than zero.")]
        public void LongVariableHaveAnIdParentLessThanZero()
        {
            long id = 1;
            long idParent = -1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "0";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
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

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value.")]
        public void LongVariableNameIsNull()
        {
            long id = 1;
            long idParent = 10;
            string name = null;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value")]
        public void LongVariableNameIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = string.Empty;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void LongVariableHaveAnInitialPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = -1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void LongVariableHaveAFinalPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = -1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void LongVariableHaveAnInitialPositionGreaterThanFinalPositionTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 2;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Scope' of identifier is undefined.")]
        public void LongVariableScopeIsUndefined()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.UNDEFINED;
            string value = "33333";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
        }


        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void LongVariableValueIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = null;

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccLongVariable);
            Assert.AreEqual(pccLongVariable.Id, 10);
            Assert.AreEqual(pccLongVariable.IdParent, 1);
            Assert.AreEqual(pccLongVariable.Name, "variable");
            Assert.AreEqual(pccLongVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccLongVariable.Type, PccIdentifierType.LONG);
            Assert.AreEqual(pccLongVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccLongVariable.GetValueInStringFormat()));
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void LongVariableValueIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = string.Empty;

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccLongVariable);
            Assert.AreEqual(pccLongVariable.Id, 10);
            Assert.AreEqual(pccLongVariable.IdParent, 1);
            Assert.AreEqual(pccLongVariable.Name, "variable");
            Assert.AreEqual(pccLongVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccLongVariable.Type, PccIdentifierType.LONG);
            Assert.AreEqual(pccLongVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccLongVariable.GetValueInStringFormat()));
        }

        [TestMethod]
        public void LongVariableHaveAValueLessThanAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.LOCAL;
            string value = "-2147483649"; //<-- Value out of range (The allowed values of 'long' variable can range from -2147483648 to 2147483647).

            try
            {
                PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, string.Format("It's not possible to convert the variable '{0}' which " +
                    "value is {1}, for the 'long' type.", name, value, PccIdentifierType.LONG.ToString().ToLower()) +
                    " - The allowed values of 'long' variable can range from -2147483648 to 2147483647.");
                Assert.IsInstanceOfType(err, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void LongVariableHaveAValueGreaterThanAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "counter";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.LOCAL;
            string value = "2147483648"; //<-- Value out of range (The allowed values of 'long' variable can range from -2147483648 to 2147483647).

            try
            {
                PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, string.Format("It's not possible to convert the variable '{0}' which " +
                    "value is {1}, for the 'long' type.", name, value, PccIdentifierType.LONG.ToString().ToLower()) +
                    " - The allowed values of 'long' variable can range from -2147483648 to 2147483647.");
                Assert.IsInstanceOfType(err, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void LongVariableeHaveAMinAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "-2147483648";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccLongVariable);
            Assert.AreEqual(pccLongVariable.Id, 10);
            Assert.AreEqual(pccLongVariable.IdParent, 1);
            Assert.AreEqual(pccLongVariable.Name, "variable");
            Assert.AreEqual(pccLongVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccLongVariable.Type, PccIdentifierType.LONG);
            Assert.AreEqual(pccLongVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccLongVariable.GetValueInStringFormat(), value);
        }

        [TestMethod]
        public void LongVariableeHaveAMaxAllowedValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "2147483647";

            PccLongVariable pccLongVariable = _director.BuildLongVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value);

            Assert.IsNotNull(pccLongVariable);
            Assert.AreEqual(pccLongVariable.Id, 10);
            Assert.AreEqual(pccLongVariable.IdParent, 1);
            Assert.AreEqual(pccLongVariable.Name, "variable");
            Assert.AreEqual(pccLongVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccLongVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccLongVariable.Type, PccIdentifierType.LONG);
            Assert.AreEqual(pccLongVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.AreEqual(pccLongVariable.GetValueInStringFormat(), value);
        }
    }
}
