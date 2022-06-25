using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Core.Handlers;
using PCC.Frontend.Parser;
using System.Threading;


namespace PCC.Frontend.Test.Parser
{
    [TestClass]
    public class PccFunctionParserTest
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
        public void SourceCodeHaveAPublicFunctionNoParametersWithoutCodeBlock()
        {
            string sourceCode = "Public Function GetById () \n";
            sourceCode += "End Function \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 7);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPrivateFunctionNoParametersWithoutCodeBlock()
        {
            string sourceCode = "Private Function GetById () \n";
            sourceCode += "End Function \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.AreEqual(_pccParser.TokenCount, 7);
            Assert.IsFalse(_pccParser.NotificationsHandler.HasNotifications());
        }

        

        [TestMethod]
        public void SourceCodeHaveAPrivateFunctionFinishedByEndFunction()
        {
            string sourceCode = "Private Function GetById () \n";
            sourceCode += "End Sub \n";

            _pccParser.Parser(sourceCode, null, null, null, null);

            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
            Assert.AreEqual(_pccParser.NotificationsHandler.GetNotifications()[0].Description, "SYNTAX ERROR");
            Assert.AreEqual(_pccParser.NotificationsHandler.GetNotifications()[0].Line, 2);
        }
    }
}
