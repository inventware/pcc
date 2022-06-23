using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Core.Handlers;
using PCC.Frontend.Parser;
using System.Threading;


namespace PCC.Frontend.Test.Parser
{
    [TestClass]
    public class PccParserTest
    {
        IPccRegExHandler _pccRegExHandler;
        IPccParserNotificationHandler _notificationsHandler;
        CancellationTokenSource _cancellationTokenSource;


        [TestInitialize]
        public void Initialize()
        {
            _pccRegExHandler = new PccRegExHandler();
            _notificationsHandler = new PccParserNotificationHandler();
            _cancellationTokenSource = new CancellationTokenSource();
        }


        [TestMethod]
        public void SourceCodeIsAEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            pccParser.Parser("");
            Assert.AreEqual(pccParser.TokenCount, 0);
        }

        [TestMethod]
        public void SourceCodeHaveAPublicToken()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            pccParser.Parser("Public");
            
            // Error: Incomplete block code
            Assert.AreEqual(pccParser.TokenCount, 1);
            Assert.IsTrue(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSub()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            pccParser.Parser("Public Sub");
            
            // Error: Incomplete block code
            Assert.AreEqual(pccParser.TokenCount, 2);
            Assert.IsTrue(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicFollowedByIdentifier()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            pccParser.Parser("Public GetById");
            
            // Error: Incomplete block code
            Assert.IsTrue(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubFollowedByIdentifierAndBracket()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            pccParser.Parser("Public Sub GetById (");
            
            // Error: Incomplete block code
            Assert.AreEqual(pccParser.TokenCount, 4);
            Assert.IsTrue(pccParser.NotificationsHandler.HasNotifications());
            Assert.AreEqual(pccParser.NotificationsHandler.GetNotifications()[0].Description, "SYNTAX ERROR");
            Assert.AreEqual(pccParser.NotificationsHandler.GetNotifications()[0].Line, 1);
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubNoParametersAndEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Public Sub GetById () \n";
            sourceCode += "End Sub \n";

            pccParser.Parser(sourceCode);

            Assert.AreEqual(pccParser.TokenCount, 7);
            Assert.IsFalse(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneIntegerParameterAndEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Public Sub GetById (value as Integer) \n";
            sourceCode += "End Sub \n";

            pccParser.Parser(sourceCode);

            Assert.AreEqual(pccParser.TokenCount, 10);
            Assert.IsFalse(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneStringParameterAndEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Public Sub GetById (name as String) \n";
            sourceCode += "End Sub \n";

            pccParser.Parser(sourceCode);

            Assert.AreEqual(pccParser.TokenCount, 10);
            Assert.IsFalse(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicSubWithOneUnderlineStringParameterAndEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Public Sub GetById (name_customer as String) \n";
            sourceCode += "End Sub \n";

            pccParser.Parser(sourceCode);

            Assert.AreEqual(pccParser.TokenCount, 10);
            Assert.IsFalse(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicFunctionNoParametersAndEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Public Function GetById () \n";
            sourceCode += "End Function \n";

            pccParser.Parser(sourceCode);

            Assert.AreEqual(pccParser.TokenCount, 7);
            Assert.IsFalse(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPrivateSubNoParametersAndEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Private Sub GetById () \n";
            sourceCode += "End Sub \n";

            pccParser.Parser(sourceCode);

            Assert.AreEqual(pccParser.TokenCount, 7);
            Assert.IsFalse(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPrivateFunctionNoParametersAndEmpty()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Private Function GetById () \n";
            sourceCode += "End Function \n";

            pccParser.Parser(sourceCode);

            Assert.AreEqual(pccParser.TokenCount, 7);
            Assert.IsFalse(pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPrivateSubFinishedByEndFunction()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Private Sub GetById () \n";
            sourceCode += "End Function \n";

            pccParser.Parser(sourceCode);

            Assert.IsTrue(pccParser.NotificationsHandler.HasNotifications());
            Assert.AreEqual(pccParser.NotificationsHandler.GetNotifications()[0].Description, "SYNTAX ERROR");
            Assert.AreEqual(pccParser.NotificationsHandler.GetNotifications()[0].Line, 2);
        }

        [TestMethod]
        public void SourceCodeHaveAPrivateFunctionFinishedByEndFunction()
        {
            IPccParser pccParser = new PccParser(_pccRegExHandler, _notificationsHandler, _cancellationTokenSource);
            string sourceCode = "Private Function GetById () \n";
            sourceCode += "End Sub \n";

            pccParser.Parser(sourceCode);

            Assert.IsTrue(pccParser.NotificationsHandler.HasNotifications());
            Assert.AreEqual(pccParser.NotificationsHandler.GetNotifications()[0].Description, "SYNTAX ERROR");
            Assert.AreEqual(pccParser.NotificationsHandler.GetNotifications()[0].Line, 2);
        }
    }
}
