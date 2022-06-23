using PCC.Frontend.Lexer;


namespace PCC.Frontend
{
    public class PccToken : IPccToken
    {
        public PccToken(int id, ETokenName name, string value, int line, bool? addToTheTableOfTokens = true)
        {
            Id = id;
            Name = name;
            AddToTheTableOfTokens = addToTheTableOfTokens.GetValueOrDefault();
            Lexeme = new PccLexeme(value, line);
        }

        public int Id
        {
            get; protected set;
        }

        public ETokenName Name
        {
            get; protected set;
        }

        public IPccLexeme Lexeme
        {
            get; protected set;
        }

        public bool AddToTheTableOfTokens
        {
            get; protected set;
        }
    }
}
