using PCC.Core.Handlers;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace PCC.Frontend.Lexer.Handlers
{
    public abstract class PccCharactersHandler : IPccCharactersHandler
    {
        protected IPccCharactersHandler _nextHandler;
        protected IPccRegExHandler _pccRegExHandler;
        protected CancellationToken _cancellationToken;
        protected char _peek;
        protected int _currentLine;
        protected int _currentIndex;
        protected int _tokenCount;
        protected string _lexeme;
        protected string _sourceCode;
        protected const char END_OF_CODE = '\\';


        protected PccCharactersHandler(string lexeme, int currentLine, int currentIndex, int tokenCount, 
            string sourceCode, IPccRegExHandler pccRegExHandler)
        {
            _lexeme = lexeme;
            _currentLine = currentLine;
            _currentIndex = currentIndex;
            _tokenCount = tokenCount;
            _sourceCode = sourceCode;
            _pccRegExHandler = pccRegExHandler;
            _peek = GetCharInTheCurrentPosition();

            ConsumeCharWhenItIsAWhiteSpaceOrTabulationOrBreakline();
        }


        public string Lexeme { get => _lexeme; set => _lexeme = value; }

        public int CurrentIndex { get => _currentIndex; set => _currentIndex = value; }

        public int CurrentLine { get => _currentLine; set => _currentLine = value; }

        public char Peek { get => _peek; }


        public IPccCharactersHandler SetNext(IPccCharactersHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual Task<IPccToken> Handle(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

            if (_nextHandler != null)
            {
                _nextHandler.Lexeme = _lexeme;
                _nextHandler.CurrentIndex = _currentIndex;
                _nextHandler.CurrentLine = _currentLine;

                return _nextHandler.Handle(cancellationToken);
            }
            return null;
        }


        protected char GetCharInTheCurrentPosition()
        {
            try
            {
                return _sourceCode[_currentIndex];
            }
            catch (IndexOutOfRangeException)
            {
                return END_OF_CODE;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        protected char GetNextCharOfSourceCode()
        {
            try
            {
                _currentIndex += 1;
                return _sourceCode[_currentIndex];
            }
            catch (IndexOutOfRangeException)
            {
                return END_OF_CODE;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        protected char GetBackOnePositionForPeek()
        {
            try
            {
                _currentIndex -= 1;
                return _sourceCode[_currentIndex];
            }
            catch
            {
                return END_OF_CODE;
            }
        }

        protected void IncrCurrentIndex()
        {
            _currentIndex += 1;
        }

        protected void DecrCurrentIndex()
        {
            _currentIndex -= 1;
        }

        private void ConsumeCharWhenItIsAWhiteSpaceOrTabulationOrBreakline()
        {
            while (_peek == 9 || _peek == 10 || _peek == 13 || _peek == 32 || _peek == '\n')
            {
                if (_peek == '\n'){
                    _currentLine++;
                }
                _peek = GetNextCharOfSourceCode();
            }
        }

        protected void ScanNumericCharacters()
        {
            while (isPeekADigit() || isPeekADot() || isPeekAnAdditionOperator() || isPeekASubtractionOperator() ||
                isPeekANotationScientificSymbol())
            {
                _lexeme += _peek.ToString();
                _peek = GetNextCharOfSourceCode();
            }
        }

        protected void ScanLetterCharacters(ref string lexeme)
        {
            while (isPeekALetter())
            {
                lexeme += _peek.ToString();
                _peek = GetNextCharOfSourceCode();
            }
        }

        protected void ScanLetterOrDigitOrUnderscoreCharacters(ref string lexeme)
        {
            while (isPeekALetter() || isPeekADigit() || isPeekAnUnderscore())
            {
                lexeme += _peek.ToString();
                _peek = GetNextCharOfSourceCode();
            }
        }

        protected void ScanAllCharactersUpToTheNextDelimiter(char delimiter)
        {
            _peek = GetNextCharOfSourceCode();

            while (_peek != delimiter && _peek != '\n')
            {
                _lexeme += _peek.ToString();
                _peek = GetNextCharOfSourceCode();
            }

            if (_peek == delimiter){
                IncrCurrentIndex();
            }
            else if (_peek != '\n')
            {
                IncrCurrentIndex();
                _currentLine += 1;
            }
        }

        protected void ScanAllCharactersToTheRightOfSingleQuote()
        {
            _peek = GetNextCharOfSourceCode();

            while (_peek != '\n')
            {
                _lexeme += _peek.ToString();
                _peek = GetNextCharOfSourceCode();
            }

            if (_peek == '\''){
                IncrCurrentIndex();
            }
            else if (_peek != '\n')
            {
                IncrCurrentIndex();
                _currentLine += 1;
            }
        }

        protected bool isPeekADigit()
        {
            return _pccRegExHandler.ValidateChar(_peek, @"^([0-9])$", _cancellationToken).Result.Length > 0;
        }

        protected bool isPeekALetter()
        {
            return _pccRegExHandler.ValidateChar(_peek, @"^([a-z]|[A-Z])$", _cancellationToken).Result.Length > 0;
        }

        protected bool isPeekAnArithmeticsOperator()
        {
            return _pccRegExHandler.ValidateChar(_peek, @"^[\+|\-|\*|/|\^]$", _cancellationToken).Result.Length > 0;
        }

        protected bool isPeekARelationalOperator()
        {
            return _pccRegExHandler.ValidateChar(_peek, @"^[<|>|=]$", _cancellationToken).Result.Length > 0;
        }

        protected bool isPeekASpecialCharacter()
        {
            return _pccRegExHandler.ValidateChar(_peek, @"^[:|\$|\#|\&]$", _cancellationToken)
                .Result.Length > 0;
        }

        protected bool isPeekAComma()
        {
            if (_peek == ','){
                return true;
            }
            return false;
        }

        protected bool isPeekADot()
        {
            if (_peek == '.'){
                return true;
            }
            return false;
        }

        protected bool isPeekAnAdditionOperator()
        {
            if (_peek == '+'){
                return true;
            }
            return false;
        }

        protected bool isPeekASubtractionOperator()
        {
            if (_peek == '-'){
                return true;
            }
            return false;
        }

        protected bool isPeekAMultiplicationOperator()
        {
            if (_peek == '*'){
                return true;
            }
            return false;
        }

        protected bool isPeekADivisionOperator()
        {
            if (_peek == '/'){
                return true;
            }
            return false;
        }

        protected bool isPeekAnIntegerDivisionOperator()
        {
            if (_peek == '\\'){
                return true;
            }
            return false;
        }

        protected bool isPeekAnExponentiationOperator()
        {
            if (_peek == '^'){
                return true;
            }
            return false;
        }

        protected bool isPeekAnOpenBracket()
        {
            if (_peek == '('){
                return true;
            }
            return false;
        }

        protected bool isPeekACloseBracket()
        {
            if (_peek == ')'){
                return true;
            }
            return false;
        }

        protected bool isPeekAnOpenBrace()
        {
            if (_peek == '{'){
                return true;
            }
            return false;
        }

        protected bool isPeekACloseBrace()
        {
            if (_peek == '}'){
                return true;
            }
            return false;
        }

        protected bool isPeekASingleQuote()
        {
            if (_peek == '\''){
                return true;
            }
            return false;
        }

        protected bool isPeekADoubleQuote()
        {
            if (_peek == '\"'){
                return true;
            }
            return false;
        }

        protected bool isPeekAColon()
        {
            if (_peek == ':'){
                return true;
            }
            return false;
        }

        protected bool isPeekADolar()
        {
            if (_peek == '$'){
                return true;
            }
            return false;
        }

        protected bool isPeekAnHashTag()
        {
            if (_peek == '#'){
                return true;
            }
            return false;
        }

        protected bool isPeekAConcatSymbol()
        {
            if (_peek == '&'){
                return true;
            }
            return false;
        }

        protected bool isPeekAnUnderscore()
        {
            if (_peek == '_'){
                return true;
            }
            return false;
        }

        protected bool isPeekAHifen()
        {
            if (_peek == '-'){
                return true;
            }
            return false;
        }

        protected bool isPeekANotationScientificSymbol()
        {
            if (_peek == 'e' || _peek == 'E'){
                return true;
            }
            return false;
        }
    }
}
