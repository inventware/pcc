using System;
using System.Collections.Generic;


namespace PCC.Frontend
{
    internal class PccTableOfTokens
    {
        private Dictionary<int, IPccToken> _DicTokens = null;

        internal PccTableOfTokens()
        {
            _DicTokens = new Dictionary<int, IPccToken>();
        }


        internal int TotalTokens()
        {
            return _DicTokens.Count;
        }

        internal Dictionary<int, IPccToken> GetTokens()
        {
            return _DicTokens;
        }

        internal void Insert(IPccToken token)
        {
            if (token.Lexeme.Line != -1){
                _DicTokens.Add(_DicTokens.Count + 1, token);
            }
        }

        internal IPccToken GetToken(ref int IndexToken, ref SortedList<int, string> MatrixErrors)
        {
            IPccToken AuxToken = null;
            try
            {
                // Retorna o Próximo Token, caso exista.
                AuxToken = _DicTokens[IndexToken];

                if (AuxToken == null)
                {
                    MatrixErrors.Add(MatrixErrors.Count, "Ocorreu um erro. O código fonte " +
                    " possui instruções inacabadas, tais como declarações de variáveis, funções, " +
                    " sub-rotinas, ou comandos.");
                }
                else {
                    return AuxToken;
                }
            }
            catch
            {
                MatrixErrors.Add(MatrixErrors.Count, "Ocorreu um erro no mecanismo de leitura" +
                                 " de Tokens. Este erro é comum em declarações, expressões e comandos" +
                                 " escritos de forma incompleta.");
            }
            return AuxToken;
        }
    }
}
