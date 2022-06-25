using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Core.Handlers;
using PCC.Frontend.Parser;
using System.Threading;


namespace PCC.Frontend.Test.Parser
{
    [TestClass]
    public class PccParserTest
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
        public void SourceCodeIsAEmpty()
        {
            _pccParser.Parser("", null, null, null, null);
            Assert.AreEqual(_pccParser.TokenCount, 0);
        }

        [TestMethod]
        public void SourceCodeHaveAPublicToken()
        {
            _pccParser.Parser("Public", null, null, null, null);
            
            // Error: Incomplete block code
            Assert.AreEqual(_pccParser.TokenCount, 1);
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
        }

        [TestMethod]
        public void SourceCodeHaveAPublicFollowedByIdentifier()
        {
            _pccParser.Parser("Public GetById", null, null, null, null);
            
            // Error: Incomplete block code
            Assert.IsTrue(_pccParser.NotificationsHandler.HasNotifications());
        }
    }
}
