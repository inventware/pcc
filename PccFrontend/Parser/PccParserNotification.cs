using PCC.Core.Entities;


namespace PCC.Frontend.Parser
{
    public class PccParserNotification : Notification
    {
        private int _line;

        public PccParserNotification(string code, string description, int line) : base(code, description)
        {
            _line = line;
        }

        public int Line
        {
            get { return _line; }
        }
    }
}
