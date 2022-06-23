
namespace PCC.Frontend.Lexer
{
    internal class PccLexeme: IPccLexeme
    {
        internal PccLexeme(string value, int line)
        {

            Value = value;
            Line = line;
        }

        public string Value
        {
            get; protected set;
        }

        public int Line
        {
            get; protected set;
        }
    }
}
