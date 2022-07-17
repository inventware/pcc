using System;


namespace PCC.Frontend.Parser
{
    public abstract class PccMethodParser : PccAbstractParser
    {
        protected void ParametersStatement()
        {
            int tokenForInterruptionControl = int.MinValue;

            while (_lookAhead.Name != ETokenName.CLOSE_BRACKET &&
                   _tokenCount != tokenForInterruptionControl)
            {
                // Security condition: It avoids infinite loop
                tokenForInterruptionControl = _tokenCount;
                PassingMechanismParameterStatement();

                // When there are more than 1 parameter!
                if(_lookAhead.Name == ETokenName.COMMA){
                    Match(ETokenName.COMMA);
                }
            }
            // Load parameters
            Match(ETokenName.CLOSE_BRACKET);
        }

        private void PassingMechanismParameterStatement()
        {
            if (_lookAhead.Name == ETokenName.BYREF)
            {
                Match(ETokenName.BYREF);
                ParameterStatement();
            }
            else if (_lookAhead.Name == ETokenName.BYVAL)
            {
                Match(ETokenName.BYVAL);
                ParameterStatement();
            }
            else {
                ParameterStatement();
            }
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
                    Match(ETokenName.VARIANT);
                    break;

                default:
                    _notificationsHandler.Handle(new PccParserNotification("PAR_" + _tokenCount.ToString(),
                        "SYNTAX ERROR - Unknow Type Parameter", _lookAhead.Lexeme.Line));
                    break;
            }
        }
    }
}
