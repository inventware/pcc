using System;


namespace PCC.Frontend
{
    public interface IPccToken
    {
        int Id
        {
            get;
        }

        ETokenName Name
        {
            get;
        }

        IPccLexeme Lexeme
        {
            get;
        }

        bool AddToTheTableOfTokens
        {
            get;
        }
    }
}
