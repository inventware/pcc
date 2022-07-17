using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Core.Handlers;
using PCC.Frontend.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PCC.Frontend.Test.Parser
{
    [TestClass]
    public class PccSubroutineParserTest
    {
        IPccParser _pccParser;


        [TestInitialize]
        public void Initialize()
        {
            // Injection Dependency Objects by the Constructor Parameters
            _pccParser = new PccParser(new PccRegExHandler(), new PccSubroutineParser(), new PccFunctionParser(),
                new PccParserNotificationHandler(), new CancellationTokenSource());
        }


        [TestMethod]
        public void SourceCodeHaveAPublicSub()
        {
            _pccParser.Parser("Public Sub", null, null, null, null);

            // Error: Incomplete block code
            Assert.AreEqual(_pccParser.TokenCount, 2);
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubFollowedByIdentifierAndBracket()
        {
            _pccParser.Parser("Public Sub GetById (", null, null, null, null);

            // Error: Incomplete block code
            Assert.AreEqual(_pccParser.TokenCount, 4);
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
            Assert.AreEqual(_pccParser.NotificationsHandler.GetNotifications()[0].Description, "SYNTAX ERROR");
            Assert.AreEqual(_pccParser.NotificationsHandler.GetNotifications()[0].Line, 1);
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubNoParametersWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById () \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 7);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubNoParametersWithParameterNoAsNoTypeWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (parameter) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 8);
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubNoParametersWithParameterNoTypeWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (parameter As) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 9);
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneIntegerParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value as Integer) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneLowerLongParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value as long) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneUPPERLongParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value as LONG) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneSingleParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value as Single) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneDoubleParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value as double) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneStringParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (name as String) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneUnderlineStringParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (name_customer as String) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneBooleanParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (isActive as Boolean) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneDateParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (currentDate as Date) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneObjectParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (myClass as Object) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneVariantParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (anyVariable as variant) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneUnknownTypeParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (anyVariable as UnknownType) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 10);
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneUnknownTypeParameterWithoutCloseBracketWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (anyVariable as UnknownType \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 9);
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithTwoIntegerParametersWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value1 as Integer, value2 as Integer) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 14);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneIntegerParameterAndOneLongParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value1 as Integer, value2 as long) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 14);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneIntegerParameterAndOneLongParameterAndOneSingleParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value1 as Integer, value2 as long, value3 as single) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 18);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneIntegerParameterAndOneLongParameterAndOneSingleAndOneDoubleParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value1 as Integer, value2 as long, value3 as double) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 18);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneIntegerParameterAndOneLongParameterAndOneSingleAndOneDoubleParameterAndOneStringParameterAndOneDateParameterAndOneBooleanParameterAndOneObjetParameterAndOneVariantParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (value1 as Integer, value2 as long, value3 as double, " + 
                "value4 as string, value5 as date, value6 as boolean, value7 as OBJECT,  value8 as Variant) \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 38);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneIntegerParameterAndByrefOneLongParameterAndOneByvalSingleAndOneDoubleParameterAndOneByrefStringParameterAndOneDateParameterAndOneBooleanParameterAndOneObjetParameterAndOneByvalVariantParameterWithoutCodeBlock()
        {
            string sourceCode = "Public Sub GetById (byref value1 as Integer, value2 as long, byval value3 as single, " + //18
                "value4 as double, byref value5 as string, value5 as date, value6 as boolean, value7 as OBJECT,  " + //21
                "byval value8 as Variant) \n"; //5
            sourceCode += "End Sub \n"; //2

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 46);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }


        [TestMethod]
        public void SourceCodeHaveAPrivateSubNoParametersWithoutCodeBlock()
        {
            string sourceCode = "Private Sub GetById () \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 7);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPrivateSubFinishedByEndFunction()
        {
            string sourceCode = "Private Sub GetById () \n";
            sourceCode += "End Function \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
            Assert.AreEqual(_pccParser.NotificationsHandler.GetNotifications()[0].Description, "SYNTAX ERROR");
            Assert.AreEqual(_pccParser.NotificationsHandler.GetNotifications()[0].Line, 2);
        }
    }
}
