using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Identifiers.Directors;


namespace PCC.Identifiers.Test.Builders
{
    [TestClass]
    public class PccDatetimeVariableBuilderTest
    {
        private PccVariableDirector _director;

        [TestInitialize]
        public void Initialize()
        {
            _director = new PccVariableDirector();
        }

        [TestMethod]
        public void DatetimeVariableAllFilledFieldsCorrectlyWhenDataFormatIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12/21/2021 14:32:51";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);

            Assert.IsNotNull(pccDatetimeVariable);
            Assert.AreEqual(pccDatetimeVariable.Id, 10);
            Assert.AreEqual(pccDatetimeVariable.IdParent, 1);
            Assert.AreEqual(pccDatetimeVariable.Name, "variable");
            Assert.AreEqual(pccDatetimeVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccDatetimeVariable.Type, PccIdentifierType.DATE);
            Assert.AreEqual(pccDatetimeVariable.Class, PccIdentifierClass.VARIABLE);

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 21);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2021);
            Assert.AreEqual(auxBoolean.Hour, 14);
            Assert.AreEqual(auxBoolean.Minute, 32);
            Assert.AreEqual(auxBoolean.Second, 51);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Id' field of identifier should be a value greater than zero.")]
        public void DatetimeVariableHaveAnIdLessThanZero()
        {
            long id = -1;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        public void IdParentOfDatetimeVariableIsNull()
        {
            long id = 1;
            long? idParent = null;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12-21-2021 00:00:00";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);

            Assert.IsNotNull(pccDatetimeVariable);
            Assert.AreEqual(pccDatetimeVariable.Id, 1);
            Assert.AreEqual(pccDatetimeVariable.IdParent, null);
            Assert.AreEqual(pccDatetimeVariable.Name, "variable");
            Assert.AreEqual(pccDatetimeVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccDatetimeVariable.Type, PccIdentifierType.DATE);
            Assert.AreEqual(pccDatetimeVariable.Class, PccIdentifierClass.VARIABLE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "If 'IdParent' field of identifier is not null, it should be a value greater than zero.")]
        public void DatetimeVariableHaveAnIdParentLessThanZero()
        {
            long id = 1;
            long idParent = -1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
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
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value.")]
        public void DatetimeVariableNameIsNull()
        {
            long id = 1;
            long idParent = 10;
            string name = null;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Name' field of identifier should'nt be a empty or null value")]
        public void DatetimeVariableNameIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = string.Empty;
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void DatetimeVariableHaveAnInitialPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = -1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void DatetimeVariableHaveAFinalPositionLessThanZeroTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = -1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'initial' and 'final' position of identifier have an invalid values.")]
        public void DatetimeVariableHaveAnInitialPositionGreaterThanFinalPositionTest()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 2;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "The 'Scope' of identifier is undefined.")]
        public void DatetimeVariableScopeIsUndefined()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.UNDEFINED;
            string value = "21-12-2021";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
        }

        [TestMethod]
        public void DatetimeVariableWhenDataFormatDoesNotExists()
        {
            try
            {
                long id = 10;
                long idParent = 1;
                string name = "variable";
                int initialPositionIntoTheCode = 1;
                int finalPositionIntoTheCode = 1;
                PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
                string dataFormat = "yyyymmdddd";   //<-- This data format does not contained in _listOfDataFormats of DatetimeHasAValidFormatValidator class.
                string value = "12/21/2021";    

                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, dataFormat);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime format.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }


        #region DATA FORMAT IS NULL OR EMPTY

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void DatetimeVariableValueIsNull()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = null;

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);

            Assert.IsNotNull(pccDatetimeVariable);
            Assert.AreEqual(pccDatetimeVariable.Id, 10);
            Assert.AreEqual(pccDatetimeVariable.IdParent, 1);
            Assert.AreEqual(pccDatetimeVariable.Name, "variable");
            Assert.AreEqual(pccDatetimeVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccDatetimeVariable.Type, PccIdentifierType.DATE);
            Assert.AreEqual(pccDatetimeVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccDatetimeVariable.GetValueInStringFormat()));
        }

        /// <summary>
        /// IMPORTANT: 
        ///     In Basic a variable should be instanced with NULL/EMPTY value (e.g.: Dim nameVariable as Date).
        /// </summary>
        [TestMethod]
        public void DatetimeVariableValueIsEmpty()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = string.Empty;

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);

            Assert.IsNotNull(pccDatetimeVariable);
            Assert.AreEqual(pccDatetimeVariable.Id, 10);
            Assert.AreEqual(pccDatetimeVariable.IdParent, 1);
            Assert.AreEqual(pccDatetimeVariable.Name, "variable");
            Assert.AreEqual(pccDatetimeVariable.InitialPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.FinalPositionIntoTheCode, 1);
            Assert.AreEqual(pccDatetimeVariable.Scope, PccIdentifierScope.GLOBAL);
            Assert.AreEqual(pccDatetimeVariable.Type, PccIdentifierType.DATE);
            Assert.AreEqual(pccDatetimeVariable.Class, PccIdentifierClass.VARIABLE);
            Assert.IsTrue(string.IsNullOrEmpty(pccDatetimeVariable.GetValueInStringFormat()));
        }

        [TestMethod]
        public void DatetimeVariableValueIsAnInvalidValue()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1212/34-45";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
            }
        }

        [TestMethod]
        public void DatetimeVariableWhenDataFormatIsNullAndValueIsInAnotherFormat()
        {
            try
            {
                long id = 10;
                long idParent = 1;
                string name = "variable";
                int initialPositionIntoTheCode = 1;
                int finalPositionIntoTheCode = 1;
                PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
                string value = "12/21/2021";    //<-- No time values, the correct value is MMddyyyy HH:mm:ss

                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueIsAnInvalidValueForTheDay()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "11-32-2021";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
            }
        }

        [TestMethod]
        public void DatetimeVariableValueIsAnInvalidValueForTheMonth()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "13-30-45";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, string.Empty);
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
            }
        }

        #endregion


        #region DATA FORMAT IS FILLED

        #region Short Date

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_YYYYMMDD()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "1913-12-11";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "yyyyMMdd");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 11);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 1913);
            Assert.AreEqual(auxBoolean.Hour, 0);
            Assert.AreEqual(auxBoolean.Minute, 0);
            Assert.AreEqual(auxBoolean.Second, 0);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidYearForTheFormat_YYYYMMDD()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "13-12-11";

            try
            { 
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "yyyyMMdd");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_MMDDyyyy()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12-31-2013";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "MMddyyyy");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 0);
            Assert.AreEqual(auxBoolean.Minute, 0);
            Assert.AreEqual(auxBoolean.Second, 0);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidMonthForTheFormat_MMddyyyy()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "13-31-2013";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "MMddyyyy");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_ddMMyyyy()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "31-12-2013";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "ddMMyyyy");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 0);
            Assert.AreEqual(auxBoolean.Minute, 0);
            Assert.AreEqual(auxBoolean.Second, 0);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidMonthForTheFormat_ddMMyyyy()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "13-31-2013";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "ddMMyyyy");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        #endregion

        #region Date + Time

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_yyyyMMddHHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "2013-12-31 12:45:56";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "yyyyMMddHHmmss");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidHourForTheFormat_yyyyMMddHHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "2013-12-31 25:45:56";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "yyyyMMddHHmmss");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_MMddyyyyHHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12-31-2013 12:45:56";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "MMddyyyyHHmmss");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidHourForTheFormat_MMddyyyyHHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12-31-2013 25:45:56";   //<-- Doesn't exists 25 hours.

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "MMddyyyyHHmmss");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_ddMMyyyyHHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "31-12-2013 12:45:56";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "ddMMyyyyHHmmss");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
        }

        [TestMethod]
        public void DatetimeVariableValueTimeNoSecondForTheFormat_ddMMyyyyHHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "31-12-2013   22:45";  //<-- Time no second.

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "ddMMyyyyHHmmss");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_yyyyMMddHHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "2013-12-31 12:45:56 123";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "yyyyMMddHHmmssfff");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
            Assert.AreEqual(auxBoolean.Millisecond, 123);
        }

        [TestMethod]
        public void DatetimeVariableValueNoMilisecondForTheFormat_yyyyMMddHHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "2013-12-31 12:45:56";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "yyyyMMddHHmmssfff");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_MMddyyyyHHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12-31-2013 12:45:56 456";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "MMddyyyyHHmmssfff");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
            Assert.AreEqual(auxBoolean.Millisecond, 456);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidMinutesForTheFormat_MMddyyyyHHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12-31-2013 12:60:56 456";   //<-- Minutes greater than 59

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "MMddyyyyHHmmssfff");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_ddMMyyyyHHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "31-12-2013 12:45:56 999";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "ddMMyyyyHHmmssfff");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Day, 31);
            Assert.AreEqual(auxBoolean.Month, 12);
            Assert.AreEqual(auxBoolean.Year, 2013);
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
            Assert.AreEqual(auxBoolean.Millisecond, 999);
        }

        [TestMethod]
        public void DatetimeVariableValueWithTwoDigitsForMillisecondsForTheFormat_ddMMyyyyHHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "31-12-2013 12:45:56 99";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "ddMMyyyyHHmmssfff");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        #endregion


        #region Time

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_HHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12:45:56";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "HHmmss");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidHourForTheFormat_HHmmss()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "25:45:56";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "HHmmss");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void DatetimeVariableValueForTheFormat_HHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "12:45:56 000";

            PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "HHmmssfff");

            DateTime auxBoolean = pccDatetimeVariable.GetValue();
            Assert.AreEqual(auxBoolean.Hour, 12);
            Assert.AreEqual(auxBoolean.Minute, 45);
            Assert.AreEqual(auxBoolean.Second, 56);
        }

        [TestMethod]
        public void DatetimeVariableValueWithInvalidMillisecondsForTheFormat_HHmmssfff()
        {
            long id = 10;
            long idParent = 1;
            string name = "variable";
            int initialPositionIntoTheCode = 1;
            int finalPositionIntoTheCode = 1;
            PccIdentifierScope identifierScope = PccIdentifierScope.GLOBAL;
            string value = "25:45:56 1234";

            try
            {
                PccDatetimeVariable pccDatetimeVariable = _director.BuildDatetimeVariable(id, idParent, name,
                    initialPositionIntoTheCode, finalPositionIntoTheCode, identifierScope, value, "HHmmssfff");
            }
            catch (Exception err)
            {
                Assert.AreEqual(err.Message, "The variable has an invalid datetime value.");
                Assert.IsInstanceOfType(err, typeof(ArgumentOutOfRangeException));
            }
        }

        #endregion

        #endregion
    }
}
