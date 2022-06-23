using PCC.Core.Entities;


namespace PCC.Frontend.Lexer
{
    public class PccLexerNotification: Notification
    {
        private int _line;

        public PccLexerNotification(string code, string description, int line) : base(code, description)
        {
            _line = line;
        }

        public int Line
        {
            get { return _line; }
        }
    }
}
