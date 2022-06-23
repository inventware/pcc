using PCC.Core.Handlers;
using PCC.Frontend.Lexer.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer
{
    public class PccLexer : IPccLexer
    {
        private IPccRegExHandler _pccRegExHandler;
        private IPccLexerNotificationHandler _notificationsHandler;
        private CancellationToken _cancellationToken;
        private string _sourceCode;
        private int _currentIndex;
        private int _currentLine;
        private int _tokenCount;


        public PccLexer(string sourceCode, IPccRegExHandler pccRegExHandler, IPccLexerNotificationHandler
            notificationsHandler, CancellationToken cancellationToken)
        {
            _pccRegExHandler = pccRegExHandler;
            _notificationsHandler = notificationsHandler;
            _cancellationToken = cancellationToken;
            _sourceCode = sourceCode;
            _currentIndex = 0;
            _currentLine = 1;
        }


        public Task<IPccToken> GetNextToken(int tokenCount)
        {
            string lexeme = string.Empty;
            _tokenCount = tokenCount;

            if (!IsTheEndOfSourceCode()){
                return GetTokenForLogicalOperatorLexeme(ref lexeme);
            }
            return Task.FromResult<IPccToken>(new PccToken(tokenCount, ETokenName.END_OF_CODE, string.Empty,
                _currentLine));
        }

        private bool IsTheEndOfSourceCode()
        {
            try
            {
                char auxChar = _sourceCode[_currentIndex];
                return false;
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
                return true;
            }
        }


        private Task<IPccToken> GetTokenForLogicalOperatorLexeme(ref string lexeme)
        {
            try
            {
                var logicalOperHandler = new PccLogicalOperatorHandler(lexeme, _currentLine, _currentIndex, _tokenCount,
                    _sourceCode, _pccRegExHandler);

                var logicalOperToken = logicalOperHandler.Handle(_cancellationToken).Result;
                if (logicalOperToken.Name == ETokenName.UNDEFINED)
                {
                    lexeme = logicalOperToken.Lexeme.Value;
                    return GetTokenForArithmeticOperatorLexeme(ref lexeme);
                }
                return ProcessFindedToken(logicalOperHandler, logicalOperToken);
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
        }


        private Task<IPccToken> GetTokenForArithmeticOperatorLexeme(ref string lexeme)
        {
            try
            {
                var arithmeticOperHandler = new PccArithmeticOperatorHandler(lexeme, _currentLine, _currentIndex,
                    _tokenCount, _sourceCode, _pccRegExHandler);

                var arithmeticOperToken = arithmeticOperHandler.Handle(_cancellationToken).Result;
                if (arithmeticOperToken.Name == ETokenName.UNDEFINED)
                {
                    lexeme = arithmeticOperToken.Lexeme.Value;
                    return GetTokenForNumericLexeme(ref lexeme);
                }
                return ProcessFindedToken(arithmeticOperHandler, arithmeticOperToken);
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
        }


        private Task<IPccToken> GetTokenForNumericLexeme(ref string lexeme)
        {
            try
            {
                var numericHandler = new PccNumericHandler(lexeme, _currentLine, _currentIndex, _tokenCount,
                    _sourceCode, _pccRegExHandler);

                var numericToken = numericHandler.Handle(_cancellationToken).Result;
                if (numericToken.Name == ETokenName.UNDEFINED)
                {
                    lexeme = numericToken.Lexeme.Value;
                    return GetTokenForTextLexeme(ref lexeme);
                }
                return ProcessFindedToken(numericHandler.CurrentIndex, numericHandler.CurrentLine, numericToken);
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
        }


        private Task<IPccToken> GetTokenForTextLexeme(ref string lexeme)
        {
            try
            {
                var textHandler = new PccTextHandler(lexeme, _currentLine, _currentIndex, _tokenCount,
                    _sourceCode, _pccRegExHandler);

                var textToken = textHandler.Handle(_cancellationToken).Result;
                if (textToken.Name == ETokenName.UNDEFINED)
                {
                    lexeme = textToken.Lexeme.Value;
                    return GetTokenForLiteralLexeme(ref lexeme);
                }
                return ProcessFindedToken(textHandler, textToken);
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
        }


        private Task<IPccToken> GetTokenForLiteralLexeme(ref string lexeme)
        {
            try
            {
                var literalHandler = new PccLiteralHandler(lexeme, _currentLine, _currentIndex, _tokenCount,
                    _sourceCode, _pccRegExHandler);

                var literalToken = literalHandler.Handle(_cancellationToken).Result;
                if (literalToken.Name == ETokenName.UNDEFINED)
                {
                    lexeme = literalToken.Lexeme.Value;
                    return GetTokenForCommentInText(ref lexeme);
                }
                return ProcessFindedToken(literalHandler.CurrentIndex, literalHandler.CurrentLine, literalToken);
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
        }


        private Task<IPccToken> GetTokenForCommentInText(ref string lexeme)
        {
            try
            {
                var commentedTextHandler = new PccCommentedTextHandler(lexeme, _currentLine, _currentIndex, _tokenCount,
                    _sourceCode, _pccRegExHandler);

                var commentedText = commentedTextHandler.Handle(_cancellationToken).Result;
                if (commentedText.Name == ETokenName.UNDEFINED)
                {
                    lexeme = commentedText.Lexeme.Value;
                    return GetTokenForSeparationAndGroupingSymbolsLexeme(ref lexeme);
                }
                return ProcessFindedToken(commentedTextHandler, commentedText);
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
        }


        private Task<IPccToken> GetTokenForSeparationAndGroupingSymbolsLexeme(ref string lexeme)
        {
            try
            {
                var separationAndGroupingSymbolsHandler = new PccSeparationAndGroupingSymbolsHandler(lexeme,
                    _currentLine, _currentIndex, _tokenCount, _sourceCode, _pccRegExHandler);

                var logicalOperToken = separationAndGroupingSymbolsHandler.Handle(_cancellationToken).Result;
                if (logicalOperToken.Name == ETokenName.UNDEFINED)
                {
                    return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
                }
                return ProcessFindedToken(separationAndGroupingSymbolsHandler, logicalOperToken);
            }
            catch (Exception err)
            {
                _notificationsHandler.Handle(new PccLexerNotification("LEX_" + _currentIndex.ToString(), err.Message,
                    _currentLine));
            }
            return Task.FromResult<IPccToken>(new PccToken(_tokenCount, ETokenName.UNDEFINED, lexeme, _currentLine));
        }


        private Task<IPccToken> ProcessFindedToken(IPccCharactersHandler processedHandler, IPccToken processedToken)
        {
            _currentIndex = processedHandler.CurrentIndex;
            _currentLine = processedHandler.CurrentLine;
            return Task.FromResult<IPccToken>(processedToken);
        }

        private Task<IPccToken> ProcessFindedToken(int currentIndex, int currentLine, IPccToken processedToken)
        {
            _currentIndex = currentIndex;
            _currentLine = currentLine;
            return Task.FromResult<IPccToken>(processedToken);
        }


        //private void VerifyIfTheTokenIsALineBreak()
        //{
        //    if (!_ActiveChar.isUnderLine().Equals(string.Empty))
        //    {
        //        // Variável auxiliar encarregada do carregamento dos caracteres Token, ou seja, da concatenação 
        //        // caracter à caracter do Código Fonte (sSourceCode). IMPORTANTE : Contém o Token em atividade apenas.
        //        string ValueToken = Convert.ToString(_peek);
        //        _currentIndex += 1;
        //        _peek = _sourceCode[_currentIndex];
        //    }
        //}

    }
}
