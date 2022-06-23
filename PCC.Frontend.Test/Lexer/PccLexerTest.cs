using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCC.Core.Handlers;
using PCC.Frontend.Lexer;
using System;
using System.Threading;


namespace PCC.Frontend.Test.Lexer
{
    [TestClass]
    public class PccLexerTest
    {
        private PccRegExHandler _pccRegExHandler;
        private PccLexerNotificationHandler _notificationsHandler;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private IPccLexer _pccLexer;


        [TestInitialize]
        public void Initialize()
        {
            _pccRegExHandler = new PccRegExHandler();
            _notificationsHandler = new PccLexerNotificationHandler();
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }


        [TestMethod]
        public void TokenIsAEmpty()
        {
            string sourceCode = string.Empty;
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.END_OF_CODE);
        }


        #region Logical Operators

        [TestMethod]
        public void TokenIsAEqualsOperator()
        {
            string sourceCode = "=";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAEqualsOperatorMoreOneSpaceBeforeIt()
        {
            string sourceCode = " =";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAEqualsOperatorMoreOneSpaceAfterIt()
        {
            string sourceCode = "= ";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterOperator()
        {
            string sourceCode = ">";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, ">");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterOperatorFollowedByOneNumber()
        {
            string sourceCode = ">1";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, ">");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterOperatorFollowedByOneSpaceAndOneNumber()
        {
            string sourceCode = "> 1";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, ">");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterThanOrEqualOperator()
        {
            string sourceCode = ">=";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OR_EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, ">=");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterThanOperatorFollowedByEqualOperator()
        {
            string sourceCode = "> =";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, ">");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterThanOperatorFollowedByEqualOperatorAndSpaces()
        {
            string sourceCode = "  >  =  ";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, ">");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterThanOrEqualOperatorFollowedByOneNumber()
        {
            string sourceCode = ">=147";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OR_EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, ">=");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "147");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAGreaterThanOrEqualOperatorFollowedByOneSpaceAndOneNumber()
        {
            string sourceCode = ">= 123";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.GREATER_THAN_OR_EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, ">=");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "123");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALessOperator()
        {
            string sourceCode = "<";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LESS_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, "<");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALessrOperatorFollowedByOneNumber()
        {
            string sourceCode = "<1";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LESS_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, "<");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALessOperatorFollowedByOneSpaceAndOneNumber()
        {
            string sourceCode = "< 1";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LESS_THAN_OP);
            Assert.AreEqual(token.Lexeme.Value, "<");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALessThanOrEqualOperator()
        {
            string sourceCode = "<=";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LESS_THAN_OR_EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "<=");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALessThanOrEqualOperatorFollowedByOneNumber()
        {
            string sourceCode = "<=147";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LESS_THAN_OR_EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "<=");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "147");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALessThanOrEqualOperatorFollowedByOneSpaceAndOneNumber()
        {
            string sourceCode = "<= 123";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LESS_THAN_OR_EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "<=");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "123");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        #endregion


        #region Arithmetic Operators

        [TestMethod]
        public void TokenIsAnAdditionOperator()
        {
            string sourceCode = "+";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ADD_OP);
            Assert.AreEqual(token.Lexeme.Value, "+");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsASubtractionOperator()
        {
            string sourceCode = "-";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAMultiplicationOperator()
        {
            string sourceCode = "*";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsADivisionOperator()
        {
            string sourceCode = "/";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnExponentiationOperator()
        {
            string sourceCode = "^";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EXP_OP);
            Assert.AreEqual(token.Lexeme.Value, "^");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnOpenBracketOperator()
        {
            string sourceCode = "(";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsACloseBracketOperator()
        {
            string sourceCode = ")";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        #endregion


        #region Numbers

        [TestMethod]
        public void TokenIsAOneDigit()
        {
            string sourceCode = "7";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "7");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsATwoDigit()
        {
            string sourceCode = "73";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "73");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnIntegerPositiveNumberWithFiveDigits()
        {
            string sourceCode = "32767";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "32767");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAMinIntegerNegativeNumberWithFiveDigits()
        {
            string sourceCode = "-32768";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "32768");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALongPositiveNumberWithFiveDigits()
        {
            string sourceCode = "32768";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "32768");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALongNegativeNumberWithFiveDigits()
        {
            string sourceCode = "-32769";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "32769");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsALongNegativeNumberWithOneHundredDigits()
        {
            string sourceCode = "-0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnOneDigitDecimalNumber()
        {
            string sourceCode = "0.7";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "0.7");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsATenDigitsDecimalNumber()
        {
            string sourceCode = "0.0123456789";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "0.0123456789");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnOneDigitDecimalNumberAndItIsNegativeNumber()
        {
            string sourceCode = "-0.7";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "0.7");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsATenDigitsDecimalNumberAndItIsNegativeNumber()
        {
            string sourceCode = "-0.0123456789";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "0.0123456789");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnOneDigitDecimalNumberAndItIsPositiveNumberNoIntegerDigits()
        {
            string sourceCode = ".7";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, ".7");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsATenDigitsDecimalNumberAndItIsPositiveNumberNoIntegerDigits()
        {
            string sourceCode = ".0123456789";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, ".0123456789");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnOneDigitDecimalNumberAndItIsNegativeNumberNoIntegerDigits()
        {
            string sourceCode = "-.7";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, ".7");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsATenDigitsDecimalNumberAndItIsNegativeNumberNoIntegerDigits()
        {
            string sourceCode = "-.0123456789";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, ".0123456789");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsATenDigitsDecimalNumberAndTwoPoints()
        {
            string sourceCode = "11..0123456789";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.UNDEFINED);
            Assert.AreEqual(token.Lexeme.Value, "11..0123456789");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }


        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithoutSignificantDigits()
        {
            string sourceCode = "0.7E";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.UNDEFINED);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumber()
        {
            string sourceCode = "0.7E10";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.7E10");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumberAndNegativeSignificantDigits()
        {
            string sourceCode = "0.7E-10";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.7E-10");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumber()
        {
            string sourceCode = "0.0123456789E10";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.0123456789E10");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumberAndNegativeSignificantDigits()
        {
            string sourceCode = "0.0123456789E-10";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.0123456789E-10");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumberAndItIsNegativeNumber()
        {
            string sourceCode = "-0.7E5";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.7E5");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumberAndItIsNegativeNumberAndNegativeSignificantDigits()
        {
            string sourceCode = "-0.7E-5";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.7E-5");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumberAndItIsNegativeNumber()
        {
            string sourceCode = "-0.0123456789E20";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.0123456789E20");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumberAndItIsNegativeNumberAndNegativeSignificantDigits()
        {
            string sourceCode = "-0.0123456789E-20";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "0.0123456789E-20");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumberAndItIsPositiveNumberNoIntegerDigits()
        {
            string sourceCode = ".7E100";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".7E100");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumberAndItIsPositiveNumberNoIntegerDigitsAndNegativeSignificantDigits()
        {
            string sourceCode = ".7E-100";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".7E-100");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumberAndItIsPositiveNumberNoIntegerDigits()
        {
            string sourceCode = ".0123456789E5";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".0123456789E5");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumberAndItIsPositiveNumberNoIntegerDigitsAndNegativeSignificantDigits()
        {
            string sourceCode = ".0123456789E-5";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".0123456789E-5");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumberAndItIsNegativeNumberNoIntegerDigits()
        {
            string sourceCode = "-.7E25";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".7E25");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithOneDigitDecimalNumberAndItIsNegativeNumberNoIntegerDigitsAndNegativeSignificantDigits()
        {
            string sourceCode = "-.7E-25";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".7E-25");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumberAndItIsNegativeNumberNoIntegerDigits()
        {
            string sourceCode = "-.0123456789e50";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".0123456789e50");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAAScientificNotationNumberWithTenDigitsDecimalNumberAndItIsNegativeNumberNoIntegerDigitsAndNegativeSignificantDigits()
        {
            string sourceCode = "-.0123456789e-50";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, ".0123456789e-50");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        #endregion


        #region Arrays and Lists

        [TestMethod]
        public void TokenIsAListWithTwoIntegerNumbers()
        {
            string sourceCode = "0,7";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "0");
            Assert.AreEqual(token.Lexeme.Line, 1);
            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Line, 1);
            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "7");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        #endregion


        #region Keywords AND Identifiers

        [TestMethod]
        public void TokenIsAKeyWordPrivate()
        {
            string sourceCode = "Private";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.PRIVATE);
            Assert.AreEqual(token.Lexeme.Value, "Private");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAKeyWordPRIVATE()
        {
            string sourceCode = "PRIVATE";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.PRIVATE);
            Assert.AreEqual(token.Lexeme.Value, "PRIVATE");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAKeyWordprivate()
        {
            string sourceCode = "private";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.PRIVATE);
            Assert.AreEqual(token.Lexeme.Value, "private");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAKeyWordpriVate()
        {
            string sourceCode = "priVate";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.PRIVATE);
            Assert.AreEqual(token.Lexeme.Value, "priVate");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void WhenThereArePrivateFunctionNameKeywords()
        {
            string sourceCode = "Private function Calc_Taxes";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.PRIVATE);
            Assert.AreEqual(token.Lexeme.Value, "Private");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FUNCTION);
            Assert.AreEqual(token.Lexeme.Value, "function");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Calc_Taxes");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void WhenThereArePrivateFunctionNameKeywordsWithSpaces()
        {
            string sourceCode = "  Private   function   Calc_Taxes  ";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.PRIVATE);
            Assert.AreEqual(token.Lexeme.Value, "Private");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FUNCTION);
            Assert.AreEqual(token.Lexeme.Value, "function");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Calc_Taxes");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnIFKeyword()
        {
            string sourceCode = "IF";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.IF);
            Assert.AreEqual(token.Lexeme.Value, "IF");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void IFWithBooleanConditionalAndThenWithIdentifierAndNumber()
        {
            string sourceCode = "IF isValid = True Then Tax=.55";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.IF);
            Assert.AreEqual(token.Lexeme.Value, "IF");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "isValid");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.TRUE);
            Assert.AreEqual(token.Lexeme.Value, "True");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.THEN);
            Assert.AreEqual(token.Lexeme.Value, "Then");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Tax");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, ".55");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsNotAnIfKeyword()
        {
            string sourceCode = "IIF";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "IIF");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void TokenIsAnUnderlineIdentifier()
        {
            string sourceCode = "BASE_TAX";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "BASE_TAX");
            Assert.AreEqual(token.Lexeme.Line, 1);
        }

        [TestMethod]
        public void WhenTheIdentifierSizeExceeds255Characters()
        {
            string sourceCode = "Number_01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);
            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.UNDEFINED);
            Assert.AreEqual(token.Lexeme.Line, 1);

            Assert.IsTrue(_notificationsHandler.HasNotifications());
            Assert.IsTrue(_notificationsHandler.GetNotifications()[0].Description.Contains("' exceeds 255 characters."));
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithIdentifiersModOperatorAndNumbers()
        {
            string sourceCode = "X=((A1+B1) Mod 5.12345E-10)";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "X");

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A1");

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ADD_OP);
            Assert.AreEqual(token.Lexeme.Value, "+");

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B1");

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MOD_OP);
            Assert.AreEqual(token.Lexeme.Value, "Mod");

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "5.12345E-10");

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithIdentifiersArithmeticOperatorsAndNumbers()
        {
            string sourceCode = "Z=((A1+B1)-(A2-B2-1)*((A3/B3)*5.12345E-10)/(A4/B4)^.123456)";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Z");

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A1");

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ADD_OP);
            Assert.AreEqual(token.Lexeme.Value, "+");

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B1");

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A2");

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B2");

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A3");

            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");

            token = _pccLexer.GetNextToken(22).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B3");

            token = _pccLexer.GetNextToken(23).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(24).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");

            token = _pccLexer.GetNextToken(25).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "5.12345E-10");

            token = _pccLexer.GetNextToken(26).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(27).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");

            token = _pccLexer.GetNextToken(28).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(29).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A4");

            token = _pccLexer.GetNextToken(30).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");

            token = _pccLexer.GetNextToken(31).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B4");

            token = _pccLexer.GetNextToken(32).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(33).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EXP_OP);
            Assert.AreEqual(token.Lexeme.Value, "^");

            token = _pccLexer.GetNextToken(34).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, ".123456");

            token = _pccLexer.GetNextToken(35).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithIdentifiersArithmeticOperatorsAndNumbersWithSpaces()
        {
            string sourceCode = " Z  =  (( A1 + B1 ) - ( A2 - B2 - 1)  * ( ( A3 / B3 ) *5.12345E-10 ) / ( A4 / B4 ) ^ .123456 )  ";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Z");

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A1");

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ADD_OP);
            Assert.AreEqual(token.Lexeme.Value, "+");

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B1");

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A2");

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B2");

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A3");

            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");

            token = _pccLexer.GetNextToken(22).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B3");

            token = _pccLexer.GetNextToken(23).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(24).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");

            token = _pccLexer.GetNextToken(25).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_SCIENT_NOT);
            Assert.AreEqual(token.Lexeme.Value, "5.12345E-10");

            token = _pccLexer.GetNextToken(26).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(27).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");

            token = _pccLexer.GetNextToken(28).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(29).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "A4");

            token = _pccLexer.GetNextToken(30).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");

            token = _pccLexer.GetNextToken(31).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "B4");

            token = _pccLexer.GetNextToken(32).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");

            token = _pccLexer.GetNextToken(33).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EXP_OP);
            Assert.AreEqual(token.Lexeme.Value, "^");

            token = _pccLexer.GetNextToken(34).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, ".123456");

            token = _pccLexer.GetNextToken(35).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
        }

        #endregion


        #region Date and Time Formats

        [TestMethod]
        public void IsAFormatDate_YYYYmmDD()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = #1993/01/27# \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_YYYYmmDD);
            Assert.AreEqual(token.Lexeme.Value, "1993/01/27");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatDate_MMddYYYY()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = \"01/27/1993\" \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_MMddYYYY);
            Assert.AreEqual(token.Lexeme.Value, "01/27/1993");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatDate_DDmmYYYY()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = \"31-01-2022\" \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_DDmmYYYY);
            Assert.AreEqual(token.Lexeme.Value, "31-01-2022");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatDate_MMMddYYYY()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = #Jan-31-2022# \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_MMMddYYYY);
            Assert.AreEqual(token.Lexeme.Value, "Jan-31-2022");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatDate_MMMMddYYYY()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = #January 27, 1993# \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_MMMMddYYYY);
            Assert.AreEqual(token.Lexeme.Value, "January 27, 1993");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatDate_YYYYmmDD_HHMMSS()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = #2022-01-31 14:55:26# \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_TIME_YYYYmmDD_HHMMSS);
            Assert.AreEqual(token.Lexeme.Value, "2022-01-31 14:55:26");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatDate_MMMddYYYY_HHMMSS()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = \"01-31-2022 14:55:26\" \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_TIME_mmDDYYYY_HHMMSS);
            Assert.AreEqual(token.Lexeme.Value, "01-31-2022 14:55:26");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatDate_DDmmYYYY_HHMMSS()
        {
            string sourceCode = "Dim MyDate As Date \n";
            sourceCode += "MyDate = \"31-01-2022 14:55:26\" \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_TIME_DDmmYYYY_HHMMSS);
            Assert.AreEqual(token.Lexeme.Value, "31-01-2022 14:55:26");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        //// Time Formats
        [TestMethod]
        public void IsAFormatTime_HHMMSS()
        {
            string sourceCode = "Dim MyTime As Date \n";
            sourceCode += "MyTime = #17:04:23# \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.TIME_HHMMSS);
            Assert.AreEqual(token.Lexeme.Value, "17:04:23");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatTime_HHMMSS_MMM()
        {
            string sourceCode = "Dim MyTime As Date \n";
            sourceCode += "MyTime = #17:04:23 456# \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.TIME_HHMMSS_MMM);
            Assert.AreEqual(token.Lexeme.Value, "17:04:23 456");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        [TestMethod]
        public void IsAFormatTime_HHMMSS_AMPM()
        {
            string sourceCode = "Dim MyTime As Date \n";
            sourceCode += "MyTime = \"12:04:23 PM\" \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE);
            Assert.AreEqual(token.Lexeme.Value, "Date");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.TIME_HHMMSS_AMPM);
            Assert.AreEqual(token.Lexeme.Value, "12:04:23 PM");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        #endregion


        #region Math Functions
        // https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/math-functions

        [TestMethod]
        public void WhenThereIsAnExpressionWithABSOperator()
        {
            string sourceCode = "MyNumber = Abs(-50.3)";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ABS_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Abs");

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "50.3");

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithATNOperator()
        {
            string sourceCode = "AngleInRadians = Atn(-50.3)";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "AngleInRadians");

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ATN_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Atn");

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "50.3");

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithCOSOperator()
        {
            string sourceCode = "MySecant = 1 / Cos(MyAngle)";
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MySecant");

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COS_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Cos");

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithEXPOperator()
        {
            string sourceCode = "Dim MyAngle, MyHSin \n";
            sourceCode += "MyAngle = 1.3 \n";
            sourceCode += "MyHSin = (Exp(MyAngle) - Exp(-1 * MyAngle)) / 2";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyHSin");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "1.3");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyHSin");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EXP_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Exp");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EXP_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Exp");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(22).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(23).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(24).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "2");
            Assert.AreEqual(token.Lexeme.Line, 3);
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithLOGAndSQROperator()
        {
            string sourceCode = "Dim MyAngle, MyLog \n";
            sourceCode += "MyAngle = 1.3 \n";
            sourceCode += "MyLog = Log(MyAngle + Sqr(MyAngle * MyAngle + 1)) \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyLog");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "1.3");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyLog");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LOG_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Log");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ADD_OP);
            Assert.AreEqual(token.Lexeme.Value, "+");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SQR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Sqr");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ADD_OP);
            Assert.AreEqual(token.Lexeme.Value, "+");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithINTAndFIXOperator()
        {
            string sourceCode = "Dim MyNumber \n";
            sourceCode += "MyNumber = Int(99.8) \n";    // ' Returns 99.
            sourceCode += "MyNumber = Fix(99.2) \n";    // ' Returns 99.
            sourceCode += "MyNumber = Int(-99.8) \n";   // ' Returns -100.
            sourceCode += "MyNumber = Fix(-99.8) \n";   // ' Returns -99.

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.INT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Int");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "99.8");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FIX_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Fix");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "99.2");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);


            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.INT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Int");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "99.8");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 4);


            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FIX_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Fix");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "99.8");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 5);
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithRNDOperator()
        {
            string sourceCode = "Dim MyValue As Integer \n";
            sourceCode += "MyValue = Int((6 * Rnd) + 1) \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyValue");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.AS);
            Assert.AreEqual(token.Lexeme.Value, "As");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.INTEGER);
            Assert.AreEqual(token.Lexeme.Value, "Integer");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyValue");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.INT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Int");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "6");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.RND_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Rnd");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ADD_OP);
            Assert.AreEqual(token.Lexeme.Value, "+");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithSGNOperator()
        {
            string sourceCode = "Dim MyVar1, MyVar2, MyVar3, MySign \n";
            sourceCode += "MyVar1 = 12: MyVar2 = -2.4: MyVar3 = 0 \n";
            sourceCode += "MySign = Sgn(MyVar1) \n";                        // ' Returns 1.
            sourceCode += "MySign = Sgn(MyVar2) \n";                        // ' Returns -1.
            sourceCode += "MySign = Sgn(MyVar3) \n";                        // ' Returns 0.

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar1");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar2");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar3");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MySign");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar1");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "12");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COLON);
            Assert.AreEqual(token.Lexeme.Value, ":");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar2");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "2.4");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COLON);
            Assert.AreEqual(token.Lexeme.Value, ":");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar3");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "0");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MySign");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(22).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SGN_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Sgn");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(23).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(24).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar1");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(25).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);


            token = _pccLexer.GetNextToken(26).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MySign");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(27).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(28).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SGN_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Sgn");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(29).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(30).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar2");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(31).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 4);


            token = _pccLexer.GetNextToken(32).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MySign");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(33).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(34).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SGN_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Sgn");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(35).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(36).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar3");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(37).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 5);
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithSINOperator()
        {
            string sourceCode = "Dim MyAngle, MyCosecant \n";
            sourceCode += "MyAngle = 1.3 \n";                   // ' Define angle in radians.
            sourceCode += "MyCosecant = 1 / Sin(MyAngle) \n";   // ' Calculate cosecant.

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCosecant");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "1.3");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCosecant");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SIN_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Sin");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithTANOperator()
        {
            string sourceCode = "Dim MyAngle, MyCotangent \n";
            sourceCode += "MyAngle = 1.3 \n";                   // ' Define angle in radians.
            sourceCode += "MyCotangent = 1 / Tan(MyAngle) \n";   // ' Calculate Cotangent.

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCotangent");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "1.3");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCotangent");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "1");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIV_OP);
            Assert.AreEqual(token.Lexeme.Value, "/");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.TAN_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Tan");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyAngle");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);
        }

        #endregion


        #region Conversion Functions

        [TestMethod]
        public void WhenThereIsAnExpressionWithASCOperator()
        {
            string sourceCode = "Dim MyNumber \n";
            sourceCode += "MyNumber = Asc(\"A\") \n";                       // ' Returns 65.
            sourceCode += "MyNumber = Asc(\"a\") \n";                       // ' Returns 97.
            sourceCode += "MyNumber = Asc(\"Apple\") \n";                   // ' Returns 65.

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ASC_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Asc");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "A");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ASC_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Asc");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "a");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);


            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyNumber");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ASC_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Asc");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "Apple");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 4);
        }

        [TestMethod]
        public void WhenThereIsAnExpressionWithCHROperator()
        {
            string sourceCode = "Dim MyChar \n";
            sourceCode += "MyChar = Chr(65) \n";                       // ' Returns A.
            sourceCode += "MyChar = Chr(97) \n";                       // ' Returns a.
            sourceCode += "MyChar = Chr(62) \n";                       // ' Returns >.
            sourceCode += "MyChar = Chr(37) \n";                       // ' Returns %.

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyChar");
            Assert.AreEqual(token.Lexeme.Line, 1);


            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyChar");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CHR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Chr");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "65");
            Assert.AreEqual(token.Lexeme.Line, 2);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);


            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyChar");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CHR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Chr");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "97");
            Assert.AreEqual(token.Lexeme.Line, 3);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);


            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyChar");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CHR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Chr");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "62");
            Assert.AreEqual(token.Lexeme.Line, 4);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 4);


            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyChar");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CHR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Chr");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "37");
            Assert.AreEqual(token.Lexeme.Line, 5);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 5);
        }

        /// <summary>
        /// REFERENCE:
        ///     https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/cverr-function
        /// </summary>
        [TestMethod]
        public void WhenThereIsAnExpressionWithCVERROperator()
        {
            string sourceCode = "' Call CalculateDouble with an error-producing argument. \n";
            sourceCode += "Sub Test() \n";
            sourceCode += "     Debug.Print CalculateDouble(\"345.45robert\") \n";
            sourceCode += "End Sub \n";
            sourceCode += "' Define CalculateDouble Function procedure. \n";
            sourceCode += "Function CalculateDouble(Number) \n";
            sourceCode += "     If IsNumeric(Number) Then \n";
            sourceCode += "         CalculateDouble = Number * 2 ' Return result. \n";
            sourceCode += "     Else \n";
            sourceCode += "         CalculateDouble = CVErr(2001) ' Return a user-defined error  \n";
            sourceCode += "     End If    ' number. \n";
            sourceCode += "End Function \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Call CalculateDouble with an error-producing argument. ");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);


            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB);
            Assert.AreEqual(token.Lexeme.Value, "Sub");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Test");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DEBUG);
            Assert.AreEqual(token.Lexeme.Value, "Debug");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.POINT);
            Assert.AreEqual(token.Lexeme.Value, ".");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.PRINT);
            Assert.AreEqual(token.Lexeme.Value, "Print");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "CalculateDouble");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "345.45robert");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.END);
            Assert.AreEqual(token.Lexeme.Value, "End");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB);
            Assert.AreEqual(token.Lexeme.Value, "Sub");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Define CalculateDouble Function procedure. ");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);


            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FUNCTION);
            Assert.AreEqual(token.Lexeme.Value, "Function");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "CalculateDouble");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Number");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.IF);
            Assert.AreEqual(token.Lexeme.Value, "If");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ISNUMERIC);
            Assert.AreEqual(token.Lexeme.Value, "IsNumeric");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(22).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(24).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Number");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(25).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(26).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.THEN);
            Assert.AreEqual(token.Lexeme.Value, "Then");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(27).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "CalculateDouble");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(28).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(29).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Number");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(30).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.MULT_OP);
            Assert.AreEqual(token.Lexeme.Value, "*");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(31).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "2");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(32).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Return result. ");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);


            token = _pccLexer.GetNextToken(33).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ELSE);
            Assert.AreEqual(token.Lexeme.Value, "Else");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(34).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "CalculateDouble");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(35).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(36).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CVERR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "CVErr");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(37).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(38).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "2001");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(39).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(40).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Return a user-defined error  ");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);


            token = _pccLexer.GetNextToken(41).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.END);
            Assert.AreEqual(token.Lexeme.Value, "End");
            Assert.AreEqual(token.Lexeme.Line, 11);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(42).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.IF);
            Assert.AreEqual(token.Lexeme.Value, "If");
            Assert.AreEqual(token.Lexeme.Line, 11);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(43).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " number. ");
            Assert.AreEqual(token.Lexeme.Line, 11);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);


            token = _pccLexer.GetNextToken(44).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.END);
            Assert.AreEqual(token.Lexeme.Value, "End");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(45).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FUNCTION);
            Assert.AreEqual(token.Lexeme.Value, "Function");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);
        }

        /// <summary>
        /// REFERENCE:
        ///     https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/format-function-visual-basic-for-applications
        /// </summary>
        [TestMethod]
        public void WhenThereIsAnExpressionWithFORMATOperator()
        {
            string sourceCode = "Dim MyTime, MyDate, MyStr \n";
            sourceCode += "MyTime = #17:04:23# \n";
            sourceCode += "MyDate = #January 27, 1993# \n";

            sourceCode += "' Returns current system time in the system-defined long time format. \n";
            sourceCode += "MyStr = Format(Time, \"Long Time\") \n";

            sourceCode += "' Returns current system date in the system-defined long date format. \n";

            sourceCode += "MyStr = Format(MyTime, \"h:m:s\")                ' Returns \"17:4:23\". \n";
            sourceCode += "MyStr = Format(MyTime, \"hh:mm:ss am/pm\")       ' Returns \"05:04:23 pm\". \n";
            sourceCode += "MyStr = Format(MyDate, \"dddd, mmm d yyyy\")     ' Returns \"Wednesday, Jan 27 1993\". \n";
            sourceCode += "' If format is not supplied, a string is returned. \n";

            sourceCode += "' User-defined formats. \n";
            sourceCode += "MyStr = Format(5459.4, \"##,##0.00\")            ' Returns \"5,459.40\". \n";
            sourceCode += "MyStr = Format(5, \"0.00 %\")                    ' Returns \"500.00%\". \n";
            sourceCode += "MyStr = Format(\"HELLO\", \"<\")                 ' Returns \"hello\". \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.TIME_HHMMSS);
            Assert.AreEqual(token.Lexeme.Value, "17:04:23");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DATE_MMMMddYYYY);
            Assert.AreEqual(token.Lexeme.Value, "January 27, 1993");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns current system time in the system-defined long time format. ");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);


            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FORMAT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Format");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "Time");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "Long Time");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns current system date in the system-defined long date format. ");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"MyStr = Format(MyTime, \"h:m:s\")                ' Returns \"17:4:23\". \n";
            token = _pccLexer.GetNextToken(22).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(23).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(24).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FORMAT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Format");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(25).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(26).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(27).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(28).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "h:m:s");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(29).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(30).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \"17:4:23\". ");
            Assert.AreEqual(token.Lexeme.Line, 7);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"MyStr = Format(MyTime, \"hh:mm:ss am/pm\")       ' Returns \"05:04:23 pm\". \n";
            token = _pccLexer.GetNextToken(31).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(32).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(33).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FORMAT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Format");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(34).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(35).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyTime");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(36).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(37).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "hh:mm:ss am/pm");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(29).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(38).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \"05:04:23 pm\". ");
            Assert.AreEqual(token.Lexeme.Line, 8);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"MyStr = Format(MyDate, \"dddd, mmm d yyyy\")     ' Returns \"Wednesday, Jan 27 1993\". \n";
            token = _pccLexer.GetNextToken(39).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(40).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(41).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FORMAT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Format");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(42).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(43).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyDate");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(44).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(45).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "dddd, mmm d yyyy");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(46).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(47).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \"Wednesday, Jan 27 1993\". ");
            Assert.AreEqual(token.Lexeme.Line, 9);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"' If format is not supplied, a string is returned. \n";
            token = _pccLexer.GetNextToken(48).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " If format is not supplied, a string is returned. ");
            Assert.AreEqual(token.Lexeme.Line, 10);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"' User-defined formats. \n";
            token = _pccLexer.GetNextToken(49).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " User-defined formats. ");
            Assert.AreEqual(token.Lexeme.Line, 11);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"MyStr = Format(5459.4, \"##,##0.00\")            ' Returns \"5,459.40\". \n";
            token = _pccLexer.GetNextToken(50).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(51).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(52).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FORMAT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Format");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(53).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(54).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "5459.4");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(55).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(56).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "##,##0.00");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(57).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(58).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \"5,459.40\". ");
            Assert.AreEqual(token.Lexeme.Line, 12);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"MyStr = Format(5, \"0.00 %\")                    ' Returns \"500.00%\". \n";
            token = _pccLexer.GetNextToken(59).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(60).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(61).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FORMAT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Format");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(62).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(63).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "5");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(64).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(65).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "0.00 %");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(66).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(67).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \"500.00%\". ");
            Assert.AreEqual(token.Lexeme.Line, 13);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //"MyStr = Format(\"HELLO\", \"<\")                 ' Returns \"hello\". \n";
            token = _pccLexer.GetNextToken(68).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyStr");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(69).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(70).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.FORMAT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Format");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(71).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(72).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "HELLO");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(73).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(74).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "<");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(75).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(78).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \"hello\". ");
            Assert.AreEqual(token.Lexeme.Line, 14);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);
        }

        /// <summary>
        /// REFERENCE:
        ///      https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/hex-function
        /// </summary>
        [TestMethod]
        public void WhenThereIsAnExpressionWithHEXOperator()
        {
            string sourceCode = "Dim MyHex \n";
            sourceCode += "MyHex = Hex(5)    ' Returns 5. \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyHex");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            // "MyHex = Hex(5)    ' Returns 5. \n";
            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyHex");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.HEX_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Hex");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "5");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns 5. ");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);
        }

        /// <summary>
        /// REFERENCE:
        ///      https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/oct-function
        /// </summary>
        [TestMethod]
        public void WhenThereIsAnExpressionWithOCTOperator()
        {
            string sourceCode = "Dim MyOct \n";
            sourceCode += "MyOct = Oct(4)     ' Returns 4. \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyOct");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);


            // "MyOct = Oct(4)     ' Returns 4. \n";
            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyOct");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OCT_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Oct");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "4");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns 4. ");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);
        }

        /// <summary>
        /// REFERENCE:
        ///      https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/str-function
        /// </summary>
        [TestMethod]
        public void WhenThereIsAnExpressionWithSTROperator()
        {
            string sourceCode = "Dim MyString \n";
            sourceCode += "MyString = Str(459)    ' Returns \" 459\". \n";
            sourceCode += "MyString = Str(-459.65)    ' Returns \" - 459.65\". \n";
            sourceCode += "MyString = Str(459.001)    ' Returns \" 459.001\". \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyString");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            // "MyString = Str(459)    ' Returns \" 459\". \n";
            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyString");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.STR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Str");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_INT);
            Assert.AreEqual(token.Lexeme.Value, "459");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \" 459\". ");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //sourceCode += "MyString = Str(-459.65)    ' Returns \" - 459.65\". \n";
            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyString");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.STR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Str");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.SUB_OP);
            Assert.AreEqual(token.Lexeme.Value, "-");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "459.65");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \" - 459.65\". ");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //sourceCode += "MyString = Str(459.001)    ' Returns \" 459.001\". \n";
            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyString");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.STR_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Str");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NUM_FLOAT);
            Assert.AreEqual(token.Lexeme.Value, "459.001");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns \" 459.001\". ");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);
        }

        /// <summary>
        /// REFERENCE:
        ///      https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/val-function
        /// </summary>
        [TestMethod]
        public void WhenThereIsAnExpressionWithVALOperator()
        {
            string sourceCode = "Dim MyValue \n";
            sourceCode += "MyValue = Val(\"2457\")    ' Returns 2457. \n";
            sourceCode += "MyValue = Val(\" 2 45 7\")    ' Returns 2457. \n";
            sourceCode += "MyValue = Val(\"24 and 57\")    ' Returns 24. \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyValue");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            // "MyValue = Val(\"2457\")    ' Returns 2457. \n";
            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyValue");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.VAL_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Val");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "2457");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns 2457. ");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //sourceCode += "MyValue = Val(\" 2 45 7\")    ' Returns 2457. \n";
            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyValue");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.VAL_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Val");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, " 2 45 7");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns 2457. ");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //sourceCode += "MyValue = Val(\"24 and 57\")    ' Returns 24. \n";
            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyValue");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.VAL_FUNC);
            Assert.AreEqual(token.Lexeme.Value, "Val");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "24 and 57");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns 24. ");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);
        }

        #endregion


        #region Validation Functions

        // = 180,
        /// <summary>
        /// REFERENCE:
        ///      https://docs.microsoft.com/en-us/office/vba/language/reference/user-interface-help/isnull-function
        /// </summary>
        [TestMethod]
        public void WhenThereIsAISNULLFunction()
        {
            string sourceCode = "Dim MyVar, MyCheck \n";
            sourceCode += "MyCheck = IsNull(MyVar)    ' Returns False. \n";

            sourceCode += "MyVar = \"\" \n";
            sourceCode += "MyCheck = IsNull(MyVar)    ' Returns False. \n";

            sourceCode += "MyVar = Null \n";
            sourceCode += "MyCheck = IsNull(MyVar)    ' Returns True. \n";

            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, _notificationsHandler, _cancellationToken);

            var token = _pccLexer.GetNextToken(0).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.DIM);
            Assert.AreEqual(token.Lexeme.Value, "Dim");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(1).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(2).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMA);
            Assert.AreEqual(token.Lexeme.Value, ",");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(3).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCheck");
            Assert.AreEqual(token.Lexeme.Line, 1);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            // "MyCheck = IsNull(MyVar)    ' Returns False. \n";
            token = _pccLexer.GetNextToken(4).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCheck");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(5).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(6).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ISNULL);
            Assert.AreEqual(token.Lexeme.Value, "IsNull");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(7).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(8).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(9).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(10).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns False. ");
            Assert.AreEqual(token.Lexeme.Line, 2);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //sourceCode += "MyVar = \"\" ";
            token = _pccLexer.GetNextToken(11).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(12).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(13).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.LITERAL);
            Assert.AreEqual(token.Lexeme.Value, "");
            Assert.AreEqual(token.Lexeme.Line, 3);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            //sourceCode += "MyCheck = IsNull(MyVar)    ' Returns False. \n";
            token = _pccLexer.GetNextToken(14).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCheck");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(15).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(16).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ISNULL);
            Assert.AreEqual(token.Lexeme.Value, "IsNull");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(17).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(18).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(19).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(20).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns False. ");
            Assert.AreEqual(token.Lexeme.Line, 4);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);

            //sourceCode += "MyVar = Null \n";
            token = _pccLexer.GetNextToken(21).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(22).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(23).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.NULL);
            Assert.AreEqual(token.Lexeme.Value, "Null");
            Assert.AreEqual(token.Lexeme.Line, 5);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            //sourceCode += "MyCheck = IsNull(MyVar)    ' Returns True. \n";
            token = _pccLexer.GetNextToken(24).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyCheck");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(25).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.EQUAL_OP);
            Assert.AreEqual(token.Lexeme.Value, "=");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(26).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ISNULL);
            Assert.AreEqual(token.Lexeme.Value, "IsNull");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(27).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.OPEN_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, "(");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(28).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.ID);
            Assert.AreEqual(token.Lexeme.Value, "MyVar");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(29).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.CLOSE_BRACKET);
            Assert.AreEqual(token.Lexeme.Value, ")");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, true);

            token = _pccLexer.GetNextToken(30).Result;
            Assert.IsNotNull(token);
            Assert.AreEqual(token.Name, ETokenName.COMMENTED_TEXT);
            Assert.AreEqual(token.Lexeme.Value, " Returns True. ");
            Assert.AreEqual(token.Lexeme.Line, 6);
            Assert.AreEqual(token.AddToTheTableOfTokens, false);
        }

        //ISEMPTY = 181,

        //ISDATE = 182,

        //ISARRAY = 183,

        //ISNUMERIC = 184,

        //ISMISSING = 185,

        #endregion
    }
}
