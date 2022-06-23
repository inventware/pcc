﻿using PCC.Core.Handlers;
using PCC.Frontend.Lexer;
using System;
using System.Threading;


namespace PCC.Frontend.Parser
{
    public class PccParser : IPccParser
    {
        private IPccLexer _pccLexer;
        private IPccRegExHandler _pccRegExHandler;
        private IPccParserNotificationHandler _notificationsHandler;
        private CancellationToken _cancellationToken;
        private IPccToken _lookAhead;
        private int _tokenCount;


        public PccParser(IPccRegExHandler pccRegExHandler, IPccParserNotificationHandler
            notificationsHandler, CancellationTokenSource cancellationTokenSource)
        {
            _pccRegExHandler = pccRegExHandler;
            _notificationsHandler = notificationsHandler;
            _cancellationToken = cancellationTokenSource.Token;
            _tokenCount = 0;
            _lookAhead = null;
        }


        public int TokenCount { get => _tokenCount; protected set => _tokenCount = value; }
        
        public IPccParserNotificationHandler NotificationsHandler { get => _notificationsHandler; protected set => _notificationsHandler = value; }

        
        public void Parser(string sourceCode)
        {
            var lexerNotificationHandler = new PccLexerNotificationHandler();
            _pccLexer = new PccLexer(sourceCode, _pccRegExHandler, lexerNotificationHandler, _cancellationToken);
            _lookAhead = _pccLexer.GetNextToken(_tokenCount).Result;
            IPccToken tokenForForcedInterruption = null;

            while (_lookAhead != null && !_lookAhead.Name.Equals(ETokenName.END_OF_CODE))
            {
                ParseToken();
                
                // Security condition: It avoids infinite loop
                if (tokenForForcedInterruption == _lookAhead)
                {
                    _lookAhead = new PccToken(_lookAhead.Id + 1, ETokenName.END_OF_CODE, _lookAhead.Lexeme.Value, 
                        _lookAhead.Lexeme.Line);
                    IncrTokenCountIfIsNotEndOfCode();
                }
                else {
                    tokenForForcedInterruption = _lookAhead;
                }
            }
        }

        private void ParseToken()
        {
            switch (_lookAhead.Name)
            {
                case ETokenName.ABS_FUNC:
                    
                    break;
                case ETokenName.ADD_OP:

                    break;
                case ETokenName.AND_OP:

                    break;
                case ETokenName.AS:

                    break;
                case ETokenName.ASC_FUNC:

                    break;
                case ETokenName.ATN_FUNC:

                    break;
                case ETokenName.BOOLEAN:

                    break;
                case ETokenName.BYREF:

                    break;
                case ETokenName.BYVAL:

                    break;
                case ETokenName.CALL:

                    break;
                case ETokenName.CASE:

                    break;
                case ETokenName.CHR_FUNC:

                    break;
                case ETokenName.CLOSE_BRACE:

                    break;
                case ETokenName.CLOSE_BRACKET:

                    break;
                case ETokenName.CLOSE_SQUARE_BRACKET:

                    break;
                case ETokenName.COLON:

                    break;
                case ETokenName.COMMA:

                    break;
                case ETokenName.COMMENTED_TEXT:

                    break;
                case ETokenName.CONCAT_OP:

                    break;
                case ETokenName.CONST:

                    break;
                case ETokenName.COS_FUNC:

                    break;
                case ETokenName.CVERR_FUNC:

                    break;
                case ETokenName.DATE:

                    break;
                case ETokenName.DATE_DDmmYYYY:

                    break;
                case ETokenName.DATE_MMddYYYY:

                    break;
                case ETokenName.DATE_MMMddYYYY:

                    break;
                case ETokenName.DATE_MMMMddYYYY:

                    break;
                case ETokenName.DATE_YYYYmmDD:

                    break;
                case ETokenName.DATE_TIME_DDmmYYYY_HHMMSS:

                    break;
                case ETokenName.DATE_TIME_mmDDYYYY_HHMMSS:

                    break;
                case ETokenName.DATE_TIME_YYYYmmDD_HHMMSS:

                    break;
                case ETokenName.DEBUG:

                    break;
                case ETokenName.DIM:
                    Match(ETokenName.DIM);
                    //PublicDeclarationStatement();
                    break;

                case ETokenName.DIV_OP:

                    break;
                case ETokenName.DO:

                    break;
                case ETokenName.DOUBLE:

                    break;
                case ETokenName.EACH:

                    break;
                case ETokenName.ELSE:

                    break;
                case ETokenName.ELSEIF:

                    break;
                case ETokenName.EMPTY:

                    break;
                case ETokenName.END:

                    break;
                case ETokenName.END_OF_CODE:

                    break;
                case ETokenName.EQUAL_OP:

                    break;
                case ETokenName.ERROR:

                    break;
                case ETokenName.EXIT:

                    break;
                case ETokenName.EXP_FUNC:

                    break;
                case ETokenName.EXP_OP:

                    break;
                case ETokenName.FALSE:

                    break;
                case ETokenName.FIX_FUNC:

                    break;
                case ETokenName.FOR:

                    break;
                case ETokenName.FORMAT_FUNC:

                    break;
                case ETokenName.FUNCTION:

                    break;
                case ETokenName.GOTO:

                    break;
                case ETokenName.GREATER_THAN_OP:

                    break;
                case ETokenName.GREATER_THAN_OR_EQUAL_OP:

                    break;
                case ETokenName.HEX_FUNC:

                    break;
                case ETokenName.ID:
                    //Match(ETokenName.ID);
                    break;
                case ETokenName.IF:

                    break;
                case ETokenName.IN:

                    break;
                case ETokenName.INTEGER:

                    break;
                case ETokenName.INT_DIV_OP:

                    break;
                case ETokenName.INT_FUNC:

                    break;
                case ETokenName.ISARRAY:

                    break;
                case ETokenName.ISDATE:

                    break;
                case ETokenName.ISEMPTY:

                    break;
                case ETokenName.ISMISSING:

                    break;
                case ETokenName.ISNULL:

                    break;
                case ETokenName.ISNUMERIC:

                    break;
                case ETokenName.LESS_THAN_OP:

                    break;
                case ETokenName.LESS_THAN_OR_EQUAL_OP:

                    break;
                case ETokenName.LITERAL:

                    break;
                case ETokenName.LOG_FUNC:

                    break;
                case ETokenName.LONG:

                    break;
                case ETokenName.LOOP:

                    break;
                case ETokenName.MOD_OP:

                    break;
                case ETokenName.MULT_OP:

                    break;
                case ETokenName.NEW:

                    break;
                case ETokenName.NEXT:

                    break;
                case ETokenName.NULL:

                    break;
                case ETokenName.NUM_FLOAT:

                    break;
                case ETokenName.NUM_INT:

                    break;
                case ETokenName.NUM_SCIENT_NOT:

                    break;
                case ETokenName.OBJECT:

                    break;
                case ETokenName.OCT_FUNC:

                    break;
                case ETokenName.ON:

                    break;
                case ETokenName.OPEN_BRACE:

                    break;
                case ETokenName.OPEN_BRACKET:

                    break;
                case ETokenName.OPEN_SQUARE_BRACKET:

                    break;
                case ETokenName.OR_OP:

                    break;
                case ETokenName.POINT:

                    break;
                case ETokenName.PRINT:
                    
                    break;

                case ETokenName.PRIVATE:
                    PrivateDeclarationStatement();
                    break;

                case ETokenName.PUBLIC:
                    PublicDeclarationStatement();
                    break;

                case ETokenName.RND_FUNC:

                    break;
                case ETokenName.SELECT:

                    break;
                case ETokenName.SEMICOLON:

                    break;
                case ETokenName.SGN_FUNC:

                    break;
                case ETokenName.SINGLE:

                    break;
                case ETokenName.SIN_FUNC:

                    break;
                case ETokenName.SQR_FUNC:

                    break;
                case ETokenName.STRING:

                    break;
                case ETokenName.STR_FUNC:

                    break;
                case ETokenName.SUB:

                    break;
                case ETokenName.SUB_OP:

                    break;
                case ETokenName.TAN_FUNC:

                    break;
                case ETokenName.THEN:

                    break;
                case ETokenName.TIME_HHMMSS:

                    break;
                case ETokenName.TIME_HHMMSS_AMPM:

                    break;
                case ETokenName.TIME_HHMMSS_MMM:

                    break;
                case ETokenName.TO:

                    break;
                case ETokenName.TRUE:

                    break;
                case ETokenName.UBOUND:

                    break;
                case ETokenName.UNDEFINED:

                    break;
                case ETokenName.UNDERSCORE:

                    break;
                case ETokenName.UNTIL:

                    break;
                case ETokenName.VAL_FUNC:

                    break;
                case ETokenName.VARIANT:

                    break;
                case ETokenName.WEND:

                    break;
                case ETokenName.WHILE:

                    break;
                default:
                    _notificationsHandler.Handle(new PccParserNotification("PAR_" + _tokenCount.ToString(), 
                        "SYNTAX ERROR", _lookAhead.Lexeme.Line));
                    break;
            }
        }

        private void IncrTokenCountIfIsNotEndOfCode()
        {
            if (!_lookAhead.Name.Equals(ETokenName.END_OF_CODE)){
                _tokenCount++;
            }
        }

        private void Match(ETokenName tokenName)
        {
            if (_lookAhead.Name == tokenName) 
            {
                _tokenCount += 1;
                _lookAhead = _pccLexer.GetNextToken(_tokenCount).Result;
            }
            else {
                _notificationsHandler.Handle(new PccParserNotification("PAR_" + _tokenCount.ToString(),
                    "SYNTAX ERROR", _lookAhead.Lexeme.Line));
            }
        }

        private void PrivateDeclarationStatement()
        {
            Match(ETokenName.PRIVATE);

            switch (_lookAhead.Name)
            {
                case ETokenName.CONST:
                    Match(ETokenName.CONST);
                    break;

                case ETokenName.SUB:
                    SubroutineStatement();
                    break;

                case ETokenName.FUNCTION:
                    FunctionStatement();
                    break;

                default:
                    _notificationsHandler.Handle(new PccParserNotification("PAR_" + _tokenCount.ToString(),
                        "SYNTAX ERROR", _lookAhead.Lexeme.Line));
                    break;
            }
        }

        private void PublicDeclarationStatement()
        {
            Match(ETokenName.PUBLIC);

            switch (_lookAhead.Name)
            {
                case ETokenName.CONST:
                    Match(ETokenName.CONST);
                    break;

                case ETokenName.SUB:
                    SubroutineStatement();
                    break;

                case ETokenName.FUNCTION:
                    FunctionStatement();
                    break;

                default:
                    _notificationsHandler.Handle(new PccParserNotification("PAR_" + _tokenCount.ToString(),
                        "SYNTAX ERROR", _lookAhead.Lexeme.Line));
                    break;
            }
        }

        private void SubroutineStatement()
        {
            Match(ETokenName.SUB);
            Match(ETokenName.ID);
            Match(ETokenName.OPEN_BRACKET);
            ParametersStatement();
            // Bloco de Codigo
            Match(ETokenName.END);
            Match(ETokenName.SUB);
        }

        private void FunctionStatement()
        {
            Match(ETokenName.FUNCTION);
            Match(ETokenName.ID);
            Match(ETokenName.OPEN_BRACKET);
            // carrega parametros
            Match(ETokenName.CLOSE_BRACKET);
            // Bloco de Codigo
            Match(ETokenName.END);
            Match(ETokenName.FUNCTION);
        }

        private void ParametersStatement()
        {
            // IPccToken tokenForForcedInterruption = null;
            int tokenForInterruptionControl = int.MinValue;

            while (_lookAhead.Name != ETokenName.CLOSE_BRACKET &&
                   _tokenCount != tokenForInterruptionControl)
            {
                // Security condition: It avoids infinite loop
                tokenForInterruptionControl = _tokenCount;
                ParameterStatement();
            }
            // carrega parametros
            Match(ETokenName.CLOSE_BRACKET);
        }

        private void ParameterStatement()
        {
            Match(ETokenName.ID);
            Match(ETokenName.AS);
            IdentifierTypeStatement();
        }

        private void IdentifierTypeStatement()
        {
            switch (_lookAhead.Name)
            {
                case ETokenName.INTEGER:
                    Match(ETokenName.INTEGER);
                    break;

                case ETokenName.LONG:
                    Match(ETokenName.LONG);
                    break;

                case ETokenName.SINGLE:
                    Match(ETokenName.SINGLE);
                    break;

                case ETokenName.DOUBLE:
                    Match(ETokenName.DOUBLE);
                    break;

                case ETokenName.STRING:
                    Match(ETokenName.STRING);
                    break;

                case ETokenName.DATE:
                    Match(ETokenName.DATE);
                    break;

                case ETokenName.BOOLEAN:
                    Match(ETokenName.BOOLEAN);
                    break;

                case ETokenName.OBJECT:
                    Match(ETokenName.OBJECT);
                    break;

                case ETokenName.VARIANT:
                    Match(ETokenName.SINGLE);
                    break;

                default:
                    break;
            }
        }
    }
}
